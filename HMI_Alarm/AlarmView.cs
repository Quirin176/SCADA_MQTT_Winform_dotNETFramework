using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Security.Claims;
using HMI_Alarm.Manager;
using System.ComponentModel.Design;
using System.Media;
using System.IO;
using System.Threading;

namespace HMI_Alarm
{
    [Designer(typeof(HMIDisplayDesigner2))]
    public partial class AlarmView : UserControl
    {
        protected System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        private readonly BindingList<Alarm> alarms = new BindingList<Alarm>();

        private DateTime dta;
        private readonly string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=LVTN;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private readonly SqlConnection connection;

        //private readonly SoundPlayer player;
        //private readonly Stream stream = Properties.Resources.mixkit_classic_short_alarm_993;
        private bool allAcknowledged;

        public AlarmView()
        {
            InitializeComponent();

            dataGridView1.DataSource = alarms;

            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].Width = 175;
            dataGridView1.Columns[2].Width = 275;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 250;

            dataGridView1.Columns["Acknowledged"].Visible = false;

            this.Dock = DockStyle.Fill;
            this.Privilege = 1;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error establishing database connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //not support design time
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv"
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "VCSExpress"
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "vbexpress"
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "WDExpress")
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            InitializeTimer();

            //player = new SoundPlayer(stream);
        }

        private void AlarmView_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(UserName + " with privilege level " + UserPrivilege.ToString());
        }

        private void InitializeTimer()
        {
            dta = DateTime.Now;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        [Category("Alarm_Device")]
        private string _DeviceName;
        public string DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }

        [Category("Security")]
        private int _privilege;
        public int Privilege
        {
            get { return _privilege; }
            set
            {
                _privilege = value;
                CheckPrivilege();
            }
        }

        [Category("Security")]
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        [Category("Security")]
        private int _userPrivilege;
        public int UserPrivilege
        {
            get { return _userPrivilege; }
            set
            {
                _userPrivilege = value;
                CheckPrivilege();
            }
        }

        private void CheckPrivilege()
        {
            if (_userPrivilege >= _privilege)
            {
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        private void btn_Acknowledge_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string alarmName = selectedRow.Cells["AlarmName"].Value.ToString();

                // Find the corresponding alarm
                Alarm selectedAlarm = alarms.FirstOrDefault(a => a.AlarmName == alarmName);
                if (selectedAlarm != null)
                {
                    selectedAlarm.DateTime = DateTime.Now; // Update DateTime
                    selectedAlarm.Acknowledged = "YES";
                    selectedAlarm.AcknowledgedBy = UserName;

                    InsertAlarmToDatabase(selectedAlarm); // Insert AcknowledgedBy to database
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please select an alarm to acknowledge.");
            }

            AllAcknowledged_StopSound();
        }

        private void AllAcknowledged_StopSound()
        {
            allAcknowledged = alarms
                .Where(a => a.State == "HIGH HIGH" || a.State == "LOW LOW")
                .All(a => !string.IsNullOrEmpty(a.AcknowledgedBy));
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            Alarm alarm = row.DataBoundItem as Alarm;

            if (alarm != null)
            {
                switch (alarm.State)
                {
                    case "LOW LOW":
                        row.DefaultCellStyle.BackColor = Color.DarkBlue;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "LOW":
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "":
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "HIGH":
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "HIGH HIGH":
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "OFF":
                        row.DefaultCellStyle.BackColor = Color.Gray;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "ON":
                        row.DefaultCellStyle.BackColor = Color.Green;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                }
            }

            row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Alarm_SettingsMode.TimerTicking)
            {
                //Console.WriteLine("Stopped ticking");
                return;
            }
            //Console.WriteLine("Ticking");
            Check_Analog_Alarms();
            Check_Digital_Alarms();
        }

        private void Check_Analog_Alarms()
        {
            try
            {
                string xmlFile = AnalogDevice_Manager.ReadKey(AnalogDevice_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeAnalogData(AnalogDevice_Manager.ReadKey(AnalogDevice_Manager.XML_NAME_DEFAULT));
                AnalogDevice_Manager.GetDeviceAnalogs();

                Device_Analog adevice = AnalogDevice_Manager.GetByDeviceAnalogName(_DeviceName);
                List<Alarm_Analog> aalarmList = adevice.AlarmAnalogs;

                foreach (Alarm_Analog tg in aalarmList)
                {
                    string[] row = {
                    tg.AlarmName,
                    tg.Source,
                    string.Format("{0}", tg.HighHigh),
                    string.Format("{0}", tg.High),
                    string.Format("{0}", tg.Low),
                    string.Format("{0}", tg.LowLow)};

                    if (tg.Source == MQTT_TagCollection.Tags[tg.Source].Topic)
                    {
                        //string alarmName = MQTT_TagCollection.Tags[tg.Source].TagName;
                        double currentValue = Convert.ToDouble(MQTT_TagCollection.Tags[tg.Source].Value);
                        //Console.WriteLine(currentValue.ToString());

                        if (currentValue >= tg.HighHigh)
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "HIGH HIGH");
                        }
                        if (currentValue >= tg.High & currentValue < tg.HighHigh)
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "HIGH");
                        }
                        if (currentValue >= tg.Low & currentValue < tg.High)
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "");
                        }
                        if (currentValue >= tg.LowLow & currentValue < tg.Low)
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "LOW");
                        }
                        if (0 < currentValue & currentValue < tg.LowLow)
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "LOW LOW");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking analog alarm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Check_Digital_Alarms()
        {
            try
            {
                string xmlFile = DigitalDevice_Manager.ReadKey(DigitalDevice_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeDigitalData(DigitalDevice_Manager.ReadKey(DigitalDevice_Manager.XML_NAME_DEFAULT));
                DigitalDevice_Manager.GetDeviceDigitals();

                Device_Digital ddevice = DigitalDevice_Manager.GetByDeviceDigitalName(_DeviceName);
                List<Alarm_Digital> dalarmList = ddevice.AlarmDigitals;

                foreach (Alarm_Digital tg in dalarmList)
                {
                    string[] row = {
                    tg.AlarmName,
                    tg.Source};

                    if (tg.Source == MQTT_TagCollection.Tags[tg.Source].Topic)
                    {
                        //string alarmName = MQTT_TagCollection.Tags[tg.Source].TagName;
                        string currentValue;
                        if (MQTT_TagCollection.Tags[tg.Source].Value != null)
                        {
                            currentValue = MQTT_TagCollection.Tags[tg.Source].Value.ToString().Trim().ToLower();
                        }
                        else
                        {
                            continue; // skip this loop iteration
                        }
                        if (currentValue == "1" || currentValue == "true")
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "ON");
                        }
                        else
                        {
                            LogAlarm(tg.AlarmId, tg.AlarmName, tg.Source, "OFF");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking digital alarm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeAnalogData(string xmlPath)
        {
            AnalogDevice_Manager.DeviceAnalogs.Clear();
            AnalogDevice_Manager.XmlPath = xmlPath;
        }

        private void InitializeDigitalData(string xmlPath)
        {
            DigitalDevice_Manager.DeviceDigitals.Clear();
            DigitalDevice_Manager.XmlPath = xmlPath;
        }

        private void LogAlarm(int alarmId, string alarmName, string source, string state)
        {
            Alarm existingAlarm = alarms.FirstOrDefault(a => a.Source == source);

            if (existingAlarm != null)            //Alarm is existing
            {
                if (existingAlarm.State != state) // Status has changed
                {
                    if (state != "HIGH HIGH" && state != "LOW LOW")
                    {
                        //player.Stop();
                    }

                    existingAlarm.Id = alarmId;
                    existingAlarm.AlarmName = alarmName;
                    existingAlarm.State = state;
                    existingAlarm.DateTime = DateTime.Now; // Update DateTime
                    existingAlarm.Acknowledged = "NO";
                    existingAlarm.AcknowledgedBy = "";

                    allAcknowledged = false;

                    InsertAlarmToDatabase(existingAlarm);
                }

                if (existingAlarm.State == "HIGH HIGH" || existingAlarm.State == "LOW LOW")
                {
                    if (!allAcknowledged)
                    {
                        Thread alarmThread = new Thread(() =>
                        {
                            Console.Beep(5000, 600);
                            Thread.Sleep(200);
                        });

                        alarmThread.IsBackground = true;
                        alarmThread.Start();
                    }
                    else
                    {
                        //player.Stop();
                    }
                }

                dataGridView1.Refresh();
            }
            else
            {
                Alarm alarm = new Alarm
                {
                    Id = alarmId,
                    AlarmName = alarmName,
                    Source = source,
                    State = state,
                    DateTime = DateTime.Now,
                };
                alarms.Add(alarm);

                InsertAlarmToDatabase(alarm); // Insert new alarm to database
            }
        }

        private void InsertAlarmToDatabase(Alarm alarm)
        {
            try
            {
                string query = $"INSERT INTO Alarm_{_DeviceName} (ID, AlarmName, Source, State, DateTime, AcknowledgedBy) VALUES (@ID, @AlarmName, @Source, @State, @DateTime, @AcknowledgedBy)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", alarm.Id);
                    command.Parameters.AddWithValue("@AlarmName", alarm.AlarmName);
                    command.Parameters.AddWithValue("@Source", alarm.Source);
                    command.Parameters.AddWithValue("@State", alarm.State);
                    command.Parameters.AddWithValue("@DateTime", alarm.DateTime);
                    if (alarm.AcknowledgedBy == null)
                        command.Parameters.AddWithValue("@AcknowledgedBy", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@AcknowledgedBy", alarm.AcknowledgedBy);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting alarm data to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Opening settings form...");
            Alarm_SettingsMode.TimerTicking = false;
            using (frm_AlarmTag tagBuilderFrm = new frm_AlarmTag())
            {
                tagBuilderFrm.ShowDialog();
            }
            //Console.WriteLine("Settings form closed.");
            Alarm_SettingsMode.TimerTicking = true;
        }
    }

    public class HMIDisplayDesigner2 : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIDisplayListItem1(this));
                }
                return actionLists;
            }
        }
    }
    public class HMIDisplayListItem1 : DesignerActionList
    {
        private AlarmView colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (AlarmView)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("DeviceName", "DeviceName"));
            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));

            return items;
        }

        public string DeviceName
        {
            get { return colUserControl.DeviceName; }
            set
            {
                colUserControl.DeviceName = value;
                colUserControl.Invalidate();
            }
        }

        public int Privilege
        {
            get { return colUserControl.Privilege; }
            set
            {
                colUserControl.Privilege = value;
                colUserControl.Invalidate();
            }
        }
    }
}
