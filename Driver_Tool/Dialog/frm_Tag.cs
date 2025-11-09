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

namespace Driver_Tool.Dialog
{
    public delegate void EventTagChanged(Tag tag);
    public partial class frm_Tag : Form
    {
        private Building building;
        private Floor floor;
        private Room room;
        private Device device;
        private Tag tag;
        public EventTagChanged eventTagChanged = null;

        public frm_Tag(Building buildingParam, Floor floorParam, Room roomParam, Device deviceParam, Tag tagParam = null)
        {
            InitializeComponent();

            building = buildingParam;
            floor = floorParam;
            room = roomParam;
            device = deviceParam;
            tag = tagParam;
        }

        private void frm_Tag_Load(object sender, EventArgs e)
        {
            try
            {
                txt_Floor.Text = floor.FloorName;
                txt_Room.Text = room.RoomName;
                txt_Device.Text = device.DeviceName;

                txt_Floor.Enabled = false;
                txt_Room.Enabled = false;
                txt_Device.Enabled = false;

                if (tag == null)
                {
                    this.Text = "Add Tag";
                    cbox_QoS.SelectedIndex = 1;
                }
                else
                {
                    this.Text = "Edit Tag";
                    txt_TagName.Text = tag.TagName;
                    txt_Topic.Text = tag.Topic;
                    cbox_QoS.SelectedItem = string.Format("{0}", tag.QoS);
                    check_Retain.Checked = tag.Retain;
                    check_IsInput.Checked = tag.IsInput;

                    radiobtn_Scale.Checked = tag.IsScaled;
                    txt_RawFull.Value = tag.AImax;
                    txt_RawZero.Value = tag.AImin;
                    txt_EngFull.Value = (decimal)tag.RLmax;
                    txt_EngZero.Value = (decimal)tag.RLmin;
                    txt_Description.Text = tag.Description;
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
                if ((string.IsNullOrEmpty(cbox_QoS.Text) || string.IsNullOrWhiteSpace(cbox_QoS.Text)))
                    errorProvider1.SetError(cbox_QoS, "Quality of Service is empty");
                else
                {
                    errorProvider1.Clear();
                    if (tag == null)
                    {
                        Tag newTg = new Tag();
                        newTg.TagId = device.Tags.Count + 1;
                        newTg.TagName = txt_TagName.Text;
                        newTg.Topic = txt_Topic.Text;
                        newTg.QoS = byte.Parse(cbox_QoS.SelectedItem.ToString());
                        newTg.Retain = check_Retain.Checked;
                        newTg.IsInput = check_IsInput.Checked;
                        newTg.Description = txt_Description.Text;
                        newTg.IsScaled = radiobtn_Scale.Checked;
                        if (radiobtn_Scale.Checked)
                        {
                            newTg.AImin = (ushort)txt_RawZero.Value;
                            newTg.AImax = (ushort)txt_RawFull.Value;
                            newTg.RLmin = (float)txt_EngZero.Value;
                            newTg.RLmax = (float)txt_EngFull.Value;
                        }
                        Tag_Manager.Add(device, newTg);
                        if (eventTagChanged != null) eventTagChanged(newTg);
                    }
                    else
                    {
                        tag.TagName = txt_TagName.Text;
                        tag.Topic = txt_Topic.Text;
                        tag.Description = txt_Description.Text;
                        tag.QoS = byte.Parse(cbox_QoS.SelectedItem.ToString());
                        tag.Retain = check_Retain.Checked;
                        tag.IsInput = check_IsInput.Checked;
                        tag.IsScaled = radiobtn_Scale.Checked;
                        if (radiobtn_Scale.Checked)
                        {
                            tag.AImin = (ushort)txt_RawZero.Value;
                            tag.AImax = (ushort)txt_RawFull.Value;
                            tag.RLmin = (float)txt_EngZero.Value;
                            tag.RLmax = (float)txt_EngFull.Value;
                        }
                        Tag_Manager.Update(device, tag);
                        if (eventTagChanged != null) eventTagChanged(tag);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
