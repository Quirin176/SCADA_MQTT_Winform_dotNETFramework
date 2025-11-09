namespace HMI_Tool.Faceplate
{
    partial class Motor_Faceplate
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
            this.disp_Speed = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Power = new HMI_Edition.HMIEditor.HMIEditor();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_ManualControl = new HMI_Tool.Toggle_Button.Toggle_Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.disp_Status = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.disp_Mode = new HMI_Edition.HMIDisplay.HMIDisplay();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Mode = new HMI_Tool.Toggle_Button.Toggle_Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // disp_Speed
            // 
            this.disp_Speed.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Speed.BackcolorOFF = System.Drawing.SystemColors.Control;
            this.disp_Speed.BackcolorON = System.Drawing.SystemColors.Control;
            this.disp_Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Speed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disp_Speed.Location = new System.Drawing.Point(98, 428);
            this.disp_Speed.Name = "disp_Speed";
            this.disp_Speed.Size = new System.Drawing.Size(100, 27);
            this.disp_Speed.TabIndex = 49;
            this.disp_Speed.TagName = null;
            this.disp_Speed.Text = " ";
            this.disp_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Speed.Unit = null;
            this.disp_Speed.Value = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(87, 397);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 25);
            this.label11.TabIndex = 48;
            this.label11.Text = "Fan Speed";
            // 
            // txt_Power
            // 
            this.txt_Power.BackColor = System.Drawing.Color.White;
            this.txt_Power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Power.ForeColor = System.Drawing.Color.Black;
            this.txt_Power.Location = new System.Drawing.Point(98, 358);
            this.txt_Power.Name = "txt_Power";
            this.txt_Power.Size = new System.Drawing.Size(100, 30);
            this.txt_Power.TabIndex = 47;
            this.txt_Power.TagName = null;
            this.txt_Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(92, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 25);
            this.label10.TabIndex = 46;
            this.label10.Text = "Fan Power";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(69, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 45;
            this.label7.Text = "Control Manual";
            // 
            // btn_ManualControl
            // 
            this.btn_ManualControl.Location = new System.Drawing.Point(111, 205);
            this.btn_ManualControl.Name = "btn_ManualControl";
            this.btn_ManualControl.OffBackColor = System.Drawing.Color.LimeGreen;
            this.btn_ManualControl.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ManualControl.OnBackColor = System.Drawing.Color.LightCoral;
            this.btn_ManualControl.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ManualControl.Privilege = 1;
            this.btn_ManualControl.Size = new System.Drawing.Size(80, 40);
            this.btn_ManualControl.TabIndex = 44;
            this.btn_ManualControl.TagName = null;
            this.btn_ManualControl.UserPrivilege = 1;
            this.btn_ManualControl.Value = "false";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "OFF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(197, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "ON";
            // 
            // disp_Status
            // 
            this.disp_Status.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorOFF = System.Drawing.SystemColors.Control;
            this.disp_Status.BackcolorON = System.Drawing.SystemColors.Control;
            this.disp_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disp_Status.Location = new System.Drawing.Point(98, 289);
            this.disp_Status.Name = "disp_Status";
            this.disp_Status.Size = new System.Drawing.Size(100, 27);
            this.disp_Status.TabIndex = 41;
            this.disp_Status.TagName = null;
            this.disp_Status.Text = " ";
            this.disp_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Status.Unit = null;
            this.disp_Status.Value = null;
            // 
            // disp_Mode
            // 
            this.disp_Mode.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Mode.BackcolorOFF = System.Drawing.Color.Orange;
            this.disp_Mode.BackcolorON = System.Drawing.Color.DarkGreen;
            this.disp_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Mode.ForeColor = System.Drawing.Color.White;
            this.disp_Mode.Location = new System.Drawing.Point(99, 132);
            this.disp_Mode.Name = "disp_Mode";
            this.disp_Mode.Size = new System.Drawing.Size(100, 27);
            this.disp_Mode.TabIndex = 40;
            this.disp_Mode.TagName = null;
            this.disp_Mode.Text = " ";
            this.disp_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Mode.Unit = null;
            this.disp_Mode.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(96, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "Schedule";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(111, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(80, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Control Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(78, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Control Mode";
            // 
            // btn_Mode
            // 
            this.btn_Mode.Location = new System.Drawing.Point(111, 43);
            this.btn_Mode.Name = "btn_Mode";
            this.btn_Mode.OffBackColor = System.Drawing.Color.LimeGreen;
            this.btn_Mode.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Mode.OnBackColor = System.Drawing.Color.LightCoral;
            this.btn_Mode.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Mode.Privilege = 1;
            this.btn_Mode.Size = new System.Drawing.Size(80, 40);
            this.btn_Mode.TabIndex = 35;
            this.btn_Mode.TagName = null;
            this.btn_Mode.UserPrivilege = 1;
            this.btn_Mode.Value = "false";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Auto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Man";
            // 
            // Motor_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 528);
            this.Controls.Add(this.disp_Speed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Power);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_ManualControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.disp_Status);
            this.Controls.Add(this.disp_Mode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Mode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Motor_Faceplate";
            this.Text = "Motor_Faceplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HMI_Edition.HMIDisplay.HMIDisplay disp_Speed;
        private System.Windows.Forms.Label label11;
        private HMI_Edition.HMIEditor.HMIEditor txt_Power;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private Toggle_Button.Toggle_Button btn_ManualControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Status;
        private HMI_Edition.HMIDisplay.HMIDisplay disp_Mode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Toggle_Button.Toggle_Button btn_Mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}