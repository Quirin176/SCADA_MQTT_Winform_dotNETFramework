using Devices;
using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Led
{
    [Designer(typeof(HMIDisplayDesigner))]

    public partial class Led : UserControl
    {
        private Timer timerLicence = new Timer();
        private string _TagName;
        private bool _value = false;
        private LightColors color_ON = LightColors.Green;
        private LightColors color_OFF = LightColors.Grey;
        private Bitmap image;
        private Bitmap ledcoloron = Properties.Resources.Light_green;
        private Bitmap ledcoloroff = Properties.Resources.Light_off;
        private SolidBrush TextBrush;
        private StringFormat sfCenter;
        private RectangleF TextRectangle;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (!(value != base.ForeColor))
                    return;
                base.ForeColor = value;
                if (this.TextBrush == null)
                    this.TextBrush = new SolidBrush(base.ForeColor);
                else
                    this.TextBrush.Color = value;
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                //   this.RefreshImage();
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                //this.RefreshImage();
                this.Invalidate();
            }
        }

        public enum LightColors
        {
            Red, Blue, Darkgreen, Grey, Green, Navy, White, Yellow,
        }

        public LightColors Color_ON
        {
            get
            {
                return this.color_ON;
            }
            set
            {
                this.color_ON = value;
                switch (this.Color_ON)
                {
                    case LightColors.Red:
                        this.ledcoloron = Properties.Resources.Light_red; break;
                    case LightColors.Blue:
                        this.ledcoloron = Properties.Resources.Light_blue; break;
                    case LightColors.Darkgreen:
                        this.ledcoloron = Properties.Resources.Light_dark_green; break;
                    case LightColors.Grey:
                        this.ledcoloron = Properties.Resources.Light_off; break;
                    case LightColors.Green:
                        this.ledcoloron = Properties.Resources.Light_green; break;
                    case LightColors.Navy:
                        this.ledcoloron = Properties.Resources.Light_navy; break;
                    case LightColors.White:
                        this.ledcoloron = Properties.Resources.Light_white; break;
                    case LightColors.Yellow:
                        this.ledcoloron = Properties.Resources.Light_yellow; break;

                }
                Invalidate();
                // this.RefreshImage();
            }
        }

        public LightColors Color_OFF
        {
            get { return this.color_OFF; }
            set
            {
                this.color_OFF = value;
                switch (this.Color_OFF)
                {
                    case LightColors.Red:
                        this.ledcoloroff = Properties.Resources.Light_red; break;
                    case LightColors.Blue:
                        this.ledcoloroff = Properties.Resources.Light_blue; break;
                    case LightColors.Darkgreen:
                        this.ledcoloroff = Properties.Resources.Light_dark_green; break;
                    case LightColors.Grey:
                        this.ledcoloroff = Properties.Resources.Light_off; break;
                    case LightColors.Green:
                        this.ledcoloroff = Properties.Resources.Light_green; break;
                    case LightColors.Navy:
                        this.ledcoloroff = Properties.Resources.Light_navy; break;
                    case LightColors.White:
                        this.ledcoloroff = Properties.Resources.Light_white; break;
                    case LightColors.Yellow:
                        this.ledcoloroff = Properties.Resources.Light_yellow; break;

                }
                //this.RefreshImage();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //  Graphics g = Graphics.FromHwnd(Handle);
            Bitmap image1 = Properties.Resources.Light_off;
            if (this._value == false) this.image = this.ledcoloroff; else this.image = this.ledcoloron;
            e.Graphics.DrawImage(this.image, 0, 0, this.Width, this.Height);
            this.TextBrush = new SolidBrush(base.ForeColor);
            this.TextRectangle = new RectangleF();
            this.TextRectangle.X = (float)(0.1 * this.Width);
            this.TextRectangle.Y = (float)(0.3 * this.Height);
            this.TextRectangle.Width = (float)(0.8 * this.Width);
            this.TextRectangle.Height = (float)(0.4 * this.Height);
            this.sfCenter = new StringFormat();
            this.sfCenter.Alignment = StringAlignment.Center;
            this.sfCenter.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(base.Text, base.Font, (Brush)this.TextBrush, this.TextRectangle, this.sfCenter);
        }

        private void RefreshImage()
        {
            Graphics g = Graphics.FromHwnd(Handle);
            Bitmap image1 = Properties.Resources.Light_off;
            if (this._value == false) this.image = this.ledcoloroff; else this.image = this.ledcoloron;
            g.DrawImage(this.image, 0, 0, this.Width, this.Height);
            this.TextBrush = new SolidBrush(base.ForeColor);
            this.TextRectangle = new RectangleF();
            this.TextRectangle.X = (float)(0.1 * this.Width);
            this.TextRectangle.Y = (float)(0.3 * this.Height);
            this.TextRectangle.Width = (float)(0.8 * this.Width);
            this.TextRectangle.Height = (float)(0.4 * this.Height);
            this.sfCenter = new StringFormat();
            this.sfCenter.Alignment = StringAlignment.Center;
            this.sfCenter.LineAlignment = StringAlignment.Center;
            g.DrawString(base.Text, base.Font, (Brush)this.TextBrush, this.TextRectangle, this.sfCenter);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            // this.RefreshImage();
            //   base.OnTextChanged();
        }

        public bool Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    this._value = value;
                    //   this.RefreshImage();
                    this.Invalidate();
                }
            }
        }

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
        public Led()
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

            InitializeComponent();

            this.Width = 50;
            this.Height = 50;
            this.Value = false;
            this.Color_OFF = LightColors.Grey;
            this.Color_ON = LightColors.Green;
            this.ledcoloron = Properties.Resources.Light_green;
            this.ledcoloroff = Properties.Resources.Light_off;
            this.TextRectangle = new Rectangle();
            this.sfCenter = new StringFormat();
            this.RefreshImage();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
    public class HMIDisplayDesigner : System.Windows.Forms.Design.ControlDesigner // form create 1 form bên ngoài
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIDisplayListItem(this));
                }
                return actionLists;
            }
        }
    }
    public class HMIDisplayListItem : DesignerActionList// tạo các compoment trong form bên ngoài
    {
        private Led _led;
        public HMIDisplayListItem(HMIDisplayDesigner owner)
            : base(owner.Component)
        {
            _led = (Led)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("Value", "Value"));
            items.Add(new DesignerActionPropertyItem("Color_ON", "Color_ON"));
            items.Add(new DesignerActionPropertyItem("Color_OFF", "Color_OFF"));
            items.Add(new DesignerActionPropertyItem("Text", "Text"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            return items;
        }


        public bool Value
        {
            get { return _led.Value; }
            set { _led.Value = value; }
        }
        public Led.LightColors Color_ON
        {
            get { return _led.Color_ON; }
            set { _led.Color_ON = value; }
        }
        public Led.LightColors Color_OFF
        {
            get { return _led.Color_OFF; }
            set { _led.Color_OFF = value; }
        }
        public string Text
        {
            get { return _led.Text; }
            set { _led.Text = value; }
        }
        public string TagName
        {
            get { return _led.TagName; }
            set
            {
                _led.TagName = value;
                _led.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                //SetProperty(_led, "TagName", tagName);
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
