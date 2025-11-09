using Driver_Tool;
using MQTT_Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Edition.HMIDisplay
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Json_DataDisplay), "Json_DataDisplay.ico")]
    [Designer(typeof(Json_DataDisplayDesigner))]
    public partial class Json_DataDisplay : Label
    {
        public Json_DataDisplay()
        {
            InitializeComponent();
            InitializeComponents();
        }
        private string _TagName;
        private dynamic _Value;
        private string _Data;
        private string _Unit;

        private void InitializeComponents()
        {
            this.BackColor = SystemColors.Control;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.Black;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = false;
            this.Size = new Size(72, 27);
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

        public string Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
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

        private void UpdateText()
        {
            try
            {
                this.Invoke(new EventHandler((obj, evt) =>
                {
                    if (!string.IsNullOrEmpty(_Data) && _Value != null)
                    {
                        string extractedValue = ExtractElementFromJson(_Value.ToString(), _Data);
                        extractedValue = extractedValue.Replace(" ", string.Empty);

                        this.Text = $"{extractedValue:F2} {_Unit}";
                    }
                    else
                    {
                        this.Text = "N/A";
                    }
                }));
            }
            catch (Exception) { }
        }

        public static string ExtractElementFromJson(string jsonString, string dataKey)
        {
            if (string.IsNullOrEmpty(jsonString) || string.IsNullOrWhiteSpace(jsonString))
            {
                return string.Empty;
            }

            try
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    JsonElement root = doc.RootElement;

                    if (root.TryGetProperty(dataKey, out JsonElement element))
                    {
                        return element.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (JsonException)
            {
                //Console.WriteLine($"Error parsing JSON: {ex.Message}");
                return string.Empty;
            }
            catch (Exception)
            {
                //Console.WriteLine($"Unexpected error: {ex.Message}");
                return string.Empty;
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
    }

    internal class Json_DataDisplayDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new Json_DataDisplayListItem(this));
                }
                return actionLists;
            }
        }
    }

    internal class Json_DataDisplayListItem : DesignerActionList
    {
        private Json_DataDisplay _Json_DataDisplay;
        public Json_DataDisplayListItem(Json_DataDisplayDesigner owner)
            : base(owner.Component)
        {
            _Json_DataDisplay = (Json_DataDisplay)owner.Component;
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
            items.Add(new DesignerActionPropertyItem("Data", "Data"));
            items.Add(new DesignerActionPropertyItem("Unit", "Unit"));

            return items;

        }

        public BorderStyle BorderStyle
        {
            get { return _Json_DataDisplay.BorderStyle; }
            set { _Json_DataDisplay.BorderStyle = value; }
        }

        public Color BackColor
        {
            get { return _Json_DataDisplay.BackColor; }
            set { _Json_DataDisplay.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _Json_DataDisplay.ForeColor; }
            set { _Json_DataDisplay.ForeColor = value; }
        }

        public Font Font
        {
            get { return _Json_DataDisplay.Font; }
            set { _Json_DataDisplay.Font = value; }
        }

        public ContentAlignment TextAlign
        {
            get { return _Json_DataDisplay.TextAlign; }
            set { _Json_DataDisplay.TextAlign = value; }
        }

        public bool AutoSize
        {
            get { return _Json_DataDisplay.AutoSize; }
            set { _Json_DataDisplay.AutoSize = value; }
        }

        public string TagName
        {
            get { return _Json_DataDisplay.TagName; }
            set
            {
                _Json_DataDisplay.TagName = value;
                _Json_DataDisplay.Invalidate();
            }
        }

        public string Data
        {
            get { return _Json_DataDisplay.Data; }
            set
            {
                _Json_DataDisplay.Data = value;
                _Json_DataDisplay.Invalidate();
            }
        }

        public string Unit
        {
            get { return _Json_DataDisplay.Unit; }
            set
            {
                _Json_DataDisplay.Unit = value;
                _Json_DataDisplay.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_Json_DataDisplay, "TagName", tagName);
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
