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
using System.Xml.Linq;

namespace HMI_Edition.HMIDisplay
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(LSN50_LoRa_Display), "LSN50_LoRa_Display.ico")]
    [Designer(typeof(LSN50_LoRa_DisplayDesigner))]
    public partial class LSN50_LoRa_Display : Label
    {
        private string _TagName;
        private dynamic _Value;
        private string _Data;
        private string _Unit;

        public LSN50_LoRa_Display()
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

                    if (root.TryGetProperty("uplink_message", out JsonElement uplinkMessage) &&
                        uplinkMessage.TryGetProperty("decoded_payload", out JsonElement decodedPayload) &&
                        decodedPayload.TryGetProperty(dataKey, out JsonElement element))
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

    internal class LSN50_LoRa_DisplayDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new LSN50_LoRa_DisplayListItem(this));
                }
                return actionLists;
            }
        }
    }

    internal class LSN50_LoRa_DisplayListItem : DesignerActionList
    {
        private LSN50_LoRa_Display _LSN50_LoRa_Display;
        public LSN50_LoRa_DisplayListItem(LSN50_LoRa_DisplayDesigner owner)
            : base(owner.Component)
        {
            _LSN50_LoRa_Display = (LSN50_LoRa_Display)owner.Component;
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
            get { return _LSN50_LoRa_Display.BorderStyle; }
            set { _LSN50_LoRa_Display.BorderStyle = value; }
        }

        public Color BackColor
        {
            get { return _LSN50_LoRa_Display.BackColor; }
            set { _LSN50_LoRa_Display.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _LSN50_LoRa_Display.ForeColor; }
            set { _LSN50_LoRa_Display.ForeColor = value; }
        }

        public Font Font
        {
            get { return _LSN50_LoRa_Display.Font; }
            set { _LSN50_LoRa_Display.Font = value; }
        }

        public ContentAlignment TextAlign
        {
            get { return _LSN50_LoRa_Display.TextAlign; }
            set { _LSN50_LoRa_Display.TextAlign = value; }
        }

        public bool AutoSize
        {
            get { return _LSN50_LoRa_Display.AutoSize; }
            set { _LSN50_LoRa_Display.AutoSize = value; }
        }

        public string TagName
        {
            get { return _LSN50_LoRa_Display.TagName; }
            set
            {
                _LSN50_LoRa_Display.TagName = value;
                _LSN50_LoRa_Display.Invalidate();
            }
        }

        public string Data
        {
            get { return _LSN50_LoRa_Display.Data; }
            set
            {
                _LSN50_LoRa_Display.Data = value;
                _LSN50_LoRa_Display.Invalidate();
            }
        }

        public string Unit
        {
            get { return _LSN50_LoRa_Display.Unit; }
            set
            {
                _LSN50_LoRa_Display.Unit = value;
                _LSN50_LoRa_Display.Invalidate();
            }
        }

        private void ShowTagListForm()
        {
            frm_TagList frm = new frm_TagList(this.TagName);
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty(_LSN50_LoRa_Display, "TagName", tagName);
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
