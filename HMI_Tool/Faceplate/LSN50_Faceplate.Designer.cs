namespace HMI_Tool.Faceplate
{
    partial class LSN50_Faceplate
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_TempLowLow = new System.Windows.Forms.TextBox();
            this.txt_TempLow = new System.Windows.Forms.TextBox();
            this.txt_TempHighHigh = new System.Windows.Forms.TextBox();
            this.txt_TempHigh = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_HumLowLow = new System.Windows.Forms.TextBox();
            this.txt_HumLow = new System.Windows.Forms.TextBox();
            this.txt_HumHighHigh = new System.Windows.Forms.TextBox();
            this.txt_HumHigh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_SetAsDefault = new System.Windows.Forms.Button();
            this.btn_UseDefaultSettings = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ALARM SETTINGS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "HighHigh Alarm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "High Alarm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightBlue;
            this.label4.Location = new System.Drawing.Point(10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Low Alarm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(10, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "LowLow Alarm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_TempLowLow);
            this.groupBox1.Controls.Add(this.txt_TempLow);
            this.groupBox1.Controls.Add(this.txt_TempHighHigh);
            this.groupBox1.Controls.Add(this.txt_TempHigh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.Location = new System.Drawing.Point(17, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 210);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // txt_TempLowLow
            // 
            this.txt_TempLowLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TempLowLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TempLowLow.ForeColor = System.Drawing.Color.Blue;
            this.txt_TempLowLow.Location = new System.Drawing.Point(170, 158);
            this.txt_TempLowLow.Name = "txt_TempLowLow";
            this.txt_TempLowLow.Size = new System.Drawing.Size(120, 27);
            this.txt_TempLowLow.TabIndex = 14;
            this.txt_TempLowLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TempLow
            // 
            this.txt_TempLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TempLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TempLow.ForeColor = System.Drawing.Color.LightBlue;
            this.txt_TempLow.Location = new System.Drawing.Point(170, 118);
            this.txt_TempLow.Name = "txt_TempLow";
            this.txt_TempLow.Size = new System.Drawing.Size(120, 27);
            this.txt_TempLow.TabIndex = 13;
            this.txt_TempLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TempHighHigh
            // 
            this.txt_TempHighHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TempHighHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TempHighHigh.ForeColor = System.Drawing.Color.Red;
            this.txt_TempHighHigh.Location = new System.Drawing.Point(170, 38);
            this.txt_TempHighHigh.Name = "txt_TempHighHigh";
            this.txt_TempHighHigh.Size = new System.Drawing.Size(120, 27);
            this.txt_TempHighHigh.TabIndex = 12;
            this.txt_TempHighHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TempHigh
            // 
            this.txt_TempHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TempHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TempHigh.ForeColor = System.Drawing.Color.Orange;
            this.txt_TempHigh.Location = new System.Drawing.Point(170, 78);
            this.txt_TempHigh.Name = "txt_TempHigh";
            this.txt_TempHigh.Size = new System.Drawing.Size(120, 27);
            this.txt_TempHigh.TabIndex = 11;
            this.txt_TempHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_HumLowLow);
            this.groupBox2.Controls.Add(this.txt_HumLow);
            this.groupBox2.Controls.Add(this.txt_HumHighHigh);
            this.groupBox2.Controls.Add(this.txt_HumHigh);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox2.Location = new System.Drawing.Point(333, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 210);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Humidity";
            // 
            // txt_HumLowLow
            // 
            this.txt_HumLowLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HumLowLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HumLowLow.ForeColor = System.Drawing.Color.Blue;
            this.txt_HumLowLow.Location = new System.Drawing.Point(170, 158);
            this.txt_HumLowLow.Name = "txt_HumLowLow";
            this.txt_HumLowLow.Size = new System.Drawing.Size(120, 27);
            this.txt_HumLowLow.TabIndex = 18;
            this.txt_HumLowLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_HumLow
            // 
            this.txt_HumLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HumLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HumLow.ForeColor = System.Drawing.Color.LightBlue;
            this.txt_HumLow.Location = new System.Drawing.Point(170, 118);
            this.txt_HumLow.Name = "txt_HumLow";
            this.txt_HumLow.Size = new System.Drawing.Size(120, 27);
            this.txt_HumLow.TabIndex = 17;
            this.txt_HumLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_HumHighHigh
            // 
            this.txt_HumHighHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HumHighHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HumHighHigh.ForeColor = System.Drawing.Color.Red;
            this.txt_HumHighHigh.Location = new System.Drawing.Point(170, 38);
            this.txt_HumHighHigh.Name = "txt_HumHighHigh";
            this.txt_HumHighHigh.Size = new System.Drawing.Size(120, 27);
            this.txt_HumHighHigh.TabIndex = 16;
            this.txt_HumHighHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_HumHigh
            // 
            this.txt_HumHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HumHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HumHigh.ForeColor = System.Drawing.Color.Orange;
            this.txt_HumHigh.Location = new System.Drawing.Point(170, 78);
            this.txt_HumHigh.Name = "txt_HumHigh";
            this.txt_HumHigh.Size = new System.Drawing.Size(120, 27);
            this.txt_HumHigh.TabIndex = 15;
            this.txt_HumHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "HighHigh Alarm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(10, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "High Alarm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightBlue;
            this.label8.Location = new System.Drawing.Point(10, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Low Alarm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(10, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "LowLow Alarm";
            // 
            // btn_SetAsDefault
            // 
            this.btn_SetAsDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SetAsDefault.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_SetAsDefault.Location = new System.Drawing.Point(17, 37);
            this.btn_SetAsDefault.Name = "btn_SetAsDefault";
            this.btn_SetAsDefault.Size = new System.Drawing.Size(203, 35);
            this.btn_SetAsDefault.TabIndex = 11;
            this.btn_SetAsDefault.Text = "Set as Default";
            this.btn_SetAsDefault.UseVisualStyleBackColor = true;
            this.btn_SetAsDefault.Click += new System.EventHandler(this.btn_SetAsDefault_Click);
            // 
            // btn_UseDefaultSettings
            // 
            this.btn_UseDefaultSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UseDefaultSettings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_UseDefaultSettings.Location = new System.Drawing.Point(390, 37);
            this.btn_UseDefaultSettings.Name = "btn_UseDefaultSettings";
            this.btn_UseDefaultSettings.Size = new System.Drawing.Size(253, 35);
            this.btn_UseDefaultSettings.TabIndex = 12;
            this.btn_UseDefaultSettings.Text = "Use Default Settings";
            this.btn_UseDefaultSettings.UseVisualStyleBackColor = true;
            this.btn_UseDefaultSettings.Click += new System.EventHandler(this.btn_UseDefaultSettings_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(543, 310);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 30);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // LSN50_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(657, 350);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_UseDefaultSettings);
            this.Controls.Add(this.btn_SetAsDefault);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LSN50_Faceplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LSN50_Faceplate_FormClosing);
            this.Load += new System.EventHandler(this.LSN50_Faceplate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TempHighHigh;
        private System.Windows.Forms.TextBox txt_TempHigh;
        private System.Windows.Forms.TextBox txt_TempLowLow;
        private System.Windows.Forms.TextBox txt_TempLow;
        private System.Windows.Forms.TextBox txt_HumLowLow;
        private System.Windows.Forms.TextBox txt_HumLow;
        private System.Windows.Forms.TextBox txt_HumHighHigh;
        private System.Windows.Forms.TextBox txt_HumHigh;
        private System.Windows.Forms.Button btn_SetAsDefault;
        private System.Windows.Forms.Button btn_UseDefaultSettings;
        private System.Windows.Forms.Button btn_OK;
    }
}