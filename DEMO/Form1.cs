using MQTT_Protocol.Devices;
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
using HMI_Tool.LSN50_LoRa_Sensor;
using System.Runtime.InteropServices;

namespace DEMO
{
    public partial class Form1 : Form
    {
        private static bool isTagsInitialized = false;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _Role;
        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private int _userPrivilege;
        public int UserPrivilege
        {
            get { return _userPrivilege; }
            set { _userPrivilege = value; }
        }

        public Form1()
        {
            if (!isTagsInitialized)
            {
                InitializeTags();
                isTagsInitialized = true;
            }

            InitializeComponent();

            //MQTT_Service.ConnectionStatusChanged += OnConnectionStatusChanged;

            SetUserNameForControls(this.Controls, _userName);
            SetUserPrivilegeForControls(this.Controls, _userPrivilege);

            this.Form1_Border.MouseDown += PanelTop_MouseDown;
            btn_FormClose.MouseEnter += (s, e) => btn_FormClose.BackColor = Color.Red;
            btn_FormClose.MouseLeave += (s, e) => btn_FormClose.BackColor = Color.WhiteSmoke;
        }

        private void InitializeTags()
        {
            List<Building> buildings = Driver_Tool.Manager.Building_Manager.GetBuildings();
            MQTT_Service.InitializeService(buildings);

            MQTT_Service.eventCatchExceptionDelegate += new CatchExceptionDelegate((ex) =>
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

            MQTT_Service.Start();
        }

        //private void OnConnectionStatusChanged(string buildingName, bool isConnected)
        //{
        //    if (!isConnected)
        //    {
        //        MQTT_Service.Stop();
        //        txt_ConnectionStatus.Text = $"{buildingName}: Disconnected";
        //    }
        //    else
        //    {
        //        txt_ConnectionStatus.Text = $"{buildingName}: Connected";
        //    }
        //}

        public void SetUserNameForControls(Control.ControlCollection controls, string userName)
        {
            txt_UserName.Text = _userName + "  (" + _Role + ")";

            foreach (Control control in controls)
            {
                // Check if the control has the 'UserName' property
                var propertyInfo = control.GetType().GetProperty("UserName");
                if (propertyInfo != null && propertyInfo.PropertyType == typeof(string))
                {
                    // Set UserPrivilege
                    propertyInfo.SetValue(control, userName);
                }

                // If the control contains other controls, call this method recursively
                if (control.HasChildren)
                {
                    SetUserNameForControls(control.Controls, userName);
                }
            }
        }

        public void SetUserPrivilegeForControls(Control.ControlCollection controls, int userPrivilege)
        {
            //txt_Role.Text = _Role;

            foreach (Control control in controls)
            {
                // Check if the control has the 'UserPrivilege' property
                var propertyInfo = control.GetType().GetProperty("UserPrivilege");
                if (propertyInfo != null && propertyInfo.PropertyType == typeof(int))
                {
                    // Set UserPrivilege
                    propertyInfo.SetValue(control, userPrivilege);
                }

                // If the control contains other controls, call this method recursively
                if (control.HasChildren)
                {
                    SetUserPrivilegeForControls(control.Controls, userPrivilege);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUserNameForControls(this.Controls, _userName);
            SetUserPrivilegeForControls(this.Controls, _userPrivilege);
            //MessageBox.Show(UserName + " with privilege level " + UserPrivilege.ToString());

            txt_UserName.Text = _userName + "  (" + _Role + ")";

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txt_DateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy  HH:mm:ss");

            if (MQTT_Service.IsConnected)
            {
                txt_ConnectionStatus.Text = "Connected to: " + MQTT_Service.server;
            }
            else
            {
                txt_ConnectionStatus.Text = "Disconnected";
            }
        }

        private void btn_LogOut_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();

                frm_Login loginForm = new frm_Login(this);
                loginForm.Show();
            }
        }

        private void btn_FormClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll")]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
