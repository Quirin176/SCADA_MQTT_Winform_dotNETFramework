using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMI_Trend
{
    [Designer(typeof(Daily_Energy_ConsumptionDesigner))]
    public partial class Daily_Energy_Consumption : UserControl
    {
        protected Timer timer = new Timer();
        private readonly PointPairList yesterdayPoints = new PointPairList();
        private readonly PointPairList todayPoints = new PointPairList();
        private readonly object lockObject = new object();

        private readonly string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=LVTN;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private string _TagName;

        public string TagName
        {
            get { return _TagName; }
            set
            {
                _TagName = value;
                if (!string.IsNullOrEmpty(_TagName))
                {
                    if (!timer.Enabled && !DesignMode)
                    {
                        timer.Start();
                    }
                }
                else
                {
                    MessageBox.Show("TagName is not set. Timer will not start.");
                }
            }
        }

        public Daily_Energy_Consumption()
        {
            InitializeComponent();
            SetupGraph();

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

            LoadYesterdayData();

            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(TimerTick);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            if (now.Minute == 0 || now.Minute == 15 || now.Minute == 30 || now.Minute == 45)
            {
                if (now.Second == 0)
                {
                    StoreData();
                }
            }

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                ResetGraphForMidnight();
            }

            UpdateTodayGraph();
        }

        private void SetupGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.Title.Text = "Daily Energy Consumption";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "kWh";

            // Axis range
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Min = new XDate(DateTime.Today.AddDays(-1)); // Start from yesterday
            //myPane.XAxis.Scale.Min = new XDate(DateTime.Today);
            myPane.XAxis.Scale.Max = new XDate(DateTime.Today.AddDays(1)); // End at midnight today
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 300;
            myPane.XAxis.Scale.Format = "hh:mm tt";

            // Create curves
            LineItem yesterdayCurve = myPane.AddCurve("Yesterday's Data", yesterdayPoints, Color.Gray, SymbolType.None);
            LineItem todayCurve = myPane.AddCurve("Today's Data", todayPoints, Color.Blue, SymbolType.None);
            yesterdayCurve.Line.Width = 3;
            todayCurve.Line.Width = 3;

            // Refresh the graph
            zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, Color.Transparent, -45F);
            zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void StoreData()
        {
            string query = "INSERT INTO EnergyConsumption (Date, Time, DateTime, Energy) VALUES (@Date, @Time, @DateTime, @Energy)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                DateTime currentDateTime = DateTime.Now;
                command.Parameters.AddWithValue("@Date", currentDateTime.Date);
                command.Parameters.AddWithValue("@Time", currentDateTime.TimeOfDay);
                command.Parameters.AddWithValue("@DateTime", currentDateTime);
                command.Parameters.AddWithValue("@Energy", Convert.ToDouble(MQTT_TagCollection.Tags[TagName].Value));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to store value to database: {ex.Message}");
                }
            }
        }

        private void UpdateTodayGraph()
        {
            lock (lockObject)
            {
                GraphPane pane = zedGraphControl1.GraphPane;

                double tagValue = Convert.ToDouble(MQTT_TagCollection.Tags[TagName].Value);
                todayPoints.Add(ConvertDateToXdate(DateTime.Now), tagValue);

                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
            }
        }

        private void ResetGraphForMidnight()
        {
            lock (lockObject)
            {
                todayPoints.Clear();

                GraphPane myPane = zedGraphControl1.GraphPane;
                myPane.XAxis.Scale.Min = new XDate(DateTime.Today.AddDays(-1));
                myPane.XAxis.Scale.Max = new XDate(DateTime.Today.AddDays(1));

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                LoadYesterdayData();
            }
        }

        private void LoadYesterdayData()
        {
            string query = "SELECT [Time], [Energy] FROM EnergyConsumption WHERE [Date] = CONVERT(date, DATEADD(day, -1, GETDATE())) ORDER BY [Time]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    yesterdayPoints.Clear();

                    while (reader.Read())
                    {
                        TimeSpan time = reader.GetTimeSpan(0);
                        DateTime dateTime = DateTime.Today.AddDays(-1).Add(time);
                        double value = reader.GetDouble(1);

                        yesterdayPoints.Add(new XDate(dateTime), value);
                    }
                }
            }

            //string query = "SELECT [Time], [Energy] FROM EnergyConsumption WHERE [Date] = @Today ORDER BY [Time]";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.AddWithValue("@Today", DateTime.Today); // Use DateTime.Today for today's date
            //    connection.Open();

            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        yesterdayPoints.Clear(); // Clear yesterday's points to reload

            //        while (reader.Read())
            //        {
            //            TimeSpan time = reader.GetTimeSpan(0); // Time column
            //            DateTime dateTime = DateTime.Today.Add(time); // Combine today's date with the time
            //            double value = reader.GetDouble(1); // Energy column

            //            yesterdayPoints.Add(new XDate(dateTime), value); // Add to yesterday's points
            //        }
            //    }
            //}
        }

        private XDate ConvertDateToXdate(DateTime date)
        {
            return new XDate(date.ToOADate());
        }
    }

    internal class Daily_Energy_ConsumptionDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new Daily_Energy_ConsumptionListItem(this));
                }
                return actionLists;
            }
        }
    }

    internal class Daily_Energy_ConsumptionListItem : DesignerActionList
    {
        private Daily_Energy_Consumption _Daily_Energy_Consumption;
        public Daily_Energy_ConsumptionListItem(Daily_Energy_ConsumptionDesigner owner)
            : base(owner.Component)
        {
            _Daily_Energy_Consumption = (Daily_Energy_Consumption)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionPropertyItem("BorderStyle", "BorderStyle"));
            items.Add(new DesignerActionPropertyItem("Font", "Font"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public BorderStyle BorderStyle
        {
            get { return _Daily_Energy_Consumption.BorderStyle; }
            set { _Daily_Energy_Consumption.BorderStyle = value; }
        }

        public Font Font
        {
            get { return _Daily_Energy_Consumption.Font; }
            set { _Daily_Energy_Consumption.Font = value; }
        }

        public string TagName
        {
            get { return _Daily_Energy_Consumption.TagName; }
            set
            {
                _Daily_Energy_Consumption.TagName = value;
                _Daily_Energy_Consumption.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_Daily_Energy_Consumption, "TagName", tagName);
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
