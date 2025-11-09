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
    public delegate void EventFloorChanged(Floor floor);
    public partial class frm_Floor : Form
    {
        private Building building = null;
        private Floor floor = null;
        public EventFloorChanged eventFloorChanged = null;

        public frm_Floor(Building buildingParam, Floor floorParam = null)
        {
            InitializeComponent();
            this.building = buildingParam;
            this.floor = floorParam;
        }

        private void frm_Device_Load(object sender, EventArgs e)
        {
            try
            {
                if (floor == null)
                {
                    this.Text = "Add Floor";
                }
                else
                {
                    this.Text = "Edit Floor";
                    txt_FloorName.Text = floor.FloorName;
                    txt_Description.Text = floor.Description;
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
                if (string.IsNullOrEmpty(txt_FloorName.Text)
                               || string.IsNullOrWhiteSpace(txt_FloorName.Text))
                    errorProvider1.SetError(txt_FloorName, "The Floor Name is empty");
                else
                {
                    errorProvider1.Clear();
                    if (floor == null)
                    {
                        Floor dvNew = new Floor();
                        dvNew.FloorId = building.Floors.Count + 1;
                        dvNew.FloorName = txt_FloorName.Text;
                        dvNew.Description = txt_Description.Text;
                        dvNew.Rooms = new List<Room>();
                        Floor_Manager.Add(building, dvNew);
                        if (eventFloorChanged != null) eventFloorChanged(dvNew);
                    }
                    else
                    {
                        floor.FloorName = txt_FloorName.Text;
                        floor.Description = txt_Description.Text;
                        Floor_Manager.Update(building, floor);
                        if (eventFloorChanged != null) eventFloorChanged(floor);
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
