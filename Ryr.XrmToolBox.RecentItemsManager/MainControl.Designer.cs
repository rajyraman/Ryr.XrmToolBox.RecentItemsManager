namespace Ryr.XrmToolBox.RecentItemsManager
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditInFXB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateUserRecentItems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recordList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viewList = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userSelector1 = new Ryr.XrmToolBox.RecentItemsManager.UserControls.UserSelector();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tsbLoadUsers,
            this.toolStripSeparator2,
            this.tsbEditInFXB,
            this.toolStripSeparator3,
            this.tsbUpdateUserRecentItems,
            this.toolStripSeparator4,
            this.tsbReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(2375, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(44, 45);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.TsbCloseClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbLoadUsers
            // 
            this.tsbLoadUsers.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadUsers.Image")));
            this.tsbLoadUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadUsers.Name = "tsbLoadUsers";
            this.tsbLoadUsers.Size = new System.Drawing.Size(208, 45);
            this.tsbLoadUsers.Text = "Load Users";
            this.tsbLoadUsers.ToolTipText = "Load Users";
            this.tsbLoadUsers.Click += new System.EventHandler(this.tsbLoadCrmItems_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbEditInFXB
            // 
            this.tsbEditInFXB.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditInFXB.Image")));
            this.tsbEditInFXB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditInFXB.Name = "tsbEditInFXB";
            this.tsbEditInFXB.Size = new System.Drawing.Size(369, 45);
            this.tsbEditInFXB.Text = "Choose users from FXB";
            this.tsbEditInFXB.Click += new System.EventHandler(this.tsbEditInFXB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbUpdateUserRecentItems
            // 
            this.tsbUpdateUserRecentItems.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateUserRecentItems.Image")));
            this.tsbUpdateUserRecentItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateUserRecentItems.Name = "tsbUpdateUserRecentItems";
            this.tsbUpdateUserRecentItems.Size = new System.Drawing.Size(374, 45);
            this.tsbUpdateUserRecentItems.Text = "Update User(s) Settings";
            this.tsbUpdateUserRecentItems.ToolTipText = "Update User(s) Items";
            this.tsbUpdateUserRecentItems.Click += new System.EventHandler(this.tsbUpdateUserSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbReset
            // 
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(134, 45);
            this.tsbReset.Text = "Reset";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userSelector1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(2375, 1862);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1718, 1862);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1718, 1862);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recordList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 1856);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Records";
            // 
            // recordList
            // 
            this.recordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.recordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordList.FullRowSelect = true;
            this.recordList.GridLines = true;
            this.recordList.HideSelection = false;
            this.recordList.Location = new System.Drawing.Point(3, 34);
            this.recordList.Name = "recordList";
            this.recordList.Size = new System.Drawing.Size(847, 1819);
            this.recordList.TabIndex = 0;
            this.recordList.UseCompatibleStateImageBehavior = false;
            this.recordList.View = System.Windows.Forms.View.Details;
            this.recordList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.recordList_ColumnClick);
            this.recordList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.recordList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Entity";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Accessed";
            this.columnHeader3.Width = 172;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pinned";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viewList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(862, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 1856);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Views";
            // 
            // viewList
            // 
            this.viewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.viewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewList.FullRowSelect = true;
            this.viewList.GridLines = true;
            this.viewList.HideSelection = false;
            this.viewList.Location = new System.Drawing.Point(3, 34);
            this.viewList.Name = "viewList";
            this.viewList.Size = new System.Drawing.Size(847, 1819);
            this.viewList.TabIndex = 0;
            this.viewList.UseCompatibleStateImageBehavior = false;
            this.viewList.View = System.Windows.Forms.View.Details;
            this.viewList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.viewList_ColumnClick);
            this.viewList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.viewList_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Entity";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Last Accessed";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Pinned";
            // 
            // userSelector1
            // 
            this.userSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector1.Location = new System.Drawing.Point(0, 0);
            this.userSelector1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.userSelector1.Name = "userSelector1";
            this.userSelector1.Service = null;
            this.userSelector1.Size = new System.Drawing.Size(650, 1862);
            this.userSelector1.TabIndex = 1;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(2375, 1910);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private UserControls.UserSelector userSelector1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUpdateUserRecentItems;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbEditInFXB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView recordList;
        private System.Windows.Forms.ListView viewList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
