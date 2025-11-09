using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Driver_Tool;
using System.Data.SqlClient;
using ZedGraph;

namespace HMI_Trend
{
    public partial class Trend_Historical: UserControl
    {
        public Trend_Historical()
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
        }

        private void Historical_Trend_Load(object sender, EventArgs e)
        {
            try
            {
                cbxLineColor.DrawItem += new DrawItemEventHandler(cbxLineColor_DrawItem);

                Type colorType = typeof(System.Drawing.Color);
                PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
                foreach (PropertyInfo c in propInfoList)
                {
                    cbxLineColor.Items.Add(c.Name);
                    cbxLineColor.Text = c.Name;
                }
            }
            catch
            {

            }
        }

        private void cbxLineColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Rectangle rect = e.Bounds;
                if (e.Index >= 0)
                {
                    string n = ((ComboBox)sender).Items[e.Index].ToString();
                    Font f = new Font("Arial", 9, FontStyle.Regular);
                    Color c = Color.FromName(n);
                    Brush b = new SolidBrush(c);
                    g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                    g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
                }
            }
            catch
            {

            }
        }

        string strcon = @"Data Source=.\sqlexpress;Initial Catalog = DATAWRITE; Integrated Security = True";
        protected DateTime myFrom;
        protected DateTime myTo;
        protected SqlConnection _conn = new SqlConnection();
        protected string _conn_str;
        protected SqlDataAdapter _adp = new SqlDataAdapter();
        protected DataSet _ds;
        protected Timer timer1 = new Timer();
        //DataTable table;
        protected string _GridLine = "No";
        protected Color _PanelColor = Color.Transparent;
        protected System.Windows.Forms.Timer _SysTimer;

        public DateTime FromDate
        {
            get { return myFrom; }
            set { myFrom = value; }
        }

        public DateTime ToDate
        {
            get { return myTo; }
            set { myTo = value; }
        }

        public Color PanelColor
        {
            get { return _PanelColor; }
            set
            {
                _PanelColor = value;
                zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, _PanelColor, -45F);
            }
        }

        public string GridLine
        {
            get { return _GridLine; }
            set
            {
                _GridLine = value;
                if (_GridLine == "Yes")
                {
                    zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
                    zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
                }
                else
                {
                    zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = false;
                    zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = false;
                }
            }
        }
        private void Query()
        {
            try
            {

                _conn = new SqlConnection(strcon);
                _conn.Open();

                _ds = new DataSet();
                //connect to table

                _conn_str = "SELECT * FROM DataD WHERE Datetime >= '" + myFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Datetime <= '" + myTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ";


                _adp.SelectCommand = new SqlCommand(_conn_str, _conn);
                _adp.Fill(_ds, "DataD");

                _conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public XDate ConvertDateToXdate(DateTime date)
        {
            return new XDate(date.ToOADate());
        }

        GraphPane myPane = new GraphPane();
        PointPairList giatri = new PointPairList();
        PointPairList[] listpoin;
        LineItem[] listline;


        //int _TryCount = 0;
        private void setting()
        {
            //Get Tag list



            GraphPane myPane = zedGraphControl1.GraphPane;
            // Set the titles and axis labels
            myPane.XAxis.Type = AxisType.Date;
            myPane.Title.Text = "Historical Trend";
            myPane.XAxis.Title.Text = "Datetime";
            myPane.YAxis.Title.Text = "Value";
            myPane.XAxis.Scale.Format = "yyyy-MM-dd \n HH:mm:ss";
            while (myPane.CurveList.Count > 0)
                myPane.CurveList.RemoveAt(myPane.CurveList.Count - 1);

            listline = new LineItem[lsvSelected.Items.Count];
            listpoin = new PointPairList[lsvSelected.Items.Count];
            for (int i = 0; i < lsvSelected.Items.Count; i++)
            {
                listpoin[i] = new PointPairList();
                listline[i] = myPane.AddCurve(lsvSelected.Items[i].SubItems[0].Text, listpoin[i], Color.FromName(lsvSelected.Items[i].SubItems[1].Text), SymbolType.Circle);
                listline[i].Line.Width = int.Parse(lsvSelected.Items[i].SubItems[2].Text);
            }

            CreateGraphControl();
            //this.timer1.Interval = 1000;
            //timer1.Start();
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);


        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            //CreateGraphControl();
        }

        private void CreateGraphControl()
        {
            try
            {



                zedGraphControl1.Invalidate();
                zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, _PanelColor, -45F);
                if (_GridLine == "Yes")
                {
                    zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
                    zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
                }
                else
                {
                    zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = false;
                    zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = false;
                }
                CreateGraph();
                //   SetSize();
                zedGraphControl1.BringToFront();
                zedGraphControl1.Refresh();
            }
            catch { }
        }
        PointPairList list = new PointPairList();
        private DataTable _table;
        private void CreateGraph()
        {
            try
            {
                TimeSpan t1 = new TimeSpan(dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute, dateTimePicker3.Value.Second);
                myFrom = dateTimePicker1.Value.Date + t1;
                TimeSpan t2 = new TimeSpan(dateTimePicker4.Value.Hour, dateTimePicker4.Value.Minute, dateTimePicker4.Value.Second);
                myTo = dateTimePicker2.Value.Date + t2;

                //Get value for each HistoricalTimeStampList
                Query();
                _table = new DataTable();
                _table = _ds.Tables["DataD"];


                //   FireChanging();
                GraphPane myPane = zedGraphControl1.GraphPane;

                myPane.XAxis.Scale.Min = ConvertDateToXdate(myFrom);
                myPane.XAxis.Scale.Max = ConvertDateToXdate(myTo);
                myPane.YAxis.Scale.Min = -10;
                myPane.YAxis.Scale.Max = 1000;
                double x, y;
                //x = ConvertDateToXdate(DateTime.Now);
                //y = 1;
                //list.Add(new PointPair(x, y));

                for (int i = 0; i < lsvSelected.Items.Count; i++)
                {

                    for (int j = 0; j < _table.Rows.Count; j++)
                    {

                        DataRow r = _table.Rows[j];

                        if (lsvSelected.Items[i].SubItems[0].Text == Convert.ToString(r["TagName"]))
                        {

                            x = ConvertDateToXdate(Convert.ToDateTime(r["Datetime"]));
                            y = Convert.ToDouble(r["Value"]);
                            listpoin[i].Add(x, y);


                        }
                    }



                    myPane.AxisChange();
                    zedGraphControl1.Refresh();
                }

                //myPane.AxisChange();
                //zedGraphControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(TagName, "Text", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }

        private void TagName_DoubleClick(object sender, EventArgs e)
        {
            ShowTagListForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = TagName.Text.ToString();
            int vt = data.LastIndexOf("/");

            string tenTagName = data.Substring(0, vt);
            foreach (ListViewItem li in lsvSelected.Items)
            {
                if (li.SubItems[0].Text == tenTagName)
                {
                    li.SubItems[1].Text = cbxLineColor.Text;
                    li.SubItems[2].Text = cbxWidth.Text;

                    return;
                }
            }

            string[] s = new string[4];
            s[0] = tenTagName;
            s[1] = cbxLineColor.Text;
            s[2] = cbxWidth.Text;

            lsvSelected.Items.Add(new ListViewItem(s));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSelected.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in lsvSelected.SelectedItems)
                        lsvSelected.Items.Remove(li);
                }
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setting();
        }

        private void lsvSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSelected.SelectedItems.Count > 0)
            {
                TagName.Text = lsvSelected.SelectedItems[0].SubItems[0].Text;
                cbxLineColor.Text = lsvSelected.SelectedItems[0].SubItems[1].Text;
                cbxWidth.Text = lsvSelected.SelectedItems[0].SubItems[2].Text;
            }
        }
    }
}
