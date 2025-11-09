namespace HMI_Tool.LSN50_LoRa_Sensor
{
    partial class ExportData
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pick_EndDate = new System.Windows.Forms.DateTimePicker();
            this.pick_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(386, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Start Date";
            // 
            // pick_EndDate
            // 
            this.pick_EndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pick_EndDate.Location = new System.Drawing.Point(289, 67);
            this.pick_EndDate.Name = "pick_EndDate";
            this.pick_EndDate.Size = new System.Drawing.Size(280, 22);
            this.pick_EndDate.TabIndex = 17;
            // 
            // pick_StartDate
            // 
            this.pick_StartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pick_StartDate.Location = new System.Drawing.Point(3, 67);
            this.pick_StartDate.MinDate = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.pick_StartDate.Name = "pick_StartDate";
            this.pick_StartDate.Size = new System.Drawing.Size(280, 22);
            this.pick_StartDate.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Report Sensor Nodes Data";
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Location = new System.Drawing.Point(592, 44);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(180, 45);
            this.btn_Export.TabIndex = 13;
            this.btn_Export.Text = "Export to Excel";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // ExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pick_EndDate);
            this.Controls.Add(this.pick_StartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Export);
            this.Name = "ExportData";
            this.Size = new System.Drawing.Size(775, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker pick_EndDate;
        private System.Windows.Forms.DateTimePicker pick_StartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Export;
    }
}
