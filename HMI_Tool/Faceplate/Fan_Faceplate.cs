using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Faceplate
{
    public partial class Fan_Faceplate : Form
    {
        private string FanName { get; set; }
        private string FanTopic { get; set; }
        private string SwitchTopic { get; set; }
        private string PowerTopic { get; set; }
        private string SpeedTopic { get; set; }
        //private string SpeedData {  get; set; }

        public Fan_Faceplate(string fanName, string fanTopic, string switchTopic, string powerTopic, string speedTopic/*, string speedData*/)
        {
            InitializeComponent();

            FanName = fanName;
            FanTopic = fanTopic;
            SwitchTopic = switchTopic;
            PowerTopic = powerTopic;
            SpeedTopic = speedTopic;
            //SpeedData = speedData;

            btn_Switch.TagName = SwitchTopic;
            setpointControl1.TagName = PowerTopic;
            disp_Power.TagName = PowerTopic;
            disp_Speed.TagName = SpeedTopic;

            btn_Switch.UserPrivilege = 8;
            disp_Status.TagName = FanTopic;
        }

        private void Fan_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = FanName;

            if (disp_Status.Value.ToString() == "TRUE" || disp_Status.Value.ToString() == "True")
            {
                btn_Switch.Value = "true";  // Set the switch to ON
            }
            else if (disp_Status.Value.ToString() == "FALSE" || disp_Status.Value.ToString() == "False")
            {
                btn_Switch.Value = "false";  // Set the switch to OFF
            }
        }

        private void btn_Switch_Click(object sender, EventArgs e)
        {
            if (btn_Switch.Value.Trim().ToLower() == "1" || btn_Switch.Value.Trim().ToLower() == "true")
            {
                disp_Status.Text = "True";
                disp_Status.ForeColor = Color.White;
                disp_Status.BackColor = Color.Green;
            }
            else
            {
                disp_Status.Text = "False";
                disp_Status.ForeColor = Color.White;
                disp_Status.BackColor = Color.Orange;
            }

        }
    }
}
