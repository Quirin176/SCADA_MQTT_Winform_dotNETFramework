namespace HMI_Trend
{
    partial class Trend_RealTime
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Remove = new System.Windows.Forms.Label();
            this.btn_AddUpdate = new System.Windows.Forms.Label();
            this.txt_TagName = new HMI_Edition.HMIText.HMIText();
            this.cbx_Width = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Color = new System.Windows.Forms.ComboBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(4, 252);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1140, 320);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Remove);
            this.panel1.Controls.Add(this.btn_AddUpdate);
            this.panel1.Controls.Add(this.txt_TagName);
            this.panel1.Controls.Add(this.cbx_Width);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_Stop);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbx_Color);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 239);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "REALTIME TREND SETTING";
            // 
            // btn_Remove
            // 
            this.btn_Remove.AutoSize = true;
            this.btn_Remove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.Location = new System.Drawing.Point(820, 62);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(89, 22);
            this.btn_Remove.TabIndex = 71;
            this.btn_Remove.Text = "REMOVE";
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_AddUpdate
            // 
            this.btn_AddUpdate.AutoSize = true;
            this.btn_AddUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_AddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUpdate.Location = new System.Drawing.Point(800, 30);
            this.btn_AddUpdate.Name = "btn_AddUpdate";
            this.btn_AddUpdate.Size = new System.Drawing.Size(131, 22);
            this.btn_AddUpdate.TabIndex = 70;
            this.btn_AddUpdate.Text = "ADD/UPDATE";
            this.btn_AddUpdate.Click += new System.EventHandler(this.btn_AddUpdate_Click);
            // 
            // txt_TagName
            // 
            this.txt_TagName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TagName.ForeColor = System.Drawing.Color.Black;
            this.txt_TagName.Location = new System.Drawing.Point(29, 56);
            this.txt_TagName.Name = "txt_TagName";
            this.txt_TagName.Size = new System.Drawing.Size(350, 27);
            this.txt_TagName.TabIndex = 69;
            this.txt_TagName.TagName = null;
            this.txt_TagName.Value = 0D;
            this.txt_TagName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TagName_MouseDoubleClick);
            // 
            // cbx_Width
            // 
            this.cbx_Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Width.FormattingEnabled = true;
            this.cbx_Width.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbx_Width.Location = new System.Drawing.Point(688, 56);
            this.cbx_Width.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Width.Name = "cbx_Width";
            this.cbx_Width.Size = new System.Drawing.Size(65, 28);
            this.cbx_Width.TabIndex = 52;
            this.cbx_Width.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(691, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 64;
            this.label5.Text = "Width";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(1000, 48);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(100, 30);
            this.btn_Stop.TabIndex = 62;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(503, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Line Color";
            // 
            // cbx_Color
            // 
            this.cbx_Color.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Color.FormattingEnabled = true;
            this.cbx_Color.Location = new System.Drawing.Point(475, 56);
            this.cbx_Color.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Color.Name = "cbx_Color";
            this.cbx_Color.Size = new System.Drawing.Size(150, 28);
            this.cbx_Color.TabIndex = 49;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(1000, 10);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(100, 30);
            this.btn_Start.TabIndex = 60;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 92);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1132, 142);
            this.listView1.TabIndex = 61;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TagName";
            this.columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Topic";
            this.columnHeader2.Width = 380;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Color";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Width";
            this.columnHeader4.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "TagName";
            // 
            // Trend_RealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Trend_RealTime";
            this.Size = new System.Drawing.Size(1150, 580);
            this.Load += new System.EventHandler(this.Trend_RealTime_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbx_Width;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_Color;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private HMI_Edition.HMIText.HMIText txt_TagName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label btn_Remove;
        private System.Windows.Forms.Label btn_AddUpdate;
        private System.Windows.Forms.Label label3;
    }
}
