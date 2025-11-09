using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace HMI_Tool.Faceplate
{
    public partial class Light_Faceplate : Form
    {
        private string LightName { get; set; }
        private string LightTopic { get; set; }
        private string SwitchTopic { get; set; }

        public Light_Faceplate(string lightName, string lightTopic, string switchTopic)
        {
            InitializeComponent();

            LightName = lightName;
            LightTopic = lightTopic;
            SwitchTopic = switchTopic;

            btn_Switch.TagName = SwitchTopic;
            disp_Switch.TagName = SwitchTopic;
            btn_Switch.UserPrivilege = 8;
            disp_Status.TagName = LightTopic;
        }

        private void Light_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = LightName;

            if (disp_Status.Value.ToString() == "TRUE" || disp_Status.Value.ToString() == "True")
            {
                btn_Switch.Value = "true";  // Set the switch to ON
            }
            else if (disp_Status.Value.ToString() == "FALSE" || disp_Status.Value.ToString() == "False")
            {
                btn_Switch.Value = "false";  // Set the switch to OFF
            }

            if (btn_Switch.Value.Trim().ToLower() == "1" || btn_Switch.Value.Trim().ToLower() == "true")
            {
                disp_Switch.Text = "True";
                disp_Switch.BackColor = Color.Green;
            }
            else
            {
                disp_Switch.Text = "False";
                disp_Switch.BackColor = Color.Orange;
            }
        }

        private void btn_Switch_Click(object sender, EventArgs e)
        {
            if (btn_Switch.Value.Trim().ToLower() == "1" || btn_Switch.Value.Trim().ToLower() == "true")
            {
                disp_Switch.Text = "True";
                disp_Switch.BackColor = Color.Green;
            }
            else
            {
                disp_Switch.Text = "False";
                disp_Switch.BackColor = Color.Orange;
            }
        }
    }
}
