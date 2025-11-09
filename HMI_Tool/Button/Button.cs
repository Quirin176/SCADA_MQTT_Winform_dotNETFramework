using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Button
{
    [Designer(typeof(HMIDisplayDesigner2))]
    public partial class Button : UserControl
    {
        public enum ButtonStyle
        {
            Circular = 0,
            Rectangular = 1,
            Elliptical = 2,
        }

        public enum ButtonState
        {
            Normal = 0,
            Pressed,
        }

        private float drawRatio = 1.0F;
        private ButtonStyle buttonStyle = ButtonStyle.Rectangular;
        private Color buttonColor = Color.DeepSkyBlue;
        private Rectangle rectCtrl;
        private Rectangle rectBody;
        private Rectangle rectText;
        private string label = "Text";
        private bool _value;

        public Button()
        {
            InitializeComponent();

            this.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            this.ForeColor = Color.White;
            this.Size = new Size(100, 50);
            this.buttonColor = Color.DeepSkyBlue;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.DoubleBuffer |
              ControlStyles.SupportsTransparentBackColor,
              true);
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

        public bool Value
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

        [Category("Misc")]
        public ButtonStyle Style
        {
            set
            {
                this.buttonStyle = value;
            }
            get { return this.buttonStyle; }
        }

        [Category("Misc")]
        public Color ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                Invalidate();
            }
        }

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

        public void _Update()
        {
            this.rectCtrl.X = 0;
            this.rectCtrl.Y = 0;
            this.rectCtrl.Width = this.Width;
            this.rectCtrl.Height = this.Height;

            if (this.Style == ButtonStyle.Circular)
            {
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
            }

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
            Color bodyColor = this.ButtonColor;
            Color cDark = ManagerColor.StepColor(bodyColor, 20);

            LinearGradientBrush br1 = new LinearGradientBrush(rc, bodyColor, cDark, 90);

            if ((this.Style == ButtonStyle.Circular) ||
                (this.Style == ButtonStyle.Elliptical))
            {
                Gr.FillEllipse(br1, rc);
            }
            else
            {
                GraphicsPath path = this.RoundedRect(rc, 18F);
                Gr.FillPath(br1, path);
                path.Dispose();
            }

            if (_value == true)
            {
                RectangleF _rc = rc;
                _rc.Inflate(- drawRatio, - drawRatio);
                LinearGradientBrush br2 = new LinearGradientBrush(_rc, cDark, bodyColor, 90);
                if ((this.Style == ButtonStyle.Circular) ||
                    (this.Style == ButtonStyle.Elliptical))
                {
                    Gr.FillEllipse(br2, _rc);
                }
                else
                {
                    GraphicsPath path = this.RoundedRect(_rc, 10F);
                    Gr.FillPath(br2, path);
                    path.Dispose();
                }
                br2.Dispose();
            }
            br1.Dispose();
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

        protected GraphicsPath RoundedRect(RectangleF rect, float radius)
        {
            RectangleF baseRect = rect;
            float diameter = (radius * this.drawRatio) * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc
            path.AddArc(arc, 180, 90);
            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right  arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _Update();
            Draw(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Value = true;
            MQTT_Service.PublishToTopic(MQTT_TagCollection.Tags[TagName].Topic, Value);
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Value = false;
            MQTT_Service.PublishToTopic(MQTT_TagCollection.Tags[TagName].Topic, Value);
            base.OnMouseUp(e);
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
        private Button colUserControl;

        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (Button)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
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
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(colUserControl, "TagName", tagName);
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
