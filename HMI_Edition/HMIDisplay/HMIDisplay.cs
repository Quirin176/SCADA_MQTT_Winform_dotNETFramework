using Devices;
using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HMI_Edition.HMIDisplay
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMIDisplay), "HMIDisplay.ico")]
    [Designer(typeof(HMIDisplayDesigner))]

    public partial class HMIDisplay : Label
    {
        private string _TagName;
        private dynamic _Value;
        private string _Unit;
        private Color _BackcolorON;
        private Color _BackcolorOFF;

        public HMIDisplay()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.BackColor = SystemColors.ControlDark;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.White;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = false;
            this.Size = new Size(72, 27);
            this.BackcolorON = Color.DarkGreen;
            this.BackcolorOFF = Color.Orange;
        }

        [Category("Misc")]
        [Browsable(true)]
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

        public dynamic Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                UpdateText();
            }
        }

        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
                UpdateText();
            }

        }

        public Color BackcolorON
        {
            get { return _BackcolorON; }
            set
            {
                _BackcolorON = value;
            }
        }

        public Color BackcolorOFF
        {
            get { return _BackcolorOFF; }
            set
            {
                _BackcolorOFF = value;
            }
        }

        private void UpdateText()
        {
            try
            {
                this.Invoke(new EventHandler((obj, evt) =>
                {
                    if (_Value != null)
                    {
                        this.Text = string.Format("{0} {1}", _Value, _Unit);
                    }
                    else
                    {
                        this.Text = "N/A";
                    }
                }));

                if (_Value.ToString() == "True" || _Value.ToString() == "TRUE")
                {
                    this.BackColor = BackcolorON;
                }
                else if (_Value.ToString() == "False" || _Value.ToString() == "FALSE")
                {
                    this.BackColor = BackcolorOFF;
                }
                else
                {
                    return;
                }
            }
            catch (Exception) { }
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
    }
    internal class HMIDisplayDesigner : System.Windows.Forms.Design.ControlDesigner
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

    internal class HMIDisplayListItem : DesignerActionList
    {
        private HMIDisplay _HMIDisplay;
        public HMIDisplayListItem(HMIDisplayDesigner owner)
            : base(owner.Component)
        {
            _HMIDisplay = (HMIDisplay)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionPropertyItem("BorderStyle", "BorderStyle"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));
            items.Add(new DesignerActionPropertyItem("Font", "Font"));
            items.Add(new DesignerActionPropertyItem("TextAlign", "TextAlign"));
            items.Add(new DesignerActionPropertyItem("AutoSize", "AutoSize"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Unit", "Unit"));

            return items;

        }

        public BorderStyle BorderStyle
        {
            get { return _HMIDisplay.BorderStyle; }
            set { _HMIDisplay.BorderStyle = value; }
        }

        public Color BackColor
        {
            get { return _HMIDisplay.BackColor; }
            set { _HMIDisplay.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _HMIDisplay.ForeColor; }
            set { _HMIDisplay.ForeColor = value; }
        }

        public Font Font
        {
            get { return _HMIDisplay.Font; }
            set { _HMIDisplay.Font = value; }
        }

        public ContentAlignment TextAlign
        {
            get { return _HMIDisplay.TextAlign; }
            set { _HMIDisplay.TextAlign = value; }
        }

        public bool AutoSize
        {
            get { return _HMIDisplay.AutoSize; }
            set { _HMIDisplay.AutoSize = value; }
        }

        public string TagName
        {
            get { return _HMIDisplay.TagName; }
            set
            {
                _HMIDisplay.TagName = value;
                _HMIDisplay.Invalidate();
            }
        }

        public string Unit
        {
            get { return _HMIDisplay.Unit; }
            set
            {
                _HMIDisplay.Unit = value;
                _HMIDisplay.Invalidate();
            }
        }

        public Color BackcolorON
        {
            get { return _HMIDisplay.BackcolorON; }
            set
            {
                _HMIDisplay.BackcolorON = value;
                _HMIDisplay.Invalidate();
            }
        }

        public Color BackcolorOFF
        {
            get { return _HMIDisplay.BackcolorOFF; }
            set
            {
                _HMIDisplay.BackcolorOFF = value;
                _HMIDisplay.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_HMIDisplay, "TagName", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }


        public void SetProperty(Label control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
