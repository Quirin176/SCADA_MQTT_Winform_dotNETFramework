using Driver_Tool;
using HMI_Edition.HMIDisplay;
using HMI_Tool.Faceplate;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Light
{
    [Designer(typeof(HMIDisplayDesigner2))]
    public partial class Light : UserControl
    {
        private float drawRatio = 1.0F;
        private Color _ColorOFF = Color.MediumBlue;
        private Color _ColorON = Color.Gold;

        private Rectangle rectCtrl;
        private Rectangle rectBody;
        private Rectangle rectText;
        private string label = "";
        private string _value = "false";

        //private string _Data;
        //private bool _state;

        public Light()
        {
            InitializeComponent();

            this.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            this.ForeColor = Color.White;
            this.Size = new Size(20, 20);
            this.Privilege = 1;
            this.UserPrivilege = 1;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.DoubleBuffer |
              ControlStyles.SupportsTransparentBackColor, true);
        }
        
        [Category("Misc")]
        private string _TagName;
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

        [Category("Misc")]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    Invalidate();
                    
                }
            }
        }

        // Color
        [Category("Misc")]
        public Color ColorON
        {
            get { return _ColorON; }
            set
            {
                _ColorON = value;
                Invalidate();
            }
        }

        [Category("Misc")]
        public Color ColorOFF
        {
            get { return _ColorOFF; }
            set
            {
                _ColorOFF = value;
                Invalidate();
            }
        }

        // Label
        [Category("Misc")]
        public string Label
        {
            get { return this.label; }
            set
            {
                this.label = value;
                Invalidate();
            }
        }

        // Faceplate
        private bool _faceplate;
        [Category("MyFaceplate")]
        public bool Faceplate
        {
            get { return _faceplate; }
            set
            {
                if (_faceplate != value)
                {
                    _faceplate = value;
                    Invalidate();
                }
            }
        }

        private string _lightName;
        [Category("MyFaceplate")]
        public string LightName
        {
            get { return _lightName; }
            set
            {
                if (_lightName != value)
                {
                    _lightName = value;
                    Invalidate();
                }
            }
        }

        private string _swTopic;
        [Category("MyFaceplate")]
        public string SWTopic
        {
            get { return _swTopic; }
            set
            {
                if (_swTopic != value)
                {
                    _swTopic = value;
                    Invalidate();
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

        //private void UpdateValueFromData()
        //{
        //    if (string.IsNullOrEmpty(_value))
        //    {
        //        State = false;
        //        return;
        //    }

        //    try
        //    {
        //        if (_value.TrimStart().StartsWith("{"))
        //        {
        //            //State = ExtractBooleanFromJson(_value, _Data);
        //            State = false;
        //        }
        //        else
        //        {
        //            State = bool.Parse(_value);
        //        }
        //    }
        //    catch
        //    {
        //        State = false;
        //    }
        //}

        //private bool ExtractBooleanFromJson(string jsonString, string key)
        //{
        //    try
        //    {
        //        using (JsonDocument doc = JsonDocument.Parse(jsonString))
        //        {
        //            if (doc.RootElement.TryGetProperty(key, out var element) && element.ValueKind == JsonValueKind.True)
        //            {
        //                return element.GetBoolean();
        //            }
        //        }
        //    }
        //    catch (JsonException ex)
        //    {
        //        Debug.WriteLine($"JSON Parsing error: {ex.Message}");
        //    }
        //    return false;
        //}

        // Draw
        private void Draw(Graphics Gr)
        {
            this._Update();
            this.DrawBackground(Gr, this.rectCtrl);
            this.DrawBody(Gr, this.rectBody);
            this.DrawText(Gr, this.rectText);
        }

        private void DrawBackground(Graphics Gr, RectangleF rc)
        {
            Color c = this.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Width, this.Height);
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _Update();
            Draw(e.Graphics);
            base.OnPaint(e);
        }

        public void _Update()
        {
            this.rectCtrl.X = 0;
            this.rectCtrl.Y = 0;
            this.rectCtrl.Width = this.Width;
            this.rectCtrl.Height = this.Height;

            if (ClientRectangle.Width < 10) this.Width = 10;
            if (ClientRectangle.Height < 10) this.Height = 10;
            if (rectCtrl.Width < rectCtrl.Height)
                rectCtrl.Height = rectCtrl.Width;
            else if (rectCtrl.Width > rectCtrl.Height)
                rectCtrl.Width = rectCtrl.Height;

            if (rectCtrl.Width < 10)
                rectCtrl.Width = 10;
            if (rectCtrl.Height < 10)
                rectCtrl.Height = 10;

            this.rectBody = this.rectCtrl;
            this.rectBody.Width -= 1;
            this.rectBody.Height -= 1;

            this.rectText = this.rectCtrl;
            this.rectText.Width -= 2;
            this.rectText.Height -= 2;

            drawRatio = (Math.Min(this.rectCtrl.Width, rectCtrl.Height)) / 250;
            if (drawRatio == 0.0f)
                drawRatio = 1f;
        }

        private void DrawBody(Graphics Gr, RectangleF rc)
        {
            try
            {
                if (_value == null || _value.Trim().ToLower() == "" || _value.Trim().ToLower() == "0"|| _value.Trim().ToLower() == "false")
                {
                    Color bodyColor = ColorOFF;
                    LinearGradientBrush br1 = new LinearGradientBrush(rc, bodyColor, bodyColor, 90);
                    Gr.FillEllipse(br1, rc);
                }
                else
                {
                    Color bodyColor = ColorON;
                    RectangleF _rc = rc;
                    _rc.Inflate(-drawRatio, -drawRatio);
                    LinearGradientBrush br2 = new LinearGradientBrush(_rc, bodyColor, bodyColor, 90);
                    Gr.FillEllipse(br2, _rc);
                    br2.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DrawText(Graphics Gr, RectangleF rc)
        {

            Font font = new Font(this.Font.FontFamily,
                                   this.Font.Size * this.drawRatio,
                                   this.Font.Style);

            String str = this.Label;

            Color bodyColor = this.ForeColor;

            SizeF size = Gr.MeasureString(str, font);

            SolidBrush br1 = new SolidBrush(bodyColor);
            SolidBrush br2 = new SolidBrush(bodyColor);

            Gr.DrawString(str, font, br1,
                            rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)) + (float)(1 * this.drawRatio),
                            rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5)) + (float)(1 * this.drawRatio));

            Gr.DrawString(str, font, br2,
                            rc.Left + ((rc.Width * 0.5F) - (float)(size.Width * 0.5F)),
                            rc.Top + ((rc.Height * 0.5F) - (float)(size.Height * 0.5)));

            br1.Dispose();
            br2.Dispose();
            font.Dispose();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //if (!_faceplate)
                //return;
            if (string.IsNullOrEmpty(_swTopic) || string.IsNullOrWhiteSpace(_swTopic))
                return;
            if (string.IsNullOrEmpty(_lightName) || string.IsNullOrWhiteSpace(_lightName))
            {
                _lightName = "Empty";
            }

            Light_Faceplate fpl = new Light_Faceplate(LightName, TagName, SWTopic);
            fpl.ShowDialog();

            base.OnMouseDoubleClick(e);
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
        private Light colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (Light)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("Label", "Label"));
            items.Add(new DesignerActionPropertyItem("ColorON", "ColorON"));
            items.Add(new DesignerActionPropertyItem("ColorOFF", "ColorOFF"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm1", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Data", "Data"));

            items.Add(new DesignerActionPropertyItem("Faceplate", "Faceplate"));
            items.Add(new DesignerActionPropertyItem("LightName", "LightName"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm2", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("SWTopic", "SWTopic"));
            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));

            return items;
        }

        public string Label
        {
            get { return colUserControl.Label; }
            set
            {
                colUserControl.Label = value;
                colUserControl.Invalidate();
            }
        }

        public Color ColorON
        {
            get { return colUserControl.ColorON; }
            set { colUserControl.ColorON = value; }
        }

        public Color ColorOFF
        {
            get { return colUserControl.ColorOFF; }
            set { colUserControl.ColorOFF = value; }
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

        //public string Data
        //{
        //    get { return colUserControl.Data; }
        //    set
        //    {
        //        colUserControl.Data = value;
        //        colUserControl.Invalidate();
        //    }
        //}

        public bool Faceplate
        {
            get { return colUserControl.Faceplate; }
            set { colUserControl.Faceplate = value; }
        }

        public string LightName
        {
            get { return colUserControl.LightName; }
            set
            {
                colUserControl.LightName = value;
                colUserControl.Invalidate();
            }
        }

        public string SWTopic
        {
            get { return colUserControl.SWTopic; }
            set
            {
                colUserControl.SWTopic = value;
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

        private void ShowTagListForm1()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(colUserControl, "TagName", tagName);
            });

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void ShowTagListForm2()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((swTopic) =>
            {
                SetProperty(colUserControl, "SWTopic", swTopic);
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
