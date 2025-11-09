using HMI_Tool.Led;
using MQTT_Protocol;
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
    public partial class Motor_Faceplate : Form
    {
        private string ToolTopic { get; set; }
        private string ToolModeTopic { get; set; }

        public Motor_Faceplate(string toolTopic, string toolModeTopic)
        {
            InitializeComponent();
            ToolTopic = toolTopic;
            ToolModeTopic = toolModeTopic;
        }
        private void Light_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = ToolTopic;
            //led_Single1.TagName = ToolTopic;
            //btn_Mode.TagName = ToolModeTopic;
        }

        private void btn_ON_MouseDown(object sender, MouseEventArgs e)
        {
            //led_ON.Value = true;
            MQTT_Service.PublishToTopic(ToolTopic, true);
        }

        private void btn_ON_MouseUp(object sender, MouseEventArgs e)
        {
            //led_ON.Value = false;
            MQTT_Service.PublishToTopic(ToolTopic, true);
        }

        private void btn_OFF_MouseDown(object sender, MouseEventArgs e)
        {
            //led_OFF.Value = true;
            MQTT_Service.PublishToTopic(ToolTopic, false);
        }

        private void btn_OFF_MouseUp(object sender, MouseEventArgs e)
        {
            //led_OFF.Value = false;
            MQTT_Service.PublishToTopic(ToolTopic, false);
        }

        private void btn_Mode_Click(object sender, EventArgs e)
        {
            //MQTT_Service.PublishToTopic(ToolModeTopic, btn_Mode.Value);
        }
    }
}
