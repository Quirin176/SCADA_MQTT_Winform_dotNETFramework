namespace Driver_Tool.Dialog
{
    partial class frm_Device
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.txt_DeviceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_FloorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_RoomName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_MultipleTags = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.check_Retain = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.check_IsInput = new System.Windows.Forms.CheckBox();
            this.cbox_QoS = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_NumberofTags = new System.Windows.Forms.NumericUpDown();
            this.txt_TagPrefix = new System.Windows.Forms.TextBox();
            this.txt_TopicPrefix = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NumberofTags)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(175, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "DEVICE SETTING";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(430, 526);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(125, 40);
            this.btn_Cancel.TabIndex = 28;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(299, 526);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(125, 40);
            this.btn_OK.TabIndex = 27;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Description.Location = new System.Drawing.Point(180, 405);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(380, 100);
            this.txt_Description.TabIndex = 26;
            // 
            // txt_DeviceName
            // 
            this.txt_DeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DeviceName.Location = new System.Drawing.Point(180, 122);
            this.txt_DeviceName.Name = "txt_DeviceName";
            this.txt_DeviceName.Size = new System.Drawing.Size(380, 27);
            this.txt_DeviceName.TabIndex = 25;
            this.txt_DeviceName.TextChanged += new System.EventHandler(this.txt_GroupName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Device Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txt_FloorName
            // 
            this.txt_FloorName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_FloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FloorName.Location = new System.Drawing.Point(180, 42);
            this.txt_FloorName.Name = "txt_FloorName";
            this.txt_FloorName.Size = new System.Drawing.Size(380, 27);
            this.txt_FloorName.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Floor Name:";
            // 
            // txt_RoomName
            // 
            this.txt_RoomName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RoomName.Location = new System.Drawing.Point(180, 82);
            this.txt_RoomName.Name = "txt_RoomName";
            this.txt_RoomName.Size = new System.Drawing.Size(380, 27);
            this.txt_RoomName.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Room Name:";
            // 
            // check_MultipleTags
            // 
            this.check_MultipleTags.AutoSize = true;
            this.check_MultipleTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_MultipleTags.Location = new System.Drawing.Point(39, 165);
            this.check_MultipleTags.Name = "check_MultipleTags";
            this.check_MultipleTags.Size = new System.Drawing.Size(186, 24);
            this.check_MultipleTags.TabIndex = 43;
            this.check_MultipleTags.Text = "Create Multiple Tags";
            this.check_MultipleTags.UseVisualStyleBackColor = true;
            this.check_MultipleTags.CheckedChanged += new System.EventHandler(this.check_MultipleTags_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Number of Tags:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "TagName Prefix:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "Topic Prefix:";
            // 
            // check_Retain
            // 
            this.check_Retain.AutoSize = true;
            this.check_Retain.Enabled = false;
            this.check_Retain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Retain.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.check_Retain.Location = new System.Drawing.Point(440, 324);
            this.check_Retain.Name = "check_Retain";
            this.check_Retain.Size = new System.Drawing.Size(85, 24);
            this.check_Retain.TabIndex = 59;
            this.check_Retain.Text = "Retain";
            this.check_Retain.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(358, 325);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 58;
            this.label14.Text = "Retain:";
            // 
            // check_IsInput
            // 
            this.check_IsInput.AutoSize = true;
            this.check_IsInput.Enabled = false;
            this.check_IsInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_IsInput.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.check_IsInput.Location = new System.Drawing.Point(180, 364);
            this.check_IsInput.Name = "check_IsInput";
            this.check_IsInput.Size = new System.Drawing.Size(93, 24);
            this.check_IsInput.TabIndex = 55;
            this.check_IsInput.Text = "Is Input";
            this.check_IsInput.UseVisualStyleBackColor = true;
            // 
            // cbox_QoS
            // 
            this.cbox_QoS.Enabled = false;
            this.cbox_QoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_QoS.FormattingEnabled = true;
            this.cbox_QoS.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cbox_QoS.Location = new System.Drawing.Point(180, 322);
            this.cbox_QoS.Name = "cbox_QoS";
            this.cbox_QoS.Size = new System.Drawing.Size(120, 28);
            this.cbox_QoS.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Is Input:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "QoS:";
            // 
            // txt_NumberofTags
            // 
            this.txt_NumberofTags.Enabled = false;
            this.txt_NumberofTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NumberofTags.Location = new System.Drawing.Point(180, 203);
            this.txt_NumberofTags.Name = "txt_NumberofTags";
            this.txt_NumberofTags.Size = new System.Drawing.Size(120, 27);
            this.txt_NumberofTags.TabIndex = 60;
            // 
            // txt_TagPrefix
            // 
            this.txt_TagPrefix.Enabled = false;
            this.txt_TagPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TagPrefix.Location = new System.Drawing.Point(180, 242);
            this.txt_TagPrefix.Name = "txt_TagPrefix";
            this.txt_TagPrefix.Size = new System.Drawing.Size(380, 27);
            this.txt_TagPrefix.TabIndex = 61;
            // 
            // txt_TopicPrefix
            // 
            this.txt_TopicPrefix.Enabled = false;
            this.txt_TopicPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TopicPrefix.Location = new System.Drawing.Point(180, 282);
            this.txt_TopicPrefix.Name = "txt_TopicPrefix";
            this.txt_TopicPrefix.Size = new System.Drawing.Size(380, 27);
            this.txt_TopicPrefix.TabIndex = 62;
            // 
            // frm_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 578);
            this.Controls.Add(this.txt_TopicPrefix);
            this.Controls.Add(this.txt_TagPrefix);
            this.Controls.Add(this.txt_NumberofTags);
            this.Controls.Add(this.check_Retain);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.check_IsInput);
            this.Controls.Add(this.cbox_QoS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.check_MultipleTags);
            this.Controls.Add(this.txt_FloorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_RoomName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.txt_DeviceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Device";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group Setting";
            this.Load += new System.EventHandler(this.frm_Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NumberofTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.TextBox txt_DeviceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_FloorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_RoomName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_MultipleTags;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox check_Retain;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox check_IsInput;
        private System.Windows.Forms.ComboBox cbox_QoS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txt_NumberofTags;
        private System.Windows.Forms.TextBox txt_TopicPrefix;
        private System.Windows.Forms.TextBox txt_TagPrefix;
    }
}