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

namespace HMI_Tool.SetpointControl
{
    [Designer(typeof(myControl))]
    public partial class SetpointControl : UserControl
    {
        private Color buttonForeColor = Color.Gray;
        private Color buttonBackColor = Color.Transparent;
        private Color textboxForeColor = Color.Black;
        private Color textboxBackColor = Color.White;

        private double _Value;
        private double _maxvalue = 1;
        private double _minvalue = 0;
        private double _Step = 0.1;

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

        public double Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        public double MaxValue
        {
            get { return _maxvalue; }
            set
            {
                if (_maxvalue != value)
                {
                    _maxvalue = value;
                    Invalidate();
                }
            }
        }

        public double MinValue
        {
            get { return _minvalue; }
            set
            {
                if (_minvalue != value)
                {
                    _minvalue = value;
                    Invalidate();
                }
            }
        }

        public double Step
        {
            get { return _Step; }
            set
            {
                if (_Step != value)
                {
                    _Step = value;
                    Invalidate();
                }
            }
        }

        [Category("Misc")]
        public Color ButtonForeColor
        {
            get { return buttonForeColor; }
            set
            {
                buttonForeColor = value;
                Invalidate();
            }
        }

        [Category("Misc")]
        public Color ButtonBackColor
        {
            get { return buttonBackColor; }
            set
            {
                buttonBackColor = value;
                Invalidate();
            }
        }

        [Category("Misc")]
        public Color TextboxForeColor
        {
            get { return textboxForeColor; }
            set
            {
                textboxForeColor = value;
                Invalidate();
            }
        }

        [Category("Misc")]
        public Color TextboxBackColor
        {
            get { return textboxBackColor; }
            set
            {
                textboxBackColor = value;
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

        public SetpointControl()
        {
            InitializeComponent();

            this.Width = 30;
            this.Height = 40;

            btn_Up.ForeColor = buttonForeColor;
            btn_Up.BackColor = buttonBackColor;
            btn_Down.ForeColor = buttonForeColor;
            btn_Down.BackColor = buttonBackColor;

            this.Resize += SetpointControl_Resize;
        }

        private void SetpointControl_Resize(object sender, EventArgs e)
        {
            AdjustButtonSizes();
        }

        private void AdjustButtonSizes()
        {
            int padding = 0;
            int buttonWidth = this.Width - 2 * padding;
            int buttonHeight = (this.Height - 3 * padding) / 2;

            btn_Up.Width = buttonWidth;
            btn_Up.Height = buttonHeight;
            btn_Up.Location = new Point(padding, padding);

            // Adjust the position and size of the "Down" button
            btn_Down.Width = buttonWidth;
            btn_Down.Height = buttonHeight;
            btn_Down.Location = new Point(padding, btn_Up.Bottom + padding);
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (_Value + _Step <= _maxvalue)
            {
                MQTT_Service.PublishToTopic(MQTT_TagCollection.Tags[_TagName].Topic, _Value + _Step);
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (_Value - _Step >= _minvalue)
            {
                MQTT_Service.PublishToTopic(MQTT_TagCollection.Tags[_TagName].Topic, _Value - _Step);
            }
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
        private SetpointControl _SetpointControl;
        public myControlActionList1(IComponent component)
           : base(component)
        {
            this._SetpointControl = component as SetpointControl;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("ButtonForeColor", "ButtonForeColor"));
            items.Add(new DesignerActionPropertyItem("ButtonBackColor", "ButtonBackColor"));
            items.Add(new DesignerActionPropertyItem("TextboxForeColor", "TextboxForeColor"));
            items.Add(new DesignerActionPropertyItem("TextboxBackColor", "TextboxBackColor"));

            items.Add(new DesignerActionPropertyItem("MaxValue", "MaxValue"));
            items.Add(new DesignerActionPropertyItem("MinValue", "MinValue"));
            items.Add(new DesignerActionPropertyItem("Step", "Step"));

            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));


            return items;
        }

        public Color ButtonForeColor
        {
            get { return _SetpointControl.ButtonForeColor; }
            set { _SetpointControl.ButtonForeColor = value; }
        }

        public Color ButtonBackColor
        {
            get { return _SetpointControl.ButtonBackColor; }
            set { _SetpointControl.ButtonBackColor = value; }
        }

        public Color TextboxForeColor
        {
            get { return _SetpointControl.TextboxForeColor; }
            set { _SetpointControl.TextboxForeColor = value; }
        }

        public Color TextboxBackColor
        {
            get { return _SetpointControl.TextboxBackColor; }
            set { _SetpointControl.TextboxBackColor = value; }
        }

        public double MaxValue
        {
            get { return _SetpointControl.MaxValue; }
            set
            {
                _SetpointControl.MaxValue = value;
                _SetpointControl.Invalidate();
            }
        }

        public double MinValue
        {
            get { return _SetpointControl.MinValue; }
            set
            {
                _SetpointControl.MinValue = value;
                _SetpointControl.Invalidate();
            }
        }

        public double Step
        {
            get { return _SetpointControl.Step; }
            set
            {
                _SetpointControl.Step = value;
                _SetpointControl.Invalidate();
            }
        }

        public string TagName
        {
            get { return _SetpointControl.TagName; }
            set
            {
                _SetpointControl.TagName = value;
            }
        }

        public int Privilege
        {
            get { return _SetpointControl.Privilege; }
            set
            {
                _SetpointControl.Privilege = value;
                _SetpointControl.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_SetpointControl, "TagName", tagName);
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
