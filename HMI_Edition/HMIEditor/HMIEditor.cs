using Devices;
using Driver_Tool;
using HMI_Edition.Utility;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace HMI_Edition.HMIEditor
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMIEditor), "HMIEditor.ico")]
    [Designer(typeof(HMIEditorDesigner))]

    public partial class HMIEditor : TextBox
    {
        public HMIEditor()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.Black;
            this.TextAlign = HorizontalAlignment.Center;
            this.KeyDown += new KeyEventHandler(HMIEditor_KeyDown);
        }

        private void HMIEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(TagName) || string.IsNullOrWhiteSpace(TagName))
                    {
                        HMIUtility.ShowTagNameInvalidMessage(this, Name);
                    }
                    else if (MQTT_TagCollection.Tags[this.TagName] == null)
                    {
                        HMIUtility.ShowTagInvalidMessage(this, Name);
                    }
                    else
                    {
                        MQTT_Service.PublishToTopic(TagName, Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string _TagName;

        [Category("Misc")]
        [Browsable(true)]
        public string TagName
        {
            get { return _TagName; }
            set
            {
                _TagName = value;
            }
        }
    }

    internal class HMIEditorDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIEditorListItem(this));
                }
                return actionLists;
            }
        }
    }

    internal class HMIEditorListItem : DesignerActionList
    {
        private HMIEditor _HMIEditor;
        public HMIEditorListItem(HMIEditorDesigner owner)
            : base(owner.Component)
        {
            _HMIEditor = (HMIEditor)owner.Component;
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
            return items;
        }

        public BorderStyle BorderStyle
        {
            get { return _HMIEditor.BorderStyle; }
            set { _HMIEditor.BorderStyle = value; }
        }

        public Color BackColor
        {
            get { return _HMIEditor.BackColor; }
            set { _HMIEditor.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _HMIEditor.ForeColor; }
            set { _HMIEditor.ForeColor = value; }
        }

        public Font Font
        {
            get { return _HMIEditor.Font; }
            set { _HMIEditor.Font = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return _HMIEditor.TextAlign; }
            set { _HMIEditor.TextAlign = value; }
        }

        public bool AutoSize
        {
            get { return _HMIEditor.AutoSize; }
            set { _HMIEditor.AutoSize = value; }
        }

        public string TagName
        {
            get { return _HMIEditor.TagName; }
            set
            {
                _HMIEditor.TagName = value;
                _HMIEditor.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_HMIEditor, "TagName", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }


        public void SetProperty(TextBox control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
