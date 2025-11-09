using Driver_Tool;
using HMI_Alarm.Manager;
using MQTT_Protocol.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMI_Alarm
{
    public delegate void EventAnalogDeviceChanged(Device_Analog ch);
    public delegate void EventDigitalDeviceChanged(Device_Digital ch);

    public delegate void EventAnalogAlarmChanged(Alarm_Analog ch);
    public delegate void EventDigitalAlarmChanged(Alarm_Digital ch);

    public partial class frm_AlarmTag : Form
    {
        public EventAnalogDeviceChanged eventAnalogDeviceChanged = null;
        public EventDigitalDeviceChanged eventDigitalDeviceChanged = null;
        public EventAnalogAlarmChanged eventAnalogAlarmChanged = null;
        public EventDigitalAlarmChanged eventDigitalAlarmChanged = null;

        private string selectedItem;
        private bool IsDataChanged = false;

        public frm_AlarmTag()
        {
            InitializeComponent();
        }

        private void frm_AlarmTag_Load(object sender, EventArgs e)
        {
            try
            {
                string xmlFile = AnalogDevice_Manager.ReadKey(AnalogDevice_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeAnalogData(AnalogDevice_Manager.ReadKey(AnalogDevice_Manager.XML_NAME_DEFAULT));
                AnalogDevice_Manager.GetDeviceAnalogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //List<Device_Analog> deviceList = AnalogDevice_Manager.GetDeviceAnalogs();

            try
            {
                string xmlFile = DigitalDevice_Manager.ReadKey(DigitalDevice_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeDigitalData(DigitalDevice_Manager.ReadKey(DigitalDevice_Manager.XML_NAME_DEFAULT));
                List<Device_Digital> deviceList = DigitalDevice_Manager.GetDeviceDigitals();

                foreach (Device_Digital device in deviceList)
                {
                    string[] row = { device.DeviceDigitalName };

                    ListViewItem item = new ListViewItem(row);
                    item.ImageIndex = 0;
                    listView3.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeAnalogData(string xmlPath)
        {
            AnalogDevice_Manager.DeviceAnalogs.Clear();
            AnalogDevice_Manager.XmlPath = xmlPath;
        }

        private void InitializeDigitalData(string xmlPath)
        {
            DigitalDevice_Manager.DeviceDigitals.Clear();
            DigitalDevice_Manager.XmlPath = xmlPath;
        }

        private void listView3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                selectedItem = e.Item.Text;
                listView1.Items.Clear();
                listView2.Items.Clear();
            }

            Device_Analog currentADevice = null;
            currentADevice = AnalogDevice_Manager.GetByDeviceAnalogName(selectedItem);
            if (currentADevice == null)
            {
                return;
            }
            else
            {
                foreach (Alarm_Analog aalarm in currentADevice.AlarmAnalogs)
                {
                    string[] row = {
                        aalarm.AlarmName,
                        aalarm.Source,
                        string.Format("{0}", aalarm.HighHigh),
                        string.Format("{0}", aalarm.High),
                        string.Format("{0}", aalarm.Low),
                        string.Format("{0}", aalarm.LowLow)
                        };

                    ListViewItem item = new ListViewItem(row);
                    item.ImageIndex = 0;
                    listView1.Items.Add(item);
                }
            }

            Device_Digital currentDDevice = null;
            currentDDevice = DigitalDevice_Manager.GetByDeviceDigitalName(selectedItem);
            if (currentDDevice.AlarmDigitals == null)
            {
                return;
            }
            else
            {
                foreach (Alarm_Digital tg in currentDDevice.AlarmDigitals)
                {
                    string[] row = {
                        tg.AlarmName,
                        tg.Source
                        };

                    ListViewItem item = new ListViewItem(row);
                    item.ImageIndex = 0;
                    listView2.Items.Add(item);
                }
            }
        }

        private void TagName_Analog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTagListForm_Analog();
        }

        private void TagName_Digital_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTagListForm_Digital();
        }

        private void btn_AddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                string deviceName = txt_DeviceName.Text;

                errorProvider1.Clear();
                if (string.IsNullOrEmpty(deviceName) || string.IsNullOrWhiteSpace(deviceName))
                {
                    errorProvider1.SetError(txt_DeviceName, "The Device name is empty");
                    return;
                }
                errorProvider1.Clear();

                string[] s = new string[1];
                s[0] = txt_DeviceName.Text;
                listView3.Items.Add(new ListViewItem(s));

                Device_Analog adevice = new Device_Analog();
                adevice.DeviceAnalogId = AnalogDevice_Manager.DeviceAnalogs.Count;
                adevice.DeviceAnalogName = deviceName;
                adevice.AlarmAnalogs = new List<Alarm_Analog>();
                AnalogDevice_Manager.Add(adevice);
                if (eventAnalogDeviceChanged != null) eventAnalogDeviceChanged(adevice);

                Device_Digital ddevice = new Device_Digital();
                ddevice.DeviceDigitalId = DigitalDevice_Manager.DeviceDigitals.Count;
                ddevice.DeviceDigitalName = deviceName;
                ddevice.AlarmDigitals = new List<Alarm_Digital>();
                DigitalDevice_Manager.Add(ddevice);
                if (eventDigitalDeviceChanged != null) eventDigitalDeviceChanged(ddevice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AddUpdate_Analog_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrWhiteSpace(selectedItem))
                {
                    errorProvider1.SetError(listView3, "The Device name is not selected");
                    return;
                }
                if (string.IsNullOrEmpty(AlarmName_Analog.Text) || string.IsNullOrWhiteSpace(AlarmName_Analog.Text))
                {
                    errorProvider1.SetError(AlarmName_Analog, "The Alarm name is empty");
                    return;
                }
                if (string.IsNullOrEmpty(TagName_Analog.Text) || string.IsNullOrWhiteSpace(TagName_Analog.Text))
                {
                    errorProvider1.SetError(TagName_Analog, "The Source is empty");
                    return;
                }
                errorProvider1.Clear();

                //foreach (ListViewItem li in listView1.Items)
                //{
                //    if (li.SubItems[1].Text == TagName_Analog.Text)
                //    {
                //        li.SubItems[0].Text = AlarmName_Analog.Text;
                //        li.SubItems[2].Text = txt_HighHigh.Text;
                //        li.SubItems[3].Text = txt_High.Text;
                //        li.SubItems[4].Text = txt_Low.Text;
                //        li.SubItems[5].Text = txt_LowLow.Text;

                //        return;
                //    }
                //}

                string[] s = new string[6];
                s[0] = AlarmName_Analog.Text;
                s[1] = TagName_Analog.Text;
                s[2] = txt_HighHigh.Text;
                s[3] = txt_High.Text;
                s[4] = txt_Low.Text;
                s[5] = txt_LowLow.Text;
                listView1.Items.Add(new ListViewItem(s));

                Device_Analog currentADevice = null;
                currentADevice = AnalogDevice_Manager.GetByDeviceAnalogName(selectedItem);

                Alarm_Analog newTg = new Alarm_Analog();
                newTg.AlarmId = currentADevice.AlarmAnalogs.Count;
                newTg.AlarmName = AlarmName_Analog.Text;
                newTg.Source = TagName_Analog.Text;
                newTg.HighHigh = int.Parse(txt_HighHigh.Text.ToString());
                newTg.High = int.Parse(txt_High.Text.ToString());
                newTg.Low = int.Parse(txt_Low.Text.ToString());
                newTg.LowLow = int.Parse(txt_LowLow.Text.ToString());
                AnalogAlarm_Manager.Add(currentADevice, newTg);
                if (eventAnalogAlarmChanged != null) eventAnalogAlarmChanged(newTg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IsDataChanged = true;
        }

        private void btn_AddUpdate_Digital_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrWhiteSpace(selectedItem))
                {
                    errorProvider1.SetError(listView3, "The Device name is not selected");
                    return;
                }
                if (string.IsNullOrEmpty(AlarmName_Digital.Text) || string.IsNullOrWhiteSpace(AlarmName_Digital.Text))
                {
                    errorProvider1.SetError(AlarmName_Digital, "The Alarm name is empty");
                    return;
                }
                if (string.IsNullOrEmpty(TagName_Digital.Text) || string.IsNullOrWhiteSpace(TagName_Digital.Text))
                {
                    errorProvider1.SetError(TagName_Digital, "The Source is empty");
                    return;
                }
                errorProvider1.Clear();

                //foreach (ListViewItem li in listView2.Items)
                //{
                //    if (li.SubItems[1].Text == TagName_Analog.Text)
                //    {
                //        li.SubItems[0].Text = AlarmName_Analog.Text;

                //        return;
                //    }
                //}

                Device_Digital currentDDevice = null;
                currentDDevice = DigitalDevice_Manager.GetByDeviceDigitalName(selectedItem);
                Alarm_Digital newTg = new Alarm_Digital();

                newTg.AlarmId = currentDDevice.AlarmDigitals.Count;
                newTg.AlarmName = AlarmName_Digital.Text;
                newTg.Source = TagName_Digital.Text;
                DigitalAlarm_Manager.Add(currentDDevice, newTg);
                if (eventDigitalAlarmChanged != null) eventDigitalAlarmChanged(newTg);

                string[] s = new string[2];
                s[0] = AlarmName_Digital.Text;
                s[1] = TagName_Digital.Text;
                listView2.Items.Add(new ListViewItem(s));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IsDataChanged = true;
        }

        private void btn_RemoveDevice_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrWhiteSpace(selectedItem))
                {
                    errorProvider1.SetError(listView3, "The Device name is not selected");
                    return;
                }
                errorProvider1.Clear();

                AnalogDevice_Manager.Delete(selectedItem);
                DigitalDevice_Manager.Delete(selectedItem);

                ListViewItem li = listView3.SelectedItems.Count > 0 ? listView3.SelectedItems[0] : null;

                if (li != null)
                {
                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Remove(li);
                }
                else
                {
                    MessageBox.Show(this, "ListView item is not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                IsDataChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Remove_Analog_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrWhiteSpace(selectedItem))
                {
                    errorProvider1.SetError(listView3, "The Device name is not selected");
                    return;
                }
                errorProvider1.Clear();

                Device_Analog deviceCurrent = AnalogDevice_Manager.GetByDeviceAnalogName(selectedItem);

                if (listView1.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in listView1.SelectedItems)
                    {
                        Alarm_Analog alarmCurrent = AnalogAlarm_Manager.GetByAlarmName(deviceCurrent, li.SubItems[0].Text);
                        AnalogAlarm_Manager.Delete(deviceCurrent, alarmCurrent);
                        listView1.Items.Remove(li);
                        IsDataChanged = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Remove_Digital_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrWhiteSpace(selectedItem))
                {
                    errorProvider1.SetError(listView3, "The Device name is not selected");
                    return;
                }
                errorProvider1.Clear();

                Device_Digital deviceCurrent = DigitalDevice_Manager.GetByDeviceDigitalName(selectedItem);

                if (listView2.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in listView2.SelectedItems)
                    {
                        Alarm_Digital alarmCurrent = DigitalAlarm_Manager.GetByAlarmName(deviceCurrent, li.SubItems[0].Text);
                        DigitalAlarm_Manager.Delete(deviceCurrent, alarmCurrent);
                        listView2.Items.Remove(li);
                        IsDataChanged = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTagListForm_Analog()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty_Analog(TagName_Analog, "Text", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty_Analog(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }

        private void ShowTagListForm_Digital()
        {
            frm_TagList frm = new frm_TagList();
            frm.OnTagSelected_Clicked += new EventTagSelected((tagName) =>
            {
                SetProperty_Digital(TagName_Digital, "Text", tagName);
            });
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty_Digital(Control control, string propertyName, object value)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(AnalogDevice_Manager.XmlPath) || string.IsNullOrWhiteSpace(AnalogDevice_Manager.XmlPath))
                {
                    AnalogDevice_Manager.Save(string.Format("{0}\\{1}.xml", Application.StartupPath, AnalogDevice_Manager.XML_NAME_DEFAULT));
                }
                else
                {
                    AnalogDevice_Manager.Save(AnalogDevice_Manager.XmlPath);
                    MessageBox.Show(this, "Data saved successfully!", Msg.MSG_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (string.IsNullOrEmpty(DigitalDevice_Manager.XmlPath) || string.IsNullOrWhiteSpace(DigitalDevice_Manager.XmlPath))
                {
                    DigitalDevice_Manager.Save(string.Format("{0}\\{1}.xml", Application.StartupPath, DigitalDevice_Manager.XML_NAME_DEFAULT));
                }
                else
                {
                    DigitalDevice_Manager.Save(DigitalDevice_Manager.XmlPath);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = AnalogDevice_Manager.XML_NAME_DEFAULT;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string xmlPath = saveFileDialog1.FileName;
                    AnalogDevice_Manager.Save(xmlPath);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                saveFileDialog1.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = DigitalDevice_Manager.XML_NAME_DEFAULT;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string xmlPath = saveFileDialog1.FileName;
                    DigitalDevice_Manager.Save(xmlPath);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AlarmTag_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsDataChanged == false) return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
