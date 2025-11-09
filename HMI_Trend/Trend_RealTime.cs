using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace HMI_Trend
{
    public partial class Trend_RealTime : UserControl
    {
        protected Timer timer1 = new Timer();

        private DateTime startTime;
        private Dictionary<string, LineItem> tagLines = new Dictionary<string, LineItem>();
        PointPairList[] listpoint;
        LineItem[] listline;
        private readonly object lockObject = new object();

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

        public Trend_RealTime()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, Color.Transparent, -45F);
            zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void Trend_RealTime_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Realtime Trend";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "dd MMM yyyy \n hh:mm:ss";
            myPane.XAxis.Title.Text = "Date - Time";
            myPane.YAxis.Title.Text = "Value";

            cbx_Color.DrawItem += new DrawItemEventHandler(combo_Color_DrawItem);
            Type colorType = typeof(Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                cbx_Color.Items.Add(c.Name);
                cbx_Color.Text = c.Name;
            }
        }

        private void combo_Color_DrawItem(object sender, DrawItemEventArgs e)
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

        private void TagName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTagListForm();
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(txt_TagName, "Text", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }

        private void btn_AddUpdate_Click(object sender, EventArgs e)
        {
            lock (lockObject)
            {
                foreach (ListViewItem li in listView1.Items)
                {
                    if (li.SubItems[0].Text == txt_TagName.Text)
                    {
                        li.SubItems[1].Text = MQTT_TagCollection.Tags[li.SubItems[1].Text].Topic;
                        li.SubItems[2].Text = cbx_Color.Text;
                        li.SubItems[3].Text = cbx_Width.Text;
                        UpdateLineItems();

                        return;
                    }
                }

            }

            string[] s = new string[4];
            s[0] = txt_TagName.Text;
            s[1] = MQTT_TagCollection.Tags[txt_TagName.Text].Topic;
            s[2] = cbx_Color.Text;
            s[3] = cbx_Width.Text;

            listView1.Items.Add(new ListViewItem(s));
            UpdateLineItems();

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                lock (lockObject)
                {
                    foreach (ListViewItem li in listView1.SelectedItems)
                        listView1.Items.Remove(li);
                    UpdateLineItems();
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            startTime = DateTime.Now;
            ClearAllData();
            timer1.Start();
        }

        private void ClearAllData()
        {
            lock (lockObject)
            {
                if (listpoint != null)
                {
                    foreach (var points in listpoint)
                    {
                        points.Clear();
                    }
                }

                zedGraphControl1.GraphPane.CurveList.Clear();

                UpdateLineItems();

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_TagName.Text = listView1.SelectedItems[0].SubItems[0].Text;
                cbx_Color.Text = listView1.SelectedItems[0].SubItems[2].Text;
                cbx_Width.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void UpdateLineItems()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            listline = new LineItem[listView1.Items.Count];
            listpoint = new PointPairList[listView1.Items.Count];

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listpoint[i] = new PointPairList();
                listline[i] = myPane.AddCurve(listView1.Items[i].SubItems[0].Text, listpoint[i],
                    Color.FromName(listView1.Items[i].SubItems[2].Text), SymbolType.None);
                listline[i].Line.Width = int.Parse(listView1.Items[i].SubItems[3].Text);
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void UpdateGraph()
        {
            lock (lockObject)
            {
                GraphPane pane = zedGraphControl1.GraphPane;

                pane.XAxis.Scale.Min = ConvertDateToXdate(startTime);
                pane.XAxis.Scale.Max = ConvertDateToXdate(DateTime.Now);
                pane.YAxis.Scale.MinAuto = true;
                pane.YAxis.Scale.MaxAuto = true;

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (MQTT_TagCollection.Tags.ContainsKey(listView1.Items[i].SubItems[0].Text))
                    {
                        double tagValue = Convert.ToDouble(MQTT_TagCollection.Tags[listView1.Items[i].SubItems[0].Text].Value);
                        listpoint[i].Add(ConvertDateToXdate(DateTime.Now), tagValue);
                    }
                    else
                    {
                        MessageBox.Show($"Tag '{listView1.Items[i].SubItems[0].Text}' not found in tag collection.");
                    }
                }

                pane.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
            }
        }

        private XDate ConvertDateToXdate(DateTime date)
        {
            return new XDate(date.ToOADate());
        }
    }
}
