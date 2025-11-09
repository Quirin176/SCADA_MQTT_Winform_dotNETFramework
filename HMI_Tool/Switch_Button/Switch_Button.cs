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

namespace HMI_Tool.Switch_Button
{
    [Designer(typeof(myControl))]
    public partial class Switch_Button : UserControl
    {
        public Switch_Button()
        {
            InitializeComponent();
        }

        private string _TagName;
        private bool _Value;

        private Color onBackColor = Color.LimeGreen;
        private Color offBackColor = Color.LightCoral;
        private Color onForeColor = Color.WhiteSmoke;
        private Color offForeColor = Color.WhiteSmoke;

        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                Invalidate();
            }
        }

        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                Invalidate();
            }
        }

        public Color OnForeColor
        {
            get { return onForeColor; }
            set
            {
                onForeColor = value;
                Invalidate();
            }
        }

        public Color OffForeColor
        {
            get { return offForeColor; }
            set
            {
                offForeColor = value;
                Invalidate();
            }
        }

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
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                }
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

        private GraphicsPath GetFigurePath()
        {
            int btnSize = Height;
            Rectangle leftArc = new Rectangle(0, 0, btnSize, btnSize);
            Rectangle rightArc = new Rectangle(Width - btnSize - 2, 0, btnSize, btnSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int toggleSize = Height - 5;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //e.Graphics.Clear(Parent.BackColor);

            if (_Value) //ON
            {
                e.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                e.Graphics.FillEllipse(new SolidBrush(onForeColor), new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                e.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                e.Graphics.FillEllipse(new SolidBrush(offForeColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _Value = !_Value;
            if (_Value)
            {
                MQTT_Service.PublishToTopic(TagName, 1);
            }
            else
            {
                MQTT_Service.PublishToTopic(TagName, 0);
            }
            base.OnMouseDown(e);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Invalidate();
        }
    }

    static class HMIUtility
    {
        public static void ShowTagInvalidMessage(IWin32Window control, string tagName)
        {
            MessageBox.Show(control, string.Format("The {0} have Tag = null", tagName), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowTagNameInvalidMessage(IWin32Window control, string controlName)
        {
            MessageBox.Show(control, string.Format("The {0} have TagName = null", controlName), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    public class myControl : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new myControlActionList1(this.Component));
                }
                return actionLists;
            }
        }
    }

    public class myControlActionList1 : DesignerActionList
    {
        private Switch_Button _ToggleButton;
        public myControlActionList1(IComponent component)
           : base(component)
        {
            this._ToggleButton = component as Switch_Button;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("OnBackColor", "OnBackColor"));
            items.Add(new DesignerActionPropertyItem("OffBackColor", "OffBackColor"));
            items.Add(new DesignerActionPropertyItem("OnForeColor", "OnForeColor"));
            items.Add(new DesignerActionPropertyItem("OffForeColor", "OffForeColor"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));


            return items;
        }

        public Color OnBackColor
        {
            get { return _ToggleButton.OnBackColor; }
            set { _ToggleButton.OnBackColor = value; }
        }

        public Color OffBackColor
        {
            get { return _ToggleButton.OffBackColor; }
            set { _ToggleButton.OffBackColor = value; }
        }

        public Color OnForeColor
        {
            get { return _ToggleButton.OnForeColor; }
            set { _ToggleButton.OnForeColor = value; }
        }

        public Color OffForeColor
        {
            get { return _ToggleButton.OffForeColor; }
            set { _ToggleButton.OffForeColor = value; }
        }

        public string TagName
        {
            get { return _ToggleButton.TagName; }
            set
            {
                _ToggleButton.TagName = value;
            }
        }

        public int Privilege
        {
            get { return _ToggleButton.Privilege; }
            set
            {
                _ToggleButton.Privilege = value;
                _ToggleButton.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_ToggleButton, "TagName", tagName);
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
