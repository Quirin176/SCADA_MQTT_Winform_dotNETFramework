using Driver_Tool.Manager;
using MQTT_Protocol.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver_Tool.Dialog
{
    public delegate void EventBuildingChanged(Building building);
    public partial class frm_Building : Form
    {
        public EventBuildingChanged eventBuildingChanged = null;
        private Building building = null;

        public frm_Building(Building buildingParam = null)
        {
            InitializeComponent();
            this.building = buildingParam;
        }

        private void frm_Channel_Load(object sender, EventArgs e)
        {
            try
            {
                if (building == null)
                {
                    this.Text = "Add Building";
                }
                else
                {
                    this.Text = "Edit Building";
                    this.txt_BuildingName.Text = building.BuildingName;
                    txt_Description.Text = building.BuildingName;
                    DIEthernet die = (DIEthernet)building;
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
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txt_BuildingName.Text)
                               || string.IsNullOrWhiteSpace(txt_BuildingName.Text))
                {
                    errorProvider1.SetError(txt_BuildingName, "The Building name is empty");
                    return;
                }
                errorProvider1.Clear();

                DIEthernet die = new DIEthernet();
                die.BuildingName = txt_BuildingName.Text;
                if (building == null)
                {
                    die.BuildingId = Building_Manager.Buildings.Count + 1;
                    die.Floors = new List<Floor>();
                    Building_Manager.Add(die);
                    if (eventBuildingChanged != null) eventBuildingChanged(die);
                }
                else
                {
                    die.BuildingId = building.BuildingId;
                    die.Floors = building.Floors;
                    Building_Manager.Update(die);
                    if (eventBuildingChanged != null) eventBuildingChanged(die);
                    this.DialogResult = DialogResult.OK;
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
