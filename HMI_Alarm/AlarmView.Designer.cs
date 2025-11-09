namespace HMI_Alarm
{
    partial class AlarmView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Acknowledge = new System.Windows.Forms.Label();
            this.btn_Settings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1394, 618);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btn_Acknowledge
            // 
            this.btn_Acknowledge.AutoSize = true;
            this.btn_Acknowledge.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Acknowledge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Acknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Acknowledge.Location = new System.Drawing.Point(3, 4);
            this.btn_Acknowledge.Name = "btn_Acknowledge";
            this.btn_Acknowledge.Size = new System.Drawing.Size(48, 22);
            this.btn_Acknowledge.TabIndex = 24;
            this.btn_Acknowledge.Text = "ACK";
            this.btn_Acknowledge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Acknowledge_MouseClick);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.AutoSize = true;
            this.btn_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Settings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Settings.Location = new System.Drawing.Point(1252, 4);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(145, 22);
            this.btn_Settings.TabIndex = 25;
            this.btn_Settings.Text = "Alarms Settings";
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Acknowledge);
            this.Name = "AlarmView";
            this.Size = new System.Drawing.Size(1400, 650);
            this.Load += new System.EventHandler(this.AlarmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label btn_Acknowledge;
        private System.Windows.Forms.Label btn_Settings;
    }
}
