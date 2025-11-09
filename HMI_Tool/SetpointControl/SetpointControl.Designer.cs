namespace HMI_Tool.SetpointControl
{
    partial class SetpointControl
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
            this.btn_Down = new HMI_Tool.ButtonTriangle.ButtonTriangle();
            this.btn_Up = new HMI_Tool.ButtonTriangle.ButtonTriangle();
            this.SuspendLayout();
            // 
            // btn_Down
            // 
            this.btn_Down.Direction = HMI_Tool.ButtonTriangle.ButtonTriangle.TriangleDirection.Down;
            this.btn_Down.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Down.Location = new System.Drawing.Point(0, 20);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(30, 20);
            this.btn_Down.TabIndex = 2;
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Direction = HMI_Tool.ButtonTriangle.ButtonTriangle.TriangleDirection.Up;
            this.btn_Up.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Up.Location = new System.Drawing.Point(0, 0);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(30, 20);
            this.btn_Up.TabIndex = 0;
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // SetpointControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Name = "SetpointControl";
            this.Size = new System.Drawing.Size(30, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonTriangle.ButtonTriangle btn_Up;
        private ButtonTriangle.ButtonTriangle btn_Down;
    }
}
