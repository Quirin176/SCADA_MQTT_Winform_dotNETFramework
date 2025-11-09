namespace HMI_Alarm
{
    partial class frm_AlarmTag
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AlarmName_Digital = new HMI_Edition.HMIText.HMIText();
            this.btn_Remove_Digital = new System.Windows.Forms.Label();
            this.btn_AddUpdate_Digital = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TagName_Digital = new HMI_Edition.HMIText.HMIText();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AlarmName_Analog = new HMI_Edition.HMIText.HMIText();
            this.btn_Remove_Analog = new System.Windows.Forms.Label();
            this.btn_AddUpdate_Analog = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TagName_Analog = new HMI_Edition.HMIText.HMIText();
            this.txt_LowLow = new System.Windows.Forms.TextBox();
            this.txt_Low = new System.Windows.Forms.TextBox();
            this.txt_High = new System.Windows.Forms.TextBox();
            this.txt_HighHigh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_RemoveDevice = new System.Windows.Forms.Label();
            this.txt_DeviceName = new HMI_Edition.HMIText.HMIText();
            this.btn_AddDevice = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGreen;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.AlarmName_Digital);
            this.groupBox2.Controls.Add(this.btn_Remove_Digital);
            this.groupBox2.Controls.Add(this.btn_AddUpdate_Digital);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TagName_Digital);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1070, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 183);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SETTING DIGITAL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "ALARM NAME";
            // 
            // AlarmName_Digital
            // 
            this.AlarmName_Digital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlarmName_Digital.ForeColor = System.Drawing.Color.Black;
            this.AlarmName_Digital.Location = new System.Drawing.Point(41, 47);
            this.AlarmName_Digital.Name = "AlarmName_Digital";
            this.AlarmName_Digital.Size = new System.Drawing.Size(320, 27);
            this.AlarmName_Digital.TabIndex = 23;
            this.AlarmName_Digital.TagName = null;
            this.AlarmName_Digital.Value = 0D;
            // 
            // btn_Remove_Digital
            // 
            this.btn_Remove_Digital.AutoSize = true;
            this.btn_Remove_Digital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Remove_Digital.Location = new System.Drawing.Point(244, 143);
            this.btn_Remove_Digital.Name = "btn_Remove_Digital";
            this.btn_Remove_Digital.Size = new System.Drawing.Size(89, 22);
            this.btn_Remove_Digital.TabIndex = 22;
            this.btn_Remove_Digital.Text = "REMOVE";
            this.btn_Remove_Digital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Remove_Digital.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Remove_Digital_MouseClick);
            // 
            // btn_AddUpdate_Digital
            // 
            this.btn_AddUpdate_Digital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_AddUpdate_Digital.Location = new System.Drawing.Point(75, 143);
            this.btn_AddUpdate_Digital.Name = "btn_AddUpdate_Digital";
            this.btn_AddUpdate_Digital.Size = new System.Drawing.Size(89, 22);
            this.btn_AddUpdate_Digital.TabIndex = 21;
            this.btn_AddUpdate_Digital.Text = "ADD";
            this.btn_AddUpdate_Digital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_AddUpdate_Digital.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_AddUpdate_Digital_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "SOURCE";
            // 
            // TagName_Digital
            // 
            this.TagName_Digital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TagName_Digital.ForeColor = System.Drawing.Color.Black;
            this.TagName_Digital.Location = new System.Drawing.Point(41, 103);
            this.TagName_Digital.Name = "TagName_Digital";
            this.TagName_Digital.Size = new System.Drawing.Size(320, 27);
            this.TagName_Digital.TabIndex = 19;
            this.TagName_Digital.TagName = null;
            this.TagName_Digital.Value = 0D;
            this.TagName_Digital.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TagName_Digital_MouseDoubleClick);
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader6});
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1070, 202);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(400, 350);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Alarm Name";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Source";
            this.columnHeader6.Width = 250;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGreen;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.AlarmName_Analog);
            this.groupBox1.Controls.Add(this.btn_Remove_Analog);
            this.groupBox1.Controls.Add(this.btn_AddUpdate_Analog);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TagName_Analog);
            this.groupBox1.Controls.Add(this.txt_LowLow);
            this.groupBox1.Controls.Add(this.txt_Low);
            this.groupBox1.Controls.Add(this.txt_High);
            this.groupBox1.Controls.Add(this.txt_HighHigh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(289, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 183);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETTING ANALOG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "ALARM NAME";
            // 
            // AlarmName_Analog
            // 
            this.AlarmName_Analog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlarmName_Analog.ForeColor = System.Drawing.Color.Black;
            this.AlarmName_Analog.Location = new System.Drawing.Point(47, 46);
            this.AlarmName_Analog.Name = "AlarmName_Analog";
            this.AlarmName_Analog.Size = new System.Drawing.Size(320, 27);
            this.AlarmName_Analog.TabIndex = 21;
            this.AlarmName_Analog.TagName = null;
            this.AlarmName_Analog.Value = 0D;
            // 
            // btn_Remove_Analog
            // 
            this.btn_Remove_Analog.AutoSize = true;
            this.btn_Remove_Analog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Remove_Analog.Location = new System.Drawing.Point(247, 142);
            this.btn_Remove_Analog.Name = "btn_Remove_Analog";
            this.btn_Remove_Analog.Size = new System.Drawing.Size(89, 22);
            this.btn_Remove_Analog.TabIndex = 20;
            this.btn_Remove_Analog.Text = "REMOVE";
            this.btn_Remove_Analog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Remove_Analog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Remove_Analog_MouseClick);
            // 
            // btn_AddUpdate_Analog
            // 
            this.btn_AddUpdate_Analog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_AddUpdate_Analog.Location = new System.Drawing.Point(82, 142);
            this.btn_AddUpdate_Analog.Name = "btn_AddUpdate_Analog";
            this.btn_AddUpdate_Analog.Size = new System.Drawing.Size(89, 22);
            this.btn_AddUpdate_Analog.TabIndex = 19;
            this.btn_AddUpdate_Analog.Text = "ADD";
            this.btn_AddUpdate_Analog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_AddUpdate_Analog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_AddUpdate_Analog_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "SOURCE";
            // 
            // TagName_Analog
            // 
            this.TagName_Analog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TagName_Analog.ForeColor = System.Drawing.Color.Black;
            this.TagName_Analog.Location = new System.Drawing.Point(47, 102);
            this.TagName_Analog.Name = "TagName_Analog";
            this.TagName_Analog.Size = new System.Drawing.Size(320, 27);
            this.TagName_Analog.TabIndex = 17;
            this.TagName_Analog.TagName = null;
            this.TagName_Analog.Value = 0D;
            this.TagName_Analog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TagName_Analog_MouseDoubleClick);
            // 
            // txt_LowLow
            // 
            this.txt_LowLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LowLow.Location = new System.Drawing.Point(610, 137);
            this.txt_LowLow.Name = "txt_LowLow";
            this.txt_LowLow.Size = new System.Drawing.Size(100, 27);
            this.txt_LowLow.TabIndex = 16;
            this.txt_LowLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Low
            // 
            this.txt_Low.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Low.Location = new System.Drawing.Point(610, 102);
            this.txt_Low.Name = "txt_Low";
            this.txt_Low.Size = new System.Drawing.Size(100, 27);
            this.txt_Low.TabIndex = 15;
            this.txt_Low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_High
            // 
            this.txt_High.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_High.Location = new System.Drawing.Point(610, 67);
            this.txt_High.Name = "txt_High";
            this.txt_High.Size = new System.Drawing.Size(100, 27);
            this.txt_High.TabIndex = 14;
            this.txt_High.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_HighHigh
            // 
            this.txt_HighHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HighHigh.Location = new System.Drawing.Point(610, 32);
            this.txt_HighHigh.Name = "txt_HighHigh";
            this.txt_HighHigh.Size = new System.Drawing.Size(100, 27);
            this.txt_HighHigh.TabIndex = 13;
            this.txt_HighHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "LOW LOW LEVEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "LOW LEVEL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "HIGH LEVEL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "HIGH HIGH LEVEL";
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(289, 202);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(775, 350);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Alarm Name";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "High High Level";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "High Level";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Low Level";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Low Low Level";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(1204, 559);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(130, 35);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "Save";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(1340, 559);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(130, 35);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(67, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "DEVICE NAME";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightPink;
            this.groupBox3.Controls.Add(this.btn_RemoveDevice);
            this.groupBox3.Controls.Add(this.txt_DeviceName);
            this.groupBox3.Controls.Add(this.btn_AddDevice);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 183);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ADD/REMOVE DEVICE";
            // 
            // btn_RemoveDevice
            // 
            this.btn_RemoveDevice.AutoSize = true;
            this.btn_RemoveDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_RemoveDevice.Location = new System.Drawing.Point(152, 107);
            this.btn_RemoveDevice.Name = "btn_RemoveDevice";
            this.btn_RemoveDevice.Size = new System.Drawing.Size(89, 22);
            this.btn_RemoveDevice.TabIndex = 22;
            this.btn_RemoveDevice.Text = "REMOVE";
            this.btn_RemoveDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_RemoveDevice.Click += new System.EventHandler(this.btn_RemoveDevice_Click);
            // 
            // txt_DeviceName
            // 
            this.txt_DeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DeviceName.ForeColor = System.Drawing.Color.Black;
            this.txt_DeviceName.Location = new System.Drawing.Point(71, 63);
            this.txt_DeviceName.Name = "txt_DeviceName";
            this.txt_DeviceName.Size = new System.Drawing.Size(131, 27);
            this.txt_DeviceName.TabIndex = 22;
            this.txt_DeviceName.TagName = null;
            this.txt_DeviceName.Value = 0D;
            // 
            // btn_AddDevice
            // 
            this.btn_AddDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_AddDevice.Location = new System.Drawing.Point(35, 107);
            this.btn_AddDevice.Name = "btn_AddDevice";
            this.btn_AddDevice.Size = new System.Drawing.Size(90, 22);
            this.btn_AddDevice.TabIndex = 21;
            this.btn_AddDevice.Text = "ADD";
            this.btn_AddDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_AddDevice.Click += new System.EventHandler(this.btn_AddDevice_Click);
            // 
            // listView3
            // 
            this.listView3.AutoArrange = false;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(12, 202);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(271, 350);
            this.listView3.TabIndex = 14;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView3_ItemSelectionChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Device";
            this.columnHeader9.Width = 250;
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveAs.Location = new System.Drawing.Point(1068, 559);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(130, 35);
            this.btn_SaveAs.TabIndex = 15;
            this.btn_SaveAs.Text = "Save As";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // frm_AlarmTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1482, 603);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Name = "frm_AlarmTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AlarmTag_FormClosing);
            this.Load += new System.EventHandler(this.frm_AlarmTag_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label btn_Remove_Digital;
        private System.Windows.Forms.Label btn_AddUpdate_Digital;
        private System.Windows.Forms.Label label6;
        private HMI_Edition.HMIText.HMIText TagName_Digital;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label btn_Remove_Analog;
        private System.Windows.Forms.Label btn_AddUpdate_Analog;
        private System.Windows.Forms.Label label5;
        private HMI_Edition.HMIText.HMIText TagName_Analog;
        private System.Windows.Forms.TextBox txt_LowLow;
        private System.Windows.Forms.TextBox txt_Low;
        private System.Windows.Forms.TextBox txt_High;
        private System.Windows.Forms.TextBox txt_HighHigh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label7;
        private HMI_Edition.HMIText.HMIText AlarmName_Analog;
        private System.Windows.Forms.Label label8;
        private HMI_Edition.HMIText.HMIText AlarmName_Digital;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox3;
        private HMI_Edition.HMIText.HMIText txt_DeviceName;
        private System.Windows.Forms.Label btn_RemoveDevice;
        private System.Windows.Forms.Label btn_AddDevice;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btn_SaveAs;
    }
}