namespace HMI_Tool.LSN50_LoRa_Sensor
{
    partial class LSN50_LoRa_Sensor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disp_Datetime = new HMI_Edition.HMIDisplay.LSN50_LoRa_Display();
            this.disp_Humidity = new HMI_Edition.HMIDisplay.LSN50_LoRa_Display();
            this.disp_Temp = new HMI_Edition.HMIDisplay.LSN50_LoRa_Display();
            this.disp_Battery = new HMI_Edition.HMIDisplay.LSN50_LoRa_Display();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.Controls.Add(this.disp_Datetime);
            this.groupBox1.Controls.Add(this.disp_Humidity);
            this.groupBox1.Controls.Add(this.disp_Temp);
            this.groupBox1.Controls.Add(this.disp_Battery);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Name";
            // 
            // disp_Datetime
            // 
            this.disp_Datetime.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Datetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Datetime.Data = "Data_time";
            this.disp_Datetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Datetime.ForeColor = System.Drawing.Color.Black;
            this.disp_Datetime.Location = new System.Drawing.Point(8, 30);
            this.disp_Datetime.Name = "disp_Datetime";
            this.disp_Datetime.Size = new System.Drawing.Size(261, 27);
            this.disp_Datetime.TabIndex = 5;
            this.disp_Datetime.TagName = "";
            this.disp_Datetime.Text = "N/A";
            this.disp_Datetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Datetime.Unit = null;
            this.disp_Datetime.Value = null;
            // 
            // disp_Humidity
            // 
            this.disp_Humidity.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Humidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Humidity.Data = "Hum_SHT31";
            this.disp_Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Humidity.ForeColor = System.Drawing.Color.Black;
            this.disp_Humidity.Location = new System.Drawing.Point(125, 150);
            this.disp_Humidity.Name = "disp_Humidity";
            this.disp_Humidity.Size = new System.Drawing.Size(144, 27);
            this.disp_Humidity.TabIndex = 6;
            this.disp_Humidity.TagName = "";
            this.disp_Humidity.Text = "N/A";
            this.disp_Humidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Humidity.Unit = "";
            this.disp_Humidity.Value = null;
            this.disp_Humidity.TextChanged += new System.EventHandler(this.disp_Humidity_TextChanged);
            // 
            // disp_Temp
            // 
            this.disp_Temp.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Temp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Temp.Data = "TempC_SHT31";
            this.disp_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Temp.ForeColor = System.Drawing.Color.Black;
            this.disp_Temp.Location = new System.Drawing.Point(125, 110);
            this.disp_Temp.Name = "disp_Temp";
            this.disp_Temp.Size = new System.Drawing.Size(144, 27);
            this.disp_Temp.TabIndex = 5;
            this.disp_Temp.TagName = "";
            this.disp_Temp.Text = "N/A";
            this.disp_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Temp.Unit = "";
            this.disp_Temp.Value = null;
            this.disp_Temp.TextChanged += new System.EventHandler(this.disp_Temp_TextChanged);
            // 
            // disp_Battery
            // 
            this.disp_Battery.BackColor = System.Drawing.SystemColors.Control;
            this.disp_Battery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disp_Battery.Data = "BatV";
            this.disp_Battery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disp_Battery.ForeColor = System.Drawing.Color.Black;
            this.disp_Battery.Location = new System.Drawing.Point(125, 70);
            this.disp_Battery.Name = "disp_Battery";
            this.disp_Battery.Size = new System.Drawing.Size(144, 27);
            this.disp_Battery.TabIndex = 4;
            this.disp_Battery.TagName = "";
            this.disp_Battery.Text = "N/A";
            this.disp_Battery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disp_Battery.Unit = "";
            this.disp_Battery.Value = null;
            this.disp_Battery.TextChanged += new System.EventHandler(this.disp_Battery_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Humidity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Battery";
            // 
            // LSN50_LoRa_Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Name = "LSN50_LoRa_Sensor";
            this.Size = new System.Drawing.Size(275, 190);
            this.Load += new System.EventHandler(this.LSN50_LoRa_Sensor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private HMI_Edition.HMIDisplay.LSN50_LoRa_Display disp_Datetime;
        private HMI_Edition.HMIDisplay.LSN50_LoRa_Display disp_Humidity;
        private HMI_Edition.HMIDisplay.LSN50_LoRa_Display disp_Temp;
        private HMI_Edition.HMIDisplay.LSN50_LoRa_Display disp_Battery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
