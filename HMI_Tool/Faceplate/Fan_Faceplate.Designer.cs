namespace HMI_Tool.Faceplate
{
    partial class Fan_Faceplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.disp_Status = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.disp_Power = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.setpointControl1 = new HMI_Tool.SetpointControl.SetpointControl();
            this.btn_Switch = new HMI_Tool.Toggle_Button.Toggle_Button();
            this.disp_Speed = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(116, 519);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Schedule";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(133, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(57, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Switch Local / Remote";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Remote";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(102, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "Control Mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(80, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Man";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(217, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Auto";
            // 
            // disp_Status
            // 
            this.disp_Status.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorOFF = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorON = System.Drawing.SystemColors.Control;
            this.disp_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disp_Status.Location = new System.Drawing.Point(121, 305);
            this.disp_Status.Name = "disp_Status";
            this.disp_Status.Size = new System.Drawing.Size(98, 27);
            this.disp_Status.TabIndex = 24;
            this.disp_Status.TagName = null;
            this.disp_Status.Text = "N/A";
            this.disp_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Status.Unit = null;
            this.disp_Status.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(93, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Control Manual";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(80, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Off";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(217, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "On";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(137, 436);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 25);
            this.label12.TabIndex = 33;
            this.label12.Text = "Fault";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(57, 355);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 25);
            this.label13.TabIndex = 34;
            this.label13.Text = "Power";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(209, 355);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 25);
            this.label14.TabIndex = 36;
            this.label14.Text = "Speed";
            // 
            // disp_Power
            // 
            this.disp_Power.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Power.BackcolorOFF = System.Drawing.SystemColors.Control;
            this.disp_Power.BackcolorON = System.Drawing.SystemColors.Control;
            this.disp_Power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Power.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disp_Power.Location = new System.Drawing.Point(31, 380);
            this.disp_Power.Name = "disp_Power";
            this.disp_Power.Size = new System.Drawing.Size(93, 40);
            this.disp_Power.TabIndex = 39;
            this.disp_Power.TagName = null;
            this.disp_Power.Text = "N/A";
            this.disp_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Power.Unit = null;
            this.disp_Power.Value = null;
            // 
            // setpointControl1
            // 
            this.setpointControl1.BackColor = System.Drawing.Color.Transparent;
            this.setpointControl1.ButtonBackColor = System.Drawing.Color.Transparent;
            this.setpointControl1.ButtonForeColor = System.Drawing.Color.Gray;
            this.setpointControl1.Location = new System.Drawing.Point(130, 380);
            this.setpointControl1.MaxValue = 1D;
            this.setpointControl1.MinValue = 0D;
            this.setpointControl1.Name = "setpointControl1";
            this.setpointControl1.Privilege = 0;
            this.setpointControl1.Size = new System.Drawing.Size(30, 40);
            this.setpointControl1.Step = 0.1D;
            this.setpointControl1.TabIndex = 40;
            this.setpointControl1.TagName = null;
            this.setpointControl1.TextboxBackColor = System.Drawing.Color.White;
            this.setpointControl1.TextboxForeColor = System.Drawing.Color.Black;
            this.setpointControl1.UserPrivilege = 0;
            this.setpointControl1.Value = 0D;
            // 
            // btn_Switch
            // 
            this.btn_Switch.Location = new System.Drawing.Point(138, 220);
            this.btn_Switch.Name = "btn_Switch";
            this.btn_Switch.OffBackColor = System.Drawing.Color.LightCoral;
            this.btn_Switch.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Switch.OnBackColor = System.Drawing.Color.LimeGreen;
            this.btn_Switch.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Switch.Privilege = 1;
            this.btn_Switch.Size = new System.Drawing.Size(60, 30);
            this.btn_Switch.TabIndex = 32;
            this.btn_Switch.TagName = null;
            this.btn_Switch.UserPrivilege = 1;
            this.btn_Switch.Value = "false";
            this.btn_Switch.Click += new System.EventHandler(this.btn_Switch_Click);
            // 
            // disp_Speed
            // 
            this.disp_Speed.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Speed.BackcolorOFF = System.Drawing.Color.Orange;
            this.disp_Speed.BackcolorON = System.Drawing.Color.DarkGreen;
            this.disp_Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Speed.ForeColor = System.Drawing.Color.Black;
            this.disp_Speed.Location = new System.Drawing.Point(187, 388);
            this.disp_Speed.Name = "disp_Speed";
            this.disp_Speed.Size = new System.Drawing.Size(120, 27);
            this.disp_Speed.TabIndex = 41;
            this.disp_Speed.TagName = null;
            this.disp_Speed.Text = "hmiDisplay1";
            this.disp_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Speed.Unit = null;
            this.disp_Speed.Value = null;
            // 
            // Fan_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(332, 553);
            this.Controls.Add(this.disp_Speed);
            this.Controls.Add(this.setpointControl1);
            this.Controls.Add(this.disp_Power);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_Switch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.disp_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Fan_Faceplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fan_Faceplate";
            this.Load += new System.EventHandler(this.Fan_Faceplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HMI_Edition.HMIDisplay.HMIDisplay disp_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Toggle_Button.Toggle_Button btn_Switch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Power;
        private SetpointControl.SetpointControl setpointControl1;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Speed;
    }
}