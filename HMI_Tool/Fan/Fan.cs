using Driver_Tool;
using HMI_Tool.Faceplate;
using HMI_Tool.Motor;
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

namespace HMI_Tool.Fan
{
    [Designer(typeof(HMIDisplayDesigner2))]

    public partial class Fan : UserControl
    {
        private string _Value = "false";

        private LightColors m_LightColor;

        private Bitmap imageon;// = Properties.Resources.Fan_Green;
        private Bitmap imageoff; //= Properties.Resources.Fan_Grey;
        private Bitmap image;//= Properties.Resources.Fan_Grey;

        public Fan()
        {
            imageon = Properties.Resources.Fan_Green;
            imageoff = Properties.Resources.Fan_Grey;
            image = Properties.Resources.Fan_Grey;

            this.Size = new Size(50, 50);

            InitializeComponent();
        }

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

        public enum LightColors
        {
            Green,
        }

        public LightColors ColorON
        {
            get { return m_LightColor; }
            set
            {
                if (m_LightColor != value)
                {
                    m_LightColor = value;
                    choice();
                }
            }
        }

        private void choice()

        {
            if (m_LightColor == LightColors.Green) imageon = Properties.Resources.Fan_Green;
            else imageon = Properties.Resources.Fan_Green;
            imageoff = new Bitmap(Properties.Resources.Fan_Grey);

            Invalidate();
        }

        public string Value
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

        private string _fanName;
        [Category("MyFaceplate")]
        public string FanName
        {
            get { return _fanName; }
            set
            {
                if (_fanName != value)
                {
                    _fanName = value;
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

        private string _powerTopic;
        [Category("MyFaceplate")]
        public string PowerTopic
        {
            get { return _powerTopic; }
            set
            {
                if (_powerTopic != value)
                {
                    _powerTopic = value;
                    Invalidate();
                }
            }
        }

        private string _speedTopic;
        [Category("MyFaceplate")]
        public string SpeedTopic
        {
            get { return _speedTopic; }
            set
            {
                if (_speedTopic != value)
                {
                    _speedTopic = value;
                    Invalidate();
                }
            }
        }

        //private string _speedData;
        //[Category("MyFaceplate")]
        //public string SpeedData
        //{
        //    get { return _speedData; }
        //    set
        //    {
        //        if (_speedData != value)
        //        {
        //            _speedData = value;
        //            Invalidate();
        //        }
        //    }
        //}

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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Value == null || _Value.Trim().ToLower() == "" || _Value.Trim().ToLower() == "0" || _Value.Trim().ToLower() == "false")
            {
                image = imageoff;
            }
            else
            {
                image = imageon;
            }
            e.Graphics.DrawImage(image, 0, 0, this.Width, this.Height);
            base.OnPaint(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //if (!_faceplate)
            //return;
            if (string.IsNullOrEmpty(_swTopic) || string.IsNullOrWhiteSpace(_swTopic))
                return;
            if (string.IsNullOrEmpty(_fanName) || string.IsNullOrWhiteSpace(_fanName))
            {
                _fanName = "Empty";
            }

            Fan_Faceplate fpl = new Fan_Faceplate(FanName, TagName, SWTopic, PowerTopic, SpeedTopic/*, SpeedData*/);
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
        private Fan colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (Fan)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm1", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            items.Add(new DesignerActionPropertyItem("Faceplate", "Faceplate"));
            items.Add(new DesignerActionPropertyItem("FanName", "FanName"));

            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm2", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("SWTopic", "SWTopic"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm3", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("PowerTopic", "PowerTopic"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm4", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("SpeedTopic", "SpeedTopic"));
            //items.Add(new DesignerActionPropertyItem("SpeedData", "SpeedData"));

            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));

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

        public bool Faceplate
        {
            get { return colUserControl.Faceplate; }
            set { colUserControl.Faceplate = value; }
        }

        public string FanName
        {
            get { return colUserControl.FanName; }
            set
            {
                colUserControl.FanName = value;
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

        public string PowerTopic
        {
            get { return colUserControl.PowerTopic; }
            set
            {
                colUserControl.PowerTopic = value;
                colUserControl.Invalidate();
            }
        }

        public string SpeedTopic
        {
            get { return colUserControl.SpeedTopic; }
            set
            {
                colUserControl.SpeedTopic = value;
                colUserControl.Invalidate();
            }
        }

        //public string SpeedData
        //{
        //    get { return colUserControl.SpeedData; }
        //    set
        //    {
        //        colUserControl.SpeedData = value;
        //        colUserControl.Invalidate();
        //    }
        //}

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

        private void ShowTagListForm3()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((powerTopic) =>
            {
                SetProperty(colUserControl, "PowerTopic", powerTopic);
            });

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void ShowTagListForm4()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((speedTopic) =>
            {
                SetProperty(colUserControl, "SpeedTopic", speedTopic);
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
