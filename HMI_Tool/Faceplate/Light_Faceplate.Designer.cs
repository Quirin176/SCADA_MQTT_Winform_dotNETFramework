namespace HMI_Tool.Faceplate
{
    partial class Light_Faceplate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Switch = new HMI_Tool.Toggle_Button.Toggle_Button();
            this.disp_Status = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.disp_Switch = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "OFF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(82, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Switch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(60, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Light Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(70, 187);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Schedule";
            // 
            // btn_Switch
            // 
            this.btn_Switch.Enabled = false;
            this.btn_Switch.Location = new System.Drawing.Point(80, 35);
            this.btn_Switch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Switch.Name = "btn_Switch";
            this.btn_Switch.OffBackColor = System.Drawing.Color.LightCoral;
            this.btn_Switch.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Switch.OnBackColor = System.Drawing.Color.LimeGreen;
            this.btn_Switch.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Switch.Privilege = 1;
            this.btn_Switch.Size = new System.Drawing.Size(60, 32);
            this.btn_Switch.TabIndex = 9;
            this.btn_Switch.TagName = null;
            this.btn_Switch.UserPrivilege = 0;
            this.btn_Switch.Value = "false";
            this.btn_Switch.Click += new System.EventHandler(this.btn_Switch_Click);
            // 
            // disp_Status
            // 
            this.disp_Status.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorOFF = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorON = System.Drawing.SystemColors.Control;
            this.disp_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disp_Status.Location = new System.Drawing.Point(71, 150);
            this.disp_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.disp_Status.Name = "disp_Status";
            this.disp_Status.Size = new System.Drawing.Size(76, 22);
            this.disp_Status.TabIndex = 15;
            this.disp_Status.TagName = null;
            this.disp_Status.Text = "Status";
            this.disp_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Status.Unit = null;
            this.disp_Status.Value = null;
            // 
            // disp_Switch
            // 
            this.disp_Switch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.disp_Switch.BackcolorOFF = System.Drawing.Color.Orange;
            this.disp_Switch.BackcolorON = System.Drawing.Color.DarkGreen;
            this.disp_Switch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Switch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Switch.ForeColor = System.Drawing.Color.White;
            this.disp_Switch.Location = new System.Drawing.Point(71, 81);
            this.disp_Switch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.disp_Switch.Name = "disp_Switch";
            this.disp_Switch.Size = new System.Drawing.Size(76, 22);
            this.disp_Switch.TabIndex = 16;
            this.disp_Switch.TagName = null;
            this.disp_Switch.Text = "Switch";
            this.disp_Switch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Switch.Unit = null;
            this.disp_Switch.Value = null;
            // 
            // Light_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(223, 266);
            this.Controls.Add(this.disp_Switch);
            this.Controls.Add(this.disp_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Switch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Light_Faceplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faceplate";
            this.Load += new System.EventHandler(this.Light_Faceplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Toggle_Button.Toggle_Button btn_Switch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Status;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Switch;
    }
}