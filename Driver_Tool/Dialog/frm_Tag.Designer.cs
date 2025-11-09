namespace Driver_Tool.Dialog
{
    partial class frm_Tag
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
            this.txt_TagName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Topic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbox_QoS = new System.Windows.Forms.ComboBox();
            this.check_IsInput = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPg_General = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Room = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Floor = new System.Windows.Forms.TextBox();
            this.check_Retain = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.tabPg_Scale = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_EngFull = new System.Windows.Forms.NumericUpDown();
            this.txt_EngZero = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_RawFull = new System.Windows.Forms.NumericUpDown();
            this.txt_RawZero = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radiobtn_Scale = new System.Windows.Forms.RadioButton();
            this.radiobtn_None = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPg_General.SuspendLayout();
            this.tabPg_Scale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EngFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EngZero)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RawFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RawZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(227, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "TAG SETTING";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(437, 501);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(125, 40);
            this.btn_Cancel.TabIndex = 35;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(306, 501);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(125, 40);
            this.btn_OK.TabIndex = 34;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Description.Location = new System.Drawing.Point(125, 302);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(380, 100);
            this.txt_Description.TabIndex = 33;
            // 
            // txt_TagName
            // 
            this.txt_TagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TagName.Location = new System.Drawing.Point(125, 142);
            this.txt_TagName.Name = "txt_TagName";
            this.txt_TagName.Size = new System.Drawing.Size(380, 27);
            this.txt_TagName.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tag Name:";
            // 
            // txt_Topic
            // 
            this.txt_Topic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Topic.Location = new System.Drawing.Point(125, 182);
            this.txt_Topic.Name = "txt_Topic";
            this.txt_Topic.Size = new System.Drawing.Size(380, 27);
            this.txt_Topic.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Topic:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "QoS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Is Input:";
            // 
            // cbox_QoS
            // 
            this.cbox_QoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_QoS.FormattingEnabled = true;
            this.cbox_QoS.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cbox_QoS.Location = new System.Drawing.Point(125, 222);
            this.cbox_QoS.Name = "cbox_QoS";
            this.cbox_QoS.Size = new System.Drawing.Size(120, 28);
            this.cbox_QoS.TabIndex = 42;
            // 
            // check_IsInput
            // 
            this.check_IsInput.AutoSize = true;
            this.check_IsInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_IsInput.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.check_IsInput.Location = new System.Drawing.Point(125, 264);
            this.check_IsInput.Name = "check_IsInput";
            this.check_IsInput.Size = new System.Drawing.Size(93, 24);
            this.check_IsInput.TabIndex = 43;
            this.check_IsInput.Text = "Is Input";
            this.check_IsInput.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPg_General);
            this.tabControl1.Controls.Add(this.tabPg_Scale);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 458);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPg_General
            // 
            this.tabPg_General.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_General.Controls.Add(this.label15);
            this.tabPg_General.Controls.Add(this.txt_Room);
            this.tabPg_General.Controls.Add(this.label13);
            this.tabPg_General.Controls.Add(this.txt_Floor);
            this.tabPg_General.Controls.Add(this.check_Retain);
            this.tabPg_General.Controls.Add(this.label14);
            this.tabPg_General.Controls.Add(this.label12);
            this.tabPg_General.Controls.Add(this.txt_Device);
            this.tabPg_General.Controls.Add(this.label1);
            this.tabPg_General.Controls.Add(this.label3);
            this.tabPg_General.Controls.Add(this.txt_TagName);
            this.tabPg_General.Controls.Add(this.check_IsInput);
            this.tabPg_General.Controls.Add(this.txt_Description);
            this.tabPg_General.Controls.Add(this.cbox_QoS);
            this.tabPg_General.Controls.Add(this.label2);
            this.tabPg_General.Controls.Add(this.label6);
            this.tabPg_General.Controls.Add(this.txt_Topic);
            this.tabPg_General.Controls.Add(this.label4);
            this.tabPg_General.Location = new System.Drawing.Point(4, 29);
            this.tabPg_General.Name = "tabPg_General";
            this.tabPg_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg_General.Size = new System.Drawing.Size(542, 425);
            this.tabPg_General.TabIndex = 0;
            this.tabPg_General.Text = "General";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 54;
            this.label15.Text = "Room:";
            // 
            // txt_Room
            // 
            this.txt_Room.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Room.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Room.Location = new System.Drawing.Point(125, 62);
            this.txt_Room.Name = "txt_Room";
            this.txt_Room.Size = new System.Drawing.Size(380, 27);
            this.txt_Room.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 52;
            this.label13.Text = "Floor:";
            // 
            // txt_Floor
            // 
            this.txt_Floor.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Floor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Floor.Location = new System.Drawing.Point(125, 22);
            this.txt_Floor.Name = "txt_Floor";
            this.txt_Floor.Size = new System.Drawing.Size(380, 27);
            this.txt_Floor.TabIndex = 53;
            // 
            // check_Retain
            // 
            this.check_Retain.AutoSize = true;
            this.check_Retain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Retain.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.check_Retain.Location = new System.Drawing.Point(408, 224);
            this.check_Retain.Name = "check_Retain";
            this.check_Retain.Size = new System.Drawing.Size(85, 24);
            this.check_Retain.TabIndex = 51;
            this.check_Retain.Text = "Retain";
            this.check_Retain.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(303, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 50;
            this.label14.Text = "Retain:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "Device:";
            // 
            // txt_Device
            // 
            this.txt_Device.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Device.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Device.Location = new System.Drawing.Point(125, 102);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(380, 27);
            this.txt_Device.TabIndex = 47;
            // 
            // tabPg_Scale
            // 
            this.tabPg_Scale.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_Scale.Controls.Add(this.groupBox2);
            this.tabPg_Scale.Controls.Add(this.groupBox1);
            this.tabPg_Scale.Controls.Add(this.radiobtn_Scale);
            this.tabPg_Scale.Controls.Add(this.radiobtn_None);
            this.tabPg_Scale.Location = new System.Drawing.Point(4, 29);
            this.tabPg_Scale.Name = "tabPg_Scale";
            this.tabPg_Scale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg_Scale.Size = new System.Drawing.Size(542, 425);
            this.tabPg_Scale.TabIndex = 1;
            this.tabPg_Scale.Text = "Scaling";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_EngFull);
            this.groupBox2.Controls.Add(this.txt_EngZero);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(272, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 266);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scaled Value Range";
            // 
            // txt_EngFull
            // 
            this.txt_EngFull.Location = new System.Drawing.Point(135, 73);
            this.txt_EngFull.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txt_EngFull.Name = "txt_EngFull";
            this.txt_EngFull.Size = new System.Drawing.Size(100, 27);
            this.txt_EngFull.TabIndex = 5;
            // 
            // txt_EngZero
            // 
            this.txt_EngZero.Location = new System.Drawing.Point(135, 148);
            this.txt_EngZero.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txt_EngZero.Name = "txt_EngZero";
            this.txt_EngZero.Size = new System.Drawing.Size(100, 27);
            this.txt_EngZero.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Eng Full Scale";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Eng Zero Scale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_RawFull);
            this.groupBox1.Controls.Add(this.txt_RawZero);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(6, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 266);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw Value Range";
            // 
            // txt_RawFull
            // 
            this.txt_RawFull.Location = new System.Drawing.Point(139, 73);
            this.txt_RawFull.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.txt_RawFull.Name = "txt_RawFull";
            this.txt_RawFull.Size = new System.Drawing.Size(100, 27);
            this.txt_RawFull.TabIndex = 3;
            // 
            // txt_RawZero
            // 
            this.txt_RawZero.Location = new System.Drawing.Point(139, 148);
            this.txt_RawZero.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.txt_RawZero.Name = "txt_RawZero";
            this.txt_RawZero.Size = new System.Drawing.Size(100, 27);
            this.txt_RawZero.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Raw Full Scale";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Raw Zero Scale";
            // 
            // radiobtn_Scale
            // 
            this.radiobtn_Scale.AutoSize = true;
            this.radiobtn_Scale.Location = new System.Drawing.Point(35, 65);
            this.radiobtn_Scale.Name = "radiobtn_Scale";
            this.radiobtn_Scale.Size = new System.Drawing.Size(124, 24);
            this.radiobtn_Scale.TabIndex = 1;
            this.radiobtn_Scale.TabStop = true;
            this.radiobtn_Scale.Text = "Scale Linear";
            this.radiobtn_Scale.UseVisualStyleBackColor = true;
            // 
            // radiobtn_None
            // 
            this.radiobtn_None.AutoSize = true;
            this.radiobtn_None.Checked = true;
            this.radiobtn_None.Location = new System.Drawing.Point(35, 25);
            this.radiobtn_None.Name = "radiobtn_None";
            this.radiobtn_None.Size = new System.Drawing.Size(98, 24);
            this.radiobtn_None.TabIndex = 0;
            this.radiobtn_None.TabStop = true;
            this.radiobtn_None.Text = "No Scale";
            this.radiobtn_None.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_Tag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Tag";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Setting";
            this.Load += new System.EventHandler(this.frm_Tag_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPg_General.ResumeLayout(false);
            this.tabPg_General.PerformLayout();
            this.tabPg_Scale.ResumeLayout(false);
            this.tabPg_Scale.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EngFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EngZero)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RawFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RawZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.TextBox txt_TagName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Topic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbox_QoS;
        private System.Windows.Forms.CheckBox check_IsInput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPg_General;
        private System.Windows.Forms.TabPage tabPg_Scale;
        private System.Windows.Forms.RadioButton radiobtn_Scale;
        private System.Windows.Forms.RadioButton radiobtn_None;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Device;
        private System.Windows.Forms.NumericUpDown txt_EngFull;
        private System.Windows.Forms.NumericUpDown txt_EngZero;
        private System.Windows.Forms.NumericUpDown txt_RawFull;
        private System.Windows.Forms.NumericUpDown txt_RawZero;
        private System.Windows.Forms.CheckBox check_Retain;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Floor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Room;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}