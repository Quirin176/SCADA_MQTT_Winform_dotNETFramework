using Driver_Tool;
using HMI_Tool.Faceplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HMI_Tool.LSN50_LoRa_Sensor
{
    [Designer(typeof(HMIDisplayDesigner2))]
    public partial class LSN50_LoRa_Sensor : UserControl
    {
        private string _sensorName;
        public string SensorName
        {
            get { return _sensorName; }
            set
            {
                if (_sensorName != value)
                {
                    _sensorName = value;
                    groupBox1.Text = _sensorName;

                    Validate();
                }
            }
        }

        private string _sensorTopic;
        public string SensorTopic
        {
            get { return _sensorTopic; }
            set
            {
                if (_sensorTopic != value)
                {
                    _sensorTopic = value;
                    disp_Datetime.TagName = _sensorTopic;
                    disp_Battery.TagName = _sensorTopic;
                    disp_Temp.TagName = _sensorTopic;
                    disp_Humidity.TagName = _sensorTopic;

                    Validate();
                }
            }
        }

        private double _tempHighHigh = 35;
        public double TempHighHigh
        {
            get { return _tempHighHigh; }
            set
            {
                if (_tempHighHigh != value)
                {
                    _tempHighHigh = value;
                    CheckAlarm(disp_Temp, TempHighHigh, TempHigh, TempLow, TempLowLow);
                    Validate();
                }
            }
        }

        private double _tempHigh = 30;
        public double TempHigh
        {
            get { return _tempHigh; }
            set
            {
                if (_tempHigh != value)
                {
                    _tempHigh = value;
                    CheckAlarm(disp_Temp, TempHighHigh, TempHigh, TempLow, TempLowLow);
                    Validate();
                }
            }
        }

        private double _tempLow = 25;
        public double TempLow
        {
            get { return _tempLow; }
            set
            {
                if (_tempLow != value)
                {
                    _tempLow = value;
                    CheckAlarm(disp_Temp, TempHighHigh, TempHigh, TempLow, TempLowLow);
                    Validate();
                }
            }
        }

        private double _tempLowLow = 20;
        public double TempLowLow
        {
            get { return _tempLowLow; }
            set
            {
                if (_tempLowLow != value)
                {
                    _tempLowLow = value;
                    CheckAlarm(disp_Temp, TempHighHigh, TempHigh, TempLow, TempLowLow);
                    Validate();
                }
            }
        }

        private double _humHighHigh = 90;
        public double HumHighHigh
        {
            get { return _humHighHigh; }
            set
            {
                if (_humHighHigh != value)
                {
                    _humHighHigh = value;
                    CheckAlarm(disp_Humidity, HumHighHigh, HumHigh, HumLow, HumLowLow);
                    Validate();
                }
            }
        }

        private double _humHigh = 80;
        public double HumHigh
        {
            get { return _humHigh; }
            set
            {
                if (_humHigh != value)
                {
                    _humHigh = value;
                    CheckAlarm(disp_Humidity, HumHighHigh, HumHigh, HumLow, HumLowLow);
                    Validate();
                }
            }
        }

        private double _humLow = 20;
        public double HumLow
        {
            get { return _humLow; }
            set
            {
                if (_humLow != value)
                {
                    _humLow = value;
                    CheckAlarm(disp_Humidity, HumHighHigh, HumHigh, HumLow, HumLowLow);
                    Validate();
                }
            }
        }

        private double _humLowLow = 10;
        public double HumLowLow
        {
            get { return _humLowLow; }
            set
            {
                if (_humLowLow != value)
                {
                    _humLowLow = value;
                    CheckAlarm(disp_Humidity, HumHighHigh, HumHigh, HumLow, HumLowLow);
                    Validate();
                }
            }
        }

        // Privilege
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

        private System.Timers.Timer alarmTimer;
        private bool isAlarmActive;
        public LSN50_LoRa_Sensor()
        {
            InitializeComponent();

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

            InitializeTimers();

            groupBox1.MouseDoubleClick += Sensor_MouseDoubleClick;
            foreach (Control control in groupBox1.Controls)
            {
                control.MouseDoubleClick += Sensor_MouseDoubleClick;
            }

            //player = new SoundPlayer(stream);
        }

        private void LSN50_LoRa_Sensor_Load(object sender, EventArgs e)
        {
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

            //LoadLastDataFromXml();
            LoadSettingsFromXml();
        }

        private void InitializeTimers()
        {
            alarmTimer = new System.Timers.Timer(5 * 60 * 1000); // 5 Minutes
            alarmTimer.Elapsed += AlarmTimer_Elapsed;
            alarmTimer.AutoReset = true;
            alarmTimer.Enabled = true;
        }

        private void AlarmTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isAlarmActive)
            {
                PlaySound();
            }
        }

        private void disp_Battery_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(disp_Temp.Text))
            {
                SaveDataToXml();
            }
        }

        private void disp_Temp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(disp_Temp.Text))
            {
                CheckAlarm(disp_Temp, TempHighHigh, TempHigh, TempLow, TempLowLow);
                SaveDataToXml();
            }
        }

        private void disp_Humidity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(disp_Humidity.Text))
            {
                CheckAlarm(disp_Humidity, HumHighHigh, HumHigh, HumLow, HumLowLow);
                SaveDataToXml();
            }
        }

        //private readonly SoundPlayer player;
        //private readonly Stream stream = Properties.Resources.mixkit_classic_short_alarm_993;
        private void CheckAlarm(HMI_Edition.HMIDisplay.LSN50_LoRa_Display dispbox, double highhigh, double high, double low, double lowlow)
        {
            if (dispbox.Text == null)
            {
                return;
            }
            //Console.WriteLine(dispbox.Text);
            if (double.TryParse(dispbox.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                if (value >= highhigh)
                {
                    dispbox.BackColor = Color.Red;
                    dispbox.ForeColor = Color.White;
                    AlarmSound(true);
                }
                if (value >= high && value < highhigh)
                {
                    dispbox.BackColor = Color.Orange;
                    dispbox.ForeColor = Color.Black;
                    AlarmSound(false);
                }
                if (value >= low && value < high)
                {
                    dispbox.BackColor = Color.Yellow;
                    dispbox.ForeColor = Color.Black;
                    AlarmSound(false);
                }
                if (value >= lowlow && value < low)
                {
                    dispbox.BackColor = Color.LightBlue;
                    dispbox.ForeColor = Color.Black;
                    AlarmSound(false);
                }
                if (value < lowlow)
                {
                    dispbox.BackColor = Color.Blue;
                    dispbox.ForeColor = Color.White;
                    AlarmSound(true);
                }
            }
        }

        private void AlarmSound(bool enable)
        {
            if (enable)
            {
                isAlarmActive = true;
                alarmTimer.Start();
                PlaySound();
            }
            else if (!enable)
            {
                isAlarmActive = false;
                alarmTimer.Stop();
            }
        }

        private void PlaySound()
        {
            Thread alarmThread = new Thread(() =>
            {
                DateTime endTime = DateTime.Now.AddSeconds(20);
                while (DateTime.Now < endTime)
                {
                    Console.Beep(5000, 600);
                    Thread.Sleep(200);
                }
            });

            alarmThread.IsBackground = true;
            alarmThread.Start();
        }

        private void Sensor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(_tempHighHigh.ToString());
            //Console.WriteLine(_tempHigh.ToString());
            //Console.WriteLine(_tempLow.ToString());
            //Console.WriteLine(_tempLowLow.ToString());

            LSN50_Faceplate fpl = new LSN50_Faceplate(this);
            fpl.ShowDialog();

            this.OnMouseDoubleClick(e);
        }

        public SensorData GetData()
        {
            return new SensorData
            {
                Sensorname = _sensorName,
                Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Battery = disp_Battery.Text,
                Temperature = disp_Temp.Text,
                Humidity = disp_Humidity.Text
            };
        }

        public void SaveDataToXml()
        {
            try
            {
                SensorData currentData = GetData();
                if (string.IsNullOrWhiteSpace(currentData.Battery) ||
                    string.IsNullOrWhiteSpace(currentData.Temperature) ||
                    string.IsNullOrWhiteSpace(currentData.Humidity))
                {
                    return;
                }
                if (currentData.Battery == "N/A" || currentData.Temperature == "N/A" || currentData.Humidity == "N/A")
                {
                    return;
                }

                string logDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogData");
                if (!Directory.Exists(logDataDir))
                {
                    Directory.CreateDirectory(logDataDir);
                }

                // Define the file path based on the current date
                string logFileName = $"{DateTime.Now:yyyy-MM-dd}.xml";
                string logFilePath = Path.Combine(logDataDir, logFileName);

                // Thread-safe lock on the type
                lock (typeof(LSN50_LoRa_Sensor))
                {
                    AllSensorsData allData;

                    // Check if the file exists and load its data if available
                    if (File.Exists(logFilePath))
                    {
                        try
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(AllSensorsData));
                            using (StreamReader reader = new StreamReader(logFilePath))
                            {
                                allData = (AllSensorsData)serializer.Deserialize(reader);
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Handle deserialization failure and reset data
                            allData = new AllSensorsData();
                            MessageBox.Show($"XML Deserialization Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        allData = new AllSensorsData();
                    }

                    // Add new data
                    allData.Sensors.Add(currentData);

                    // Save updated data back to the file
                    XmlSerializer serializerSave = new XmlSerializer(typeof(AllSensorsData));
                    using (StreamWriter writer = new StreamWriter(logFilePath, false)) // Overwrite the file
                    {
                        serializerSave.Serialize(writer, allData);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File is in use or other IO issue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static readonly string LastDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllLastSensorsData.xml");
        //private static readonly object FileLock = new object();
        //public void SaveLastDataToXml()
        //{
        //    try
        //    {
        //        lock (FileLock)
        //        {
        //            // Load existing data or initialize a new list
        //            AllSensorsData allData;
        //            if (File.Exists(LastDataFilePath))
        //            {
        //                XmlSerializer serializer = new XmlSerializer(typeof(AllSensorsData));
        //                using (StreamReader reader = new StreamReader(LastDataFilePath))
        //                {
        //                    allData = (AllSensorsData)serializer.Deserialize(reader);
        //                }
        //            }
        //            else
        //            {
        //                allData = new AllSensorsData();
        //            }

        //            // Get current sensor data
        //            SensorData currentData = GetData();

        //            // Check if all fields are null or empty then skip
        //            if (string.IsNullOrWhiteSpace(currentData.Battery) &&
        //                string.IsNullOrWhiteSpace(currentData.Temperature) &&
        //                string.IsNullOrWhiteSpace(currentData.Humidity))
        //            {
        //                return;
        //            }

        //            // Find the existing sensor data by SensorName
        //            var existingData = allData.Sensors.FirstOrDefault(s => s.Sensorname == currentData.Sensorname);

        //            if (existingData != null)
        //            {
        //                // Update only non-null/non-empty fields
        //                if (!string.IsNullOrWhiteSpace(currentData.Battery))
        //                {
        //                    existingData.Battery = currentData.Battery;
        //                }
        //                if (!string.IsNullOrWhiteSpace(currentData.Temperature))
        //                {
        //                    existingData.Temperature = currentData.Temperature;
        //                }
        //                if (!string.IsNullOrWhiteSpace(currentData.Humidity))
        //                {
        //                    existingData.Humidity = currentData.Humidity;
        //                }

        //                existingData.Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Update timestamp
        //            }
        //            else
        //            {
        //                // Add new sensor data if it has at least one non-empty field
        //                allData.Sensors.Add(currentData);
        //            }

        //            // Save updated data back to the XML file
        //            XmlSerializer serializerSave = new XmlSerializer(typeof(AllSensorsData));
        //            using (StreamWriter writer = new StreamWriter(LastDataFilePath, false)) // Overwrite the file
        //            {
        //                serializerSave.Serialize(writer, allData);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //public void LoadLastDataFromXml()
        //{
        //    try
        //    {
        //        if (!File.Exists(LastDataFilePath))
        //            return;

        //        lock (FileLock) // Thread safety
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(AllSensorsData));
        //            using (StreamReader reader = new StreamReader(LastDataFilePath))
        //            {
        //                AllSensorsData allData = (AllSensorsData)serializer.Deserialize(reader);

        //                // Find the data for this sensor
        //                SensorData sensorData = allData.Sensors
        //                    .FirstOrDefault(sensor => sensor.Sensorname == SensorName);

        //                if (sensorData != null)
        //                {
        //                    // Only load data if the current value is null or white space
        //                    if (string.IsNullOrWhiteSpace(disp_Datetime.Text))
        //                        disp_Datetime.Text = sensorData.Datetime;

        //                    if (string.IsNullOrWhiteSpace(disp_Battery.Text))
        //                        disp_Battery.Text = sensorData.Battery;

        //                    if (string.IsNullOrWhiteSpace(disp_Temp.Text))
        //                        disp_Temp.Text = sensorData.Temperature;

        //                    if (string.IsNullOrWhiteSpace(disp_Humidity.Text))
        //                        disp_Humidity.Text = sensorData.Humidity;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading sensor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void LoadSettingsFromXml()
        {
            try
            {
                lock (typeof(LSN50_LoRa_Sensor)) // Thread-safe access
                {
                    if (!File.Exists(LSN50_Faceplate.FilePath))
                    {
                        MessageBox.Show("Settings file not found. Default values will be used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(AllSensorSettings));
                    using (StreamReader reader = new StreamReader(LSN50_Faceplate.FilePath))
                    {
                        AllSensorSettings allSettings = (AllSensorSettings)serializer.Deserialize(reader);

                        // Find the matching sensor settings by name
                        SensorSettings sensorSettings = allSettings.Sensors.FirstOrDefault(s => s.SensorName == _sensorName);
                        if (sensorSettings != null)
                        {
                            TempHighHigh = sensorSettings.TempHighHigh;
                            TempHigh = sensorSettings.TempHigh;
                            TempLow = sensorSettings.TempLow;
                            TempLowLow = sensorSettings.TempLowLow;

                            HumHighHigh = sensorSettings.HumHighHigh;
                            HumHigh = sensorSettings.HumHigh;
                            HumLow = sensorSettings.HumLow;
                            HumLowLow = sensorSettings.HumLowLow;
                        }
                        else
                        {
                            MessageBox.Show($"Settings for sensor '{_sensorName}' not found. Default values will be used.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private LSN50_LoRa_Sensor colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (LSN50_LoRa_Sensor)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("SensorName", "SensorName"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm1", "Choose Tag For Sensor"));
            items.Add(new DesignerActionPropertyItem("SensorTopic", "SensorTopic"));

            items.Add(new DesignerActionPropertyItem("TempHighHigh", "TempHighHigh"));
            items.Add(new DesignerActionPropertyItem("TempHigh", "TempHigh"));
            items.Add(new DesignerActionPropertyItem("TempLow", "TempLow"));
            items.Add(new DesignerActionPropertyItem("TempLowLow", "TempLowLow"));

            items.Add(new DesignerActionPropertyItem("HumHighHigh", "HumHighHigh"));
            items.Add(new DesignerActionPropertyItem("HumHigh", "HumHigh"));
            items.Add(new DesignerActionPropertyItem("HumLow", "HumLow"));
            items.Add(new DesignerActionPropertyItem("HumLowLow", "HumLowLow"));

            return items;
        }

        public string SensorName
        {
            get { return colUserControl.SensorName; }
            set
            {
                colUserControl.SensorName = value;
                colUserControl.Invalidate();
            }
        }

        public string SensorTopic
        {
            get { return colUserControl.SensorTopic; }
            set
            {
                colUserControl.SensorTopic = value;
                colUserControl.Invalidate();
            }
        }

        public double TempHighHigh
        {
            get { return colUserControl.TempHighHigh; }
            set
            {
                colUserControl.TempHighHigh = value;
                colUserControl.Invalidate();
            }
        }

        public double TempHigh
        {
            get { return colUserControl.TempHigh; }
            set
            {
                colUserControl.TempHigh = value;
                colUserControl.Invalidate();
            }
        }

        public double TempLow
        {
            get { return colUserControl.TempLow; }
            set
            {
                colUserControl.TempLow = value;
                colUserControl.Invalidate();
            }
        }

        public double TempLowLow
        {
            get { return colUserControl.TempLowLow; }
            set
            {
                colUserControl.TempLowLow = value;
                colUserControl.Invalidate();
            }
        }

        public double HumHighHigh
        {
            get { return colUserControl.HumHighHigh; }
            set
            {
                colUserControl.HumHighHigh = value;
                colUserControl.Invalidate();
            }
        }

        public double HumHigh
        {
            get { return colUserControl.HumHigh; }
            set
            {
                colUserControl.HumHigh = value;
                colUserControl.Invalidate();
            }
        }

        public double HumLow
        {
            get { return colUserControl.HumLow; }
            set
            {
                colUserControl.HumLow = value;
                colUserControl.Invalidate();
            }
        }

        public double HumLowLow
        {
            get { return colUserControl.HumLowLow; }
            set
            {
                colUserControl.HumLowLow = value;
                colUserControl.Invalidate();
            }
        }

        private void ShowTagListForm1()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((lightTopic) =>
            {
                SetProperty(colUserControl, "SensorTopic", lightTopic);
            });

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
