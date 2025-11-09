namespace Driver_Tool
{
    partial class frm_TagList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TagList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col_TagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Topic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_QoS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_IsInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mns_Channel = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Device = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Group = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Tag = new System.Windows.Forms.ToolStripMenuItem();
            this.mns_Delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(1342, 673);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(315, 669);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_TagName,
            this.col_Topic,
            this.col_QoS,
            this.col_Description,
            this.col_IsInput});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1015, 669);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.col_Topic.Width = 200;
            // 
            // col_QoS
            // 
            this.col_QoS.Text = "Quality of Service";
            this.col_QoS.Width = 120;
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
            this.statusStrip1.Size = new System.Drawing.Size(1342, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mns_Channel,
            this.mns_Device,
            this.mns_Group,
            this.mns_Tag,
            this.mns_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 124);
            // 
            // mns_Channel
            // 
            this.mns_Channel.Name = "mns_Channel";
            this.mns_Channel.Size = new System.Drawing.Size(165, 24);
            this.mns_Channel.Text = "New Channel";
            // 
            // mns_Device
            // 
            this.mns_Device.Name = "mns_Device";
            this.mns_Device.Size = new System.Drawing.Size(165, 24);
            this.mns_Device.Text = "New Device";
            // 
            // mns_Group
            // 
            this.mns_Group.Name = "mns_Group";
            this.mns_Group.Size = new System.Drawing.Size(165, 24);
            this.mns_Group.Text = "New Group";
            // 
            // mns_Tag
            // 
            this.mns_Tag.Name = "mns_Tag";
            this.mns_Tag.Size = new System.Drawing.Size(165, 24);
            this.mns_Tag.Text = "New Tag";
            // 
            // mns_Delete
            // 
            this.mns_Delete.Name = "mns_Delete";
            this.mns_Delete.Size = new System.Drawing.Size(165, 24);
            this.mns_Delete.Text = "Delete";
            // 
            // frm_TagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 673);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_TagList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tag List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_TagList_FormClosing);
            this.Load += new System.EventHandler(this.frm_TagList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col_TagName;
        private System.Windows.Forms.ColumnHeader col_Topic;
        private System.Windows.Forms.ColumnHeader col_QoS;
        private System.Windows.Forms.ColumnHeader col_Description;
        private System.Windows.Forms.ColumnHeader col_IsInput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mns_Channel;
        private System.Windows.Forms.ToolStripMenuItem mns_Device;
        private System.Windows.Forms.ToolStripMenuItem mns_Group;
        private System.Windows.Forms.ToolStripMenuItem mns_Tag;
        private System.Windows.Forms.ToolStripMenuItem mns_Delete;
    }
}