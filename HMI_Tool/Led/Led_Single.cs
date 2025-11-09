using HMI_Tool.Motor;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Led
{
    [Designer(typeof(HMIDisplayDesigner1))]
    public partial class Led_Single : UserControl
    {
        private Timer timerLicence = new Timer();
        private string _TagName;
        private Color coloron = Color.LimeGreen;
        private bool _isblink = false;
        private StringFormat sf = null;
        private Timer timer = new Timer();
        private Color _color = Color.Gray;
        private bool _value = false;
        private bool alarmStatus = false;

        [Browsable(true), Category("Misc")]
        public string TagName
        {
            get { return _TagName; }
            set
            {
                FireChanged();
                try
                {
                    _TagName = value;
                    if (string.IsNullOrEmpty(_TagName) || string.IsNullOrWhiteSpace(_TagName) || MQTT_TagCollection.Tags.Count == 0) return;
                    Binding bd = new Binding("Value", MQTT_TagCollection.Tags[_TagName], "Value", true);
                    if (this.DataBindings.Count > 0) this.DataBindings.Clear();
                    this.DataBindings.Add(bd);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(string.Format("TagName is invalid: {0}", _TagName));
                }
                finally { FireChanged(); }
            }
        }
        void FireChanging()
        {
            IComponentChangeService service = GetComponentChangeService();
            if (service != null)
                service.OnComponentChanging(this, null);
        }
        void FireChanged()
        {
            IComponentChangeService service = GetComponentChangeService();
            if (service != null)
                service.OnComponentChanged(this, null, null, null);
        }
        IComponentChangeService GetComponentChangeService()
        {
            return GetService(typeof(IComponentChangeService)) as IComponentChangeService;
        }
        private void ShowLiInfo(object o, EventArgs e)
        {
            this.timerLicence.Enabled = false;
            if (this.DataBindings.Count > 0)
            {
                this.DataBindings.Clear();
                this.Text = "Trial";

            }
        }

        [Browsable(true), Category("Misc"), Description("Led chớp theo chu kỳ 0.5s"), EditorBrowsable(EditorBrowsableState.Always)]
        public bool Isblink
        {
            get { return _isblink; }
            set
            {
                if (_isblink != value)
                {
                    _isblink = value;
                    if (value == true)
                    {
                        timer.Start();
                    }
                    else
                    {
                        timer.Stop();
                        refresh();
                    }
                }
            }
        }

        [Browsable(true), Category("Misc"), DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(true), Category("Misc"), Description("Colorligh"), EditorBrowsable(EditorBrowsableState.Always)]
        public Color Colorligh
        {
            get { return coloron; }
            set
            {
                if (coloron != value)
                {
                    coloron = value;

                    refresh();
                }
            }
        }

        [Browsable(true), Category("Misc"), Description("Value"), EditorBrowsable(EditorBrowsableState.Always)]
        public bool Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    refresh();
                }
            }
        }

        [Browsable(true), Category("Misc"), Description("Text of led"), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                base.Invalidate();
            }
        }

        public Led_Single()
        {
            this.timerLicence.Tick += new EventHandler(this.ShowLiInfo);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                this.timerLicence.Interval = 0xA4CB80;
            }
            else
            {
                this.timerLicence.Interval = 0x36EE80;
                //this.timerLicence.Interval = 9000;
            }

            InitializeComponent1();

            this.sf = new StringFormat();
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.timer.Interval = 500;
            this.timer.Tick += new EventHandler(this.Timer_Tick);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            bool flag = this.Isblink;
            if (flag)
            {
                bool flag2 = this.alarmStatus;
                if (flag2)
                {
                    _color = this.Colorligh;
                }
                else
                {
                    _color = Color.Gray;
                }
                this.alarmStatus = !this.alarmStatus;
            }
            else
            {
                _color = this.Value ? this.Colorligh : Color.Gray;


            }
            Invalidate();
        }

        private void refresh()
        {
            _color = this.Value ? coloron : Color.Gray;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            int num = Math.Min(base.Width, base.Height);
            num--;
            Point point = new Point(num / 2, num / 2);
            e.Graphics.TranslateTransform((float)point.X, (float)point.Y);
            float num2 = (float)(point.X * 17) / 20f;
            float num3 = (float)point.X / 20f;
            bool flag2 = num2 < 2f;
            if (!flag2)
            {
                RectangleF rect = new RectangleF(-num2 - 2f * num3, -num2 - 2f * num3, 2f * num2 + 4f * num3, 2f * num2 + 4f * num3);
                RectangleF rect2 = new RectangleF(-num2, -num2, 2f * num2, 2f * num2);
                using (Pen pen = new Pen(this.ForeColor, num3))
                {
                    e.Graphics.DrawEllipse(pen, rect);
                }


                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddEllipse(-num2, -num2, 2f * num2, 2f * num2);
                PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                pathGradientBrush.CenterPoint = new Point(0, 0);
                pathGradientBrush.InterpolationColors = new ColorBlend
                {
                    Positions = new float[]
                    {
                                0f,
                                1f
                    },
                    Colors = new Color[]
                    {
                                this._color,
                                Color.WhiteSmoke
                    }
                };
                e.Graphics.FillEllipse(pathGradientBrush, rect2);
                using (Pen pen2 = new Pen(this.ForeColor))
                {
                    e.Graphics.DrawEllipse(pen2, -num2, -num2, 2f * num2, 2f * num2);
                }
                pathGradientBrush.Dispose();
                graphicsPath.Dispose();

                e.Graphics.ResetTransform();
                bool flag4 = base.Height - num > 0;
                if (flag4)
                {
                    bool flag5 = !string.IsNullOrEmpty(this.Text);
                    if (flag5)
                    {
                        using (Brush brush = new SolidBrush(this.ForeColor))
                        {
                            SizeF sizestring = e.Graphics.MeasureString(this.Text, this.Font);
                            PointF poinstring = new PointF((float)(num - sizestring.Width) / 2, (float)(num - sizestring.Height) / 2);
                            e.Graphics.DrawString(this.Text, this.Font, brush, poinstring);
                        }
                    }
                }
                base.OnPaint(e);
            }
        }
        private void InitializeComponent1()
        {
            base.SuspendLayout();
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Transparent;
            base.Name = "HslLanternSimple";
            base.Size = new Size(80, 80);
            base.ResumeLayout(false);
        }
    }
    public class HMIDisplayDesigner1 : System.Windows.Forms.Design.ControlDesigner // form create 1 form bên ngoài
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
    public class HMIDisplayListItem1 : DesignerActionList// tạo các compoment trong form bên ngoài
    {
        private Led_Single colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner1 owner)
            : base(owner.Component)
        {
            colUserControl = (Led_Single)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI property", "HMI Property"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Colorligh", "Colorligh"));
            items.Add(new DesignerActionPropertyItem("Text", "Text"));
            items.Add(new DesignerActionPropertyItem("Value", "Value"));
            items.Add(new DesignerActionPropertyItem("IsBlink", "IsBlink"));

            return items;

        }
        public string Text
        {
            get { return colUserControl.Text; }
            set { colUserControl.Text = value; }

        }
        public Color Colorligh
        {
            get { return colUserControl.Colorligh; }
            set { colUserControl.Colorligh = value; }
        }

        public bool Value
        {
            get { return colUserControl.Value; }
            set { colUserControl.Value = value; }
        }
        public bool IsBlink
        {
            get { return colUserControl.Isblink; }
            set { colUserControl.Isblink = value; }
        }
        public string TagName
        {
            get { return colUserControl.TagName; }
            set
            {
                colUserControl.TagName = value;
                colUserControl.Invalidate();
            }
        }
        private void ShowTagListForm()
        {
            //TagListForm frm = new TagListForm(this.TagName);
            //frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            //{
                //SetProperty(colUserControl, "TagName", tagName);
            //});
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowDialog();
        }


        public void SetProperty(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
