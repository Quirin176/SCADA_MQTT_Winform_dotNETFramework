namespace Driver_Tool
{
    partial class frm_TagManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TagManagement));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Building = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Floor = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Room = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Device = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Tag = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_New = new System.Windows.Forms.ToolStripButton();
            this.btn_Open = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_SaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Building = new System.Windows.Forms.ToolStripButton();
            this.btn_Floor = new System.Windows.Forms.ToolStripButton();
            this.btn_Room = new System.Windows.Forms.ToolStripButton();
            this.btn_Device = new System.Windows.Forms.ToolStripButton();
            this.btn_Tag = new System.Windows.Forms.ToolStripButton();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col_TagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Topic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_QoS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Retain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_IsInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mns_Building = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Floor = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Room = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Device = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Tag = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1481, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_New,
            this.mn_Open,
            this.mn_Save,
            this.mn_SaveAs,
            this.toolStripSeparator2,
            this.mn_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mn_New
            // 
            this.mn_New.Image = global::Devices.Properties.Resources.New;
            this.mn_New.Name = "mn_New";
            this.mn_New.Size = new System.Drawing.Size(143, 26);
            this.mn_New.Text = "&New";
            // 
            // mn_Open
            // 
            this.mn_Open.Image = global::Devices.Properties.Resources.Open;
            this.mn_Open.Name = "mn_Open";
            this.mn_Open.Size = new System.Drawing.Size(143, 26);
            this.mn_Open.Text = "&Open";
            // 
            // mn_Save
            // 
            this.mn_Save.Image = global::Devices.Properties.Resources.Save;
            this.mn_Save.Name = "mn_Save";
            this.mn_Save.Size = new System.Drawing.Size(143, 26);
            this.mn_Save.Text = "&Save";
            // 
            // mn_SaveAs
            // 
            this.mn_SaveAs.Image = global::Devices.Properties.Resources.SaveAs;
            this.mn_SaveAs.Name = "mn_SaveAs";
            this.mn_SaveAs.Size = new System.Drawing.Size(143, 26);
            this.mn_SaveAs.Text = "&Save As";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // mn_Exit
            // 
            this.mn_Exit.Image = global::Devices.Properties.Resources.Quit;
            this.mn_Exit.Name = "mn_Exit";
            this.mn_Exit.Size = new System.Drawing.Size(143, 26);
            this.mn_Exit.Text = "&Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Building,
            this.mn_Floor,
            this.mn_Room,
            this.mn_Device,
            this.mn_Tag,
            this.mn_Delete});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mn_Building
            // 
            this.mn_Building.Image = global::Devices.Properties.Resources.Add_Building;
            this.mn_Building.Name = "mn_Building";
            this.mn_Building.Size = new System.Drawing.Size(147, 26);
            this.mn_Building.Text = "&Building";
            // 
            // mn_Floor
            // 
            this.mn_Floor.Image = global::Devices.Properties.Resources.Add_Floor;
            this.mn_Floor.Name = "mn_Floor";
            this.mn_Floor.Size = new System.Drawing.Size(147, 26);
            this.mn_Floor.Text = "&Floor";
            // 
            // mn_Room
            // 
            this.mn_Room.Image = global::Devices.Properties.Resources.Add_Room;
            this.mn_Room.Name = "mn_Room";
            this.mn_Room.Size = new System.Drawing.Size(147, 26);
            this.mn_Room.Text = "&Room";
            // 
            // mn_Device
            // 
            this.mn_Device.Image = global::Devices.Properties.Resources.Add_Device;
            this.mn_Device.Name = "mn_Device";
            this.mn_Device.Size = new System.Drawing.Size(147, 26);
            this.mn_Device.Text = "&Device";
            // 
            // mn_Tag
            // 
            this.mn_Tag.Image = global::Devices.Properties.Resources.Add_Tag;
            this.mn_Tag.Name = "mn_Tag";
            this.mn_Tag.Size = new System.Drawing.Size(147, 26);
            this.mn_Tag.Text = "&Tag";
            // 
            // mn_Delete
            // 
            this.mn_Delete.Image = global::Devices.Properties.Resources.Exit;
            this.mn_Delete.Name = "mn_Delete";
            this.mn_Delete.Size = new System.Drawing.Size(147, 26);
            this.mn_Delete.Text = "&Delete";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_New,
            this.btn_Open,
            this.btn_Save,
            this.btn_SaveAs,
            this.toolStripSeparator1,
            this.btn_Building,
            this.btn_Floor,
            this.btn_Room,
            this.btn_Device,
            this.btn_Tag,
            this.btn_Delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1481, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_New
            // 
            this.btn_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_New.Image = global::Devices.Properties.Resources.New;
            this.btn_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(29, 24);
            this.btn_New.Text = "New";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Open.Image = global::Devices.Properties.Resources.Open;
            this.btn_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(29, 24);
            this.btn_Open.Text = "Open";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.Image = global::Devices.Properties.Resources.Save;
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(29, 24);
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SaveAs.Image = global::Devices.Properties.Resources.SaveAs;
            this.btn_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(29, 24);
            this.btn_SaveAs.Text = "Save As";
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_Building
            // 
            this.btn_Building.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Building.Image = global::Devices.Properties.Resources.Add_Building;
            this.btn_Building.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Building.Name = "btn_Building";
            this.btn_Building.Size = new System.Drawing.Size(29, 24);
            this.btn_Building.Text = "Channel";
            this.btn_Building.Click += new System.EventHandler(this.btn_Building_Click);
            // 
            // btn_Floor
            // 
            this.btn_Floor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Floor.Image = global::Devices.Properties.Resources.Add_Floor;
            this.btn_Floor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Floor.Name = "btn_Floor";
            this.btn_Floor.Size = new System.Drawing.Size(29, 24);
            this.btn_Floor.Text = "Floor";
            this.btn_Floor.Click += new System.EventHandler(this.btn_Floor_Click);
            // 
            // btn_Room
            // 
            this.btn_Room.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Room.Image = global::Devices.Properties.Resources.Add_Room;
            this.btn_Room.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Room.Name = "btn_Room";
            this.btn_Room.Size = new System.Drawing.Size(29, 24);
            this.btn_Room.Text = "Room";
            this.btn_Room.Click += new System.EventHandler(this.btn_Room_Click);
            // 
            // btn_Device
            // 
            this.btn_Device.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Device.Image = global::Devices.Properties.Resources.Add_Device;
            this.btn_Device.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Device.Name = "btn_Device";
            this.btn_Device.Size = new System.Drawing.Size(29, 24);
            this.btn_Device.Text = "Device";
            this.btn_Device.Click += new System.EventHandler(this.btn_Device_Click);
            // 
            // btn_Tag
            // 
            this.btn_Tag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Tag.Image = global::Devices.Properties.Resources.Add_Tag;
            this.btn_Tag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Tag.Name = "btn_Tag";
            this.btn_Tag.Size = new System.Drawing.Size(29, 24);
            this.btn_Tag.Text = "Tag";
            this.btn_Tag.Click += new System.EventHandler(this.btn_Tag_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Delete.Image = global::Devices.Properties.Resources.Delete_Tag;
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(29, 24);
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(348, 614);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(1481, 618);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_TagName,
            this.col_Topic,
            this.col_QoS,
            this.col_Retain,
            this.col_Description,
            this.col_IsInput});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1121, 614);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // col_TagName
            // 
            this.col_TagName.Text = "Tag Name";
            this.col_TagName.Width = 200;
            // 
            // col_Topic
            // 
            this.col_Topic.Text = "Topic";
            this.col_Topic.Width = 375;
            // 
            // col_QoS
            // 
            this.col_QoS.Text = "Quality of Service";
            this.col_QoS.Width = 120;
            // 
            // col_Retain
            // 
            this.col_Retain.Text = "Retain";
            // 
            // col_Description
            // 
            this.col_Description.Text = "Description";
            this.col_Description.Width = 200;
            // 
            // col_IsInput
            // 
            this.col_IsInput.Text = "Is Input";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1481, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mns_Building,
            this.mns_Floor,
            this.mns_Room,
            this.mns_Device,
            this.mns_Tag,
            this.mns_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 148);
            // 
            // mns_Building
            // 
            this.mns_Building.Name = "mns_Building";
            this.mns_Building.Size = new System.Drawing.Size(167, 24);
            this.mns_Building.Text = "New Building";
            // 
            // mns_Floor
            // 
            this.mns_Floor.Name = "mns_Floor";
            this.mns_Floor.Size = new System.Drawing.Size(167, 24);
            this.mns_Floor.Text = "New Floor";
            // 
            // mns_Room
            // 
            this.mns_Room.Name = "mns_Room";
            this.mns_Room.Size = new System.Drawing.Size(167, 24);
            this.mns_Room.Text = "New Room";
            // 
            // mns_Device
            // 
            this.mns_Device.Name = "mns_Device";
            this.mns_Device.Size = new System.Drawing.Size(167, 24);
            this.mns_Device.Text = "New Group";
            // 
            // mns_Tag
            // 
            this.mns_Tag.Name = "mns_Tag";
            this.mns_Tag.Size = new System.Drawing.Size(167, 24);
            this.mns_Tag.Text = "New Tag";
            // 
            // mns_Delete
            // 
            this.mns_Delete.Name = "mns_Delete";
            this.mns_Delete.Size = new System.Drawing.Size(167, 24);
            this.mns_Delete.Text = "Delete";
            // 
            // frm_TagManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 673);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_TagManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tag Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_TagManagement_FormClosing);
            this.Load += new System.EventHandler(this.frm_TagManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_New;
        private System.Windows.Forms.ToolStripButton btn_Open;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Building;
        private System.Windows.Forms.ToolStripButton btn_Floor;
        private System.Windows.Forms.ToolStripButton btn_Tag;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col_TagName;
        private System.Windows.Forms.ColumnHeader col_Topic;
        private System.Windows.Forms.ColumnHeader col_Description;
        private System.Windows.Forms.ColumnHeader col_IsInput;
        private System.Windows.Forms.ColumnHeader col_QoS;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mn_New;
        private System.Windows.Forms.ToolStripMenuItem mn_Open;
        private System.Windows.Forms.ToolStripMenuItem mn_Save;
        private System.Windows.Forms.ToolStripMenuItem mn_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mn_Exit;
        private System.Windows.Forms.ToolStripMenuItem mn_Building;
        private System.Windows.Forms.ToolStripMenuItem mn_Floor;
        private System.Windows.Forms.ToolStripMenuItem mn_Tag;
        private System.Windows.Forms.ToolStripMenuItem mn_Delete;
        private System.Windows.Forms.ToolStripButton btn_Room;
        private System.Windows.Forms.ToolStripMenuItem mn_Device;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mns_Building;
        private System.Windows.Forms.ToolStripMenuItem mns_Floor;
        private System.Windows.Forms.ToolStripMenuItem mns_Device;
        private System.Windows.Forms.ToolStripMenuItem mns_Tag;
        private System.Windows.Forms.ToolStripMenuItem mns_Delete;
        private System.Windows.Forms.ColumnHeader col_Retain;
        private System.Windows.Forms.ToolStripButton btn_Device;
        private System.Windows.Forms.ToolStripMenuItem mn_Room;
        private System.Windows.Forms.ToolStripMenuItem mns_Room;
    }
}