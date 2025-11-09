using Driver_Tool.Manager;
using MQTT_Protocol.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Driver_Tool.Dialog
{
    public delegate void EventDeviceChanged(Device device);

    public partial class frm_Device : Form
    {
        private Building building = null;
        private Floor floor = null;
        private Room room = null;
        private Device device = null;
        public EventDeviceChanged eventDeviceChanged = null;

        public frm_Device(Building buildingParam, Floor floorParam, Room roomParam, Device deviceParam = null)
        {
            InitializeComponent();
            building = buildingParam;
            floor = floorParam;
            room = roomParam;
            device = deviceParam;
        }

        private void frm_Group_Load(object sender, EventArgs e)
        {
            try
            {
                txt_RoomName.Text = room.RoomName;
                txt_RoomName.Enabled = false;

                txt_FloorName.Text = floor.FloorName;
                txt_FloorName.Enabled = false;

                txt_NumberofTags.Value = 3;
                cbox_QoS.SelectedIndex = 1;

                if (this.device == null)
                {
                    this.Text = "Add Device";
                }
                else
                {
                    this.Text = "Edit Device";
                    txt_DeviceName.Text = device.DeviceName;
                    txt_Description.Text = device.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_DeviceName.Text)
                    || string.IsNullOrWhiteSpace(txt_DeviceName.Text))
                    errorProvider1.SetError(txt_DeviceName, "The Device Name is empty");

                if (check_MultipleTags.Checked && (string.IsNullOrEmpty(txt_TagPrefix.Text)
                    || string.IsNullOrWhiteSpace(txt_TagPrefix.Text)))
                    errorProvider1.SetError(txt_TagPrefix, "Tag Prefix is empty");

                if (check_MultipleTags.Checked && (string.IsNullOrEmpty(txt_TopicPrefix.Text)
                    || string.IsNullOrWhiteSpace(txt_TopicPrefix.Text)))
                    errorProvider1.SetError(txt_TopicPrefix, "Topic Prefix is empty");

                if (check_MultipleTags.Checked && (string.IsNullOrEmpty(cbox_QoS.Text)
                    || string.IsNullOrWhiteSpace(cbox_QoS.Text)))
                    errorProvider1.SetError(cbox_QoS, "Quality of Service is empty");

                else
                {
                    ushort number = (ushort)txt_NumberofTags.Value;

                    errorProvider1.Clear();
                    if (device == null)
                    {
                        Device deviceNew = new Device();
                        deviceNew.DeviceId = room.Devices.Count + 1;
                        deviceNew.DeviceName = txt_DeviceName.Text;
                        deviceNew.Description = txt_Description.Text;
                        deviceNew.Tags = new List<Tag>();
                        Device_Manager.Add(room, deviceNew);

                        if (check_MultipleTags.Checked)
                        {
                            for (int i = 1; i <= txt_NumberofTags.Value; i++)
                            {
                                Tag tag = new Tag();
                                tag.TagId = i;
                                tag.TagName = string.Format("{0}{1}", txt_TagPrefix.Text, i);
                                tag.Topic = string.Format("{0}{1}", txt_TopicPrefix.Text, i);
                                tag.QoS = byte.Parse(cbox_QoS.SelectedItem.ToString());
                                tag.Description = string.Format("{0}{1}", txt_Description.Text, i);
                                tag.Retain = check_Retain.Checked;
                                tag.IsInput = check_IsInput.Checked;
                                deviceNew.Tags.Add(tag);
                            }
                        }

                        if (eventDeviceChanged != null) eventDeviceChanged(deviceNew);
                    }
                    else
                    {
                        device.DeviceName = txt_DeviceName.Text;
                        device.Description = txt_Description.Text;

                        Device_Manager.Update(room, device);

                        if (check_MultipleTags.Checked)
                        {
                            device.Tags.Clear();
                            for (int i = 1; i <= txt_NumberofTags.Value; i++)
                            {
                                Tag tag = new Tag();
                                tag.TagId = i;
                                tag.TagName = string.Format("{0}{1}", txt_TagPrefix.Text, i);
                                tag.Topic = string.Format("{0}{1}", txt_TopicPrefix.Text, i);
                                tag.QoS = byte.Parse(cbox_QoS.SelectedItem.ToString());
                                tag.Description = string.Format("{0}{1}", txt_Description.Text, i);
                                tag.Retain = check_Retain.Checked;
                                tag.IsInput = check_IsInput.Checked;
                                device.Tags.Add(tag);
                            }
                        }

                        if (eventDeviceChanged != null) eventDeviceChanged(device);

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void check_MultipleTags_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txt_NumberofTags.Enabled = check_MultipleTags.Checked;
                txt_TagPrefix.Enabled = check_MultipleTags.Checked;
                txt_TopicPrefix.Enabled = check_MultipleTags.Checked;
                cbox_QoS.Enabled = check_MultipleTags.Checked;
                check_Retain.Enabled = check_MultipleTags.Checked;
                check_IsInput.Enabled = check_MultipleTags.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_GroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
