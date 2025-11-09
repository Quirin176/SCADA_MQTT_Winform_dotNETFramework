using Driver_Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using MQTT_Protocol;

namespace HMI_Edition.HMIText
{
    [Designer(typeof(HMIDisplayDesigner1))]

    public class HMIText : TextBox
    {
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
                    base.Text = value;
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

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;


                this.Invalidate();
            }
        }

        // public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        public HMIText()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.ForeColor = Color.Black;

        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
            }
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
        private HMIText colUserControl;
        public HMIDisplayListItem1(HMIDisplayDesigner1 owner)
            : base(owner.Component)
        {
            colUserControl = (HMIText)owner.Component;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Value", "Value"));

            return items;

        }

        public double Value
        {
            get { return colUserControl.Value; }
            set { colUserControl.Value = value; }
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
            frm_TagList frm = new frm_TagList(this.TagName);
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
