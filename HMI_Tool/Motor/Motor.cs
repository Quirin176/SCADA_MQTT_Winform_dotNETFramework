using Driver_Tool;
using HMI_Tool.Faceplate;
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

namespace HMI_Tool.Motor
{
    [Designer(typeof(HMIDisplayDesigner2))]
    public partial class Motor : UserControl
    {
        private string _TagName;
        private bool _Value = false;

        private LightColors m_LightColor;
        private RotateFlipType m_Rotation;

        private Bitmap imageon;// = Properties.Resources.Motor_green;
        private Bitmap imageoff; //= Properties.Resources.Motor_grey;
        private Bitmap image;//= Properties.Resources.Motor_grey;


        public Motor()
        {
            imageon = Properties.Resources.Motor_green;
            imageoff = Properties.Resources.Motor_grey;
            image = Properties.Resources.Motor_grey;

            this.Size = new Size(125, 75);
            InitializeComponent();
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
        public enum LightColors
        {
            Red,
            Green,
        }

        [Category("Misc")]
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

        [Category("Misc")]
        public RotateFlipType Rotate
        {
            get { return m_Rotation; }
            set
            {
                if (m_Rotation != value)
                {
                    m_Rotation = value;
                    choice();
                }
            }
        }

        [Category("Misc")]
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

        private void choice()
        {
            if (m_LightColor == LightColors.Green) imageon = Properties.Resources.Motor_green;
            else imageon = Properties.Resources.Motor_red;
            imageoff = new Bitmap(Properties.Resources.Motor_grey);
            imageon.RotateFlip(m_Rotation);
            imageoff.RotateFlip(m_Rotation);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Value == true) image = imageon;
            else image = imageoff;
            e.Graphics.DrawImage(image, 0, 0, this.Width, this.Height);
            base.OnPaint(e);
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

            //Motor_Faceplate fpl = new Motor_Faceplate(LightName, TagName, SWTopic);
            //fpl.ShowDialog();

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
        private Motor colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner2 owner)
            : base(owner.Component)
        {
            colUserControl = (Motor)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("ColorON", "ColorON"));
            items.Add(new DesignerActionPropertyItem("Rotate", "Rotate"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm1", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            items.Add(new DesignerActionPropertyItem("Faceplate", "Faceplate"));
            items.Add(new DesignerActionPropertyItem("MotorName", "MotorName"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm2", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("SWTopic", "SWTopic"));
            items.Add(new DesignerActionPropertyItem("Privilege", "Privilege"));


            return items;
        }

        public Motor.LightColors ColorON
        {
            get { return colUserControl.ColorON; }
            set { colUserControl.ColorON = value; }
        }
        public RotateFlipType Rotate
        {
            get { return colUserControl.Rotate; }
            set { colUserControl.Rotate = value; }
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
