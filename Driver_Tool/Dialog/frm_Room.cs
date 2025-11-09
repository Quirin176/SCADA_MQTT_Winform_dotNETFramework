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
    public delegate void EventRoomChanged(Room room);

    public partial class frm_Room : Form
    {
        private Building building = null;
        private Floor floor = null;
        private Room room = null;
        public EventRoomChanged eventRoomChanged = null;

        public frm_Room(Building buildingParam, Floor floorParam, Room roomParam = null)
        {
            InitializeComponent();
            this.building = buildingParam;
            this.floor = floorParam;
            this.room = roomParam;
        }

        private void frm_Room_Load(object sender, EventArgs e)
        {
            try
            {
                txt_FloorName.Text = this.floor.FloorName;
                txt_FloorName.Enabled = false;

                if (this.room == null)
                {
                    this.Text = "Add Room";
                }
                else
                {
                    this.Text = "Edit Room";
                    txt_RoomName.Text = room.RoomName;
                    txt_Description.Text = room.Description;
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
                if (string.IsNullOrEmpty(txt_RoomName.Text)
                               || string.IsNullOrWhiteSpace(txt_RoomName.Text))
                    errorProvider1.SetError(txt_RoomName, "The Room Name is empty");
                else
                {
                    errorProvider1.Clear();
                    if (room == null)
                    {
                        Room dvNew = new Room();
                        dvNew.RoomId = floor.Rooms.Count + 1;
                        dvNew.RoomName = txt_RoomName.Text;
                        dvNew.Description = txt_Description.Text;
                        dvNew.Devices = new List<Device>();
                        Room_Manager.Add(floor, dvNew);
                        if (eventRoomChanged != null) eventRoomChanged(dvNew);
                    }
                    else
                    {
                        room.RoomName = txt_RoomName.Text;
                        room.Description = txt_Description.Text;
                        Room_Manager.Update(floor, room);
                        if (eventRoomChanged != null) eventRoomChanged(room);
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
