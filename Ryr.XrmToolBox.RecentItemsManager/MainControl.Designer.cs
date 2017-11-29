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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditInFXB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRetrievePins = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRetrieveStats = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userSelector1 = new Ryr.XrmToolBox.RecentItemsManager.UserControls.UserSelector();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.recordsPinList = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewPinList = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viewList = new System.Windows.Forms.ListView();
            this.viewEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewLastAccessed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewIsPinned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pinUnpinContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recordPinSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.recordPinUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recordList = new System.Windows.Forms.ListView();
            this.recordEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordPinned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordLastAccessed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pinUnpinContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.toolStripSeparator8,
            this.tsbRetrievePins,
            this.toolStripSeparator3,
            this.tsbRetrieveStats,
            this.toolStripSeparator4,
            this.tsbPin,
            this.toolStripSeparator7,
            this.tsbReset,
            this.toolStripSeparator6});
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbRetrievePins
            // 
            this.tsbRetrievePins.Enabled = false;
            this.tsbRetrievePins.Image = ((System.Drawing.Image)(resources.GetObject("tsbRetrievePins.Image")));
            this.tsbRetrievePins.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRetrievePins.Name = "tsbRetrievePins";
            this.tsbRetrievePins.Size = new System.Drawing.Size(347, 45);
            this.tsbRetrievePins.Text = "Retrieve Recent Items";
            this.tsbRetrievePins.Click += new System.EventHandler(this.tsbRetrievePins_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbRetrieveStats
            // 
            this.tsbRetrieveStats.Enabled = false;
            this.tsbRetrieveStats.Image = ((System.Drawing.Image)(resources.GetObject("tsbRetrieveStats.Image")));
            this.tsbRetrieveStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRetrieveStats.Name = "tsbRetrieveStats";
            this.tsbRetrieveStats.Size = new System.Drawing.Size(337, 45);
            this.tsbRetrieveStats.Text = "Retrieve Recent Stats";
            this.tsbRetrieveStats.ToolTipText = "Show interesting stats from MRU list";
            this.tsbRetrieveStats.Click += new System.EventHandler(this.tsbRetrieveStats_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbPin
            // 
            this.tsbPin.Image = ((System.Drawing.Image)(resources.GetObject("tsbPin.Image")));
            this.tsbPin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPin.Name = "tsbPin";
            this.tsbPin.Size = new System.Drawing.Size(435, 45);
            this.tsbPin.Text = "Pin/Unpin for selected users";
            this.tsbPin.Click += new System.EventHandler(this.tsbPin_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbReset
            // 
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(134, 45);
            this.tsbReset.Text = "Reset";
            this.tsbReset.ToolTipText = "Reset Pinned items list";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 48);
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1718, 1862);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1718, 1862);
            this.splitContainer2.SplitterDistance = 150;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.recordsPinList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.viewPinList, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1718, 150);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // recordsPinList
            // 
            this.recordsPinList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.recordsPinList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader13});
            this.recordsPinList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordsPinList.FullRowSelect = true;
            this.recordsPinList.GridLines = true;
            this.recordsPinList.HideSelection = false;
            this.recordsPinList.Location = new System.Drawing.Point(3, 35);
            this.recordsPinList.Name = "recordsPinList";
            this.recordsPinList.Size = new System.Drawing.Size(853, 112);
            this.recordsPinList.TabIndex = 0;
            this.recordsPinList.UseCompatibleStateImageBehavior = false;
            this.recordsPinList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Entity";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            this.columnHeader10.Width = 250;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Pinned";
            // 
            // viewPinList
            // 
            this.viewPinList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14});
            this.viewPinList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPinList.GridLines = true;
            this.viewPinList.HideSelection = false;
            this.viewPinList.Location = new System.Drawing.Point(862, 35);
            this.viewPinList.Name = "viewPinList";
            this.viewPinList.Size = new System.Drawing.Size(853, 112);
            this.viewPinList.TabIndex = 1;
            this.viewPinList.UseCompatibleStateImageBehavior = false;
            this.viewPinList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Entity";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Name";
            this.columnHeader12.Width = 250;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Pinned";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(853, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Records to Pin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(862, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(853, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Views to Pin";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1718, 1708);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viewList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(862, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 1702);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Views";
            // 
            // viewList
            // 
            this.viewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.viewUser,
            this.viewEntity,
            this.viewName,
            this.viewIsPinned,
            this.viewLastAccessed});
            this.viewList.ContextMenuStrip = this.pinUnpinContextMenu;
            this.viewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewList.FullRowSelect = true;
            this.viewList.GridLines = true;
            this.viewList.HideSelection = false;
            this.viewList.Location = new System.Drawing.Point(3, 34);
            this.viewList.Name = "viewList";
            this.viewList.Size = new System.Drawing.Size(847, 1665);
            this.viewList.TabIndex = 0;
            this.viewList.UseCompatibleStateImageBehavior = false;
            this.viewList.View = System.Windows.Forms.View.Details;
            this.viewList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.recentItemsList_ColumnClick);
            this.viewList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.viewList_MouseDoubleClick);
            // 
            // viewEntity
            // 
            this.viewEntity.Text = "Entity";
            this.viewEntity.Width = 100;
            // 
            // viewName
            // 
            this.viewName.Text = "Name";
            this.viewName.Width = 250;
            // 
            // viewLastAccessed
            // 
            this.viewLastAccessed.Text = "Last Accessed";
            this.viewLastAccessed.Width = 125;
            // 
            // viewIsPinned
            // 
            this.viewIsPinned.Text = "Pinned";
            // 
            // pinUnpinContextMenu
            // 
            this.pinUnpinContextMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.pinUnpinContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordPinSelect,
            this.recordPinUnselect});
            this.pinUnpinContextMenu.Name = "recordContextMenu";
            this.pinUnpinContextMenu.Size = new System.Drawing.Size(253, 96);
            this.pinUnpinContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.pinContextMenu_ItemClicked);
            // 
            // recordPinSelect
            // 
            this.recordPinSelect.Name = "recordPinSelect";
            this.recordPinSelect.Size = new System.Drawing.Size(252, 46);
            this.recordPinSelect.Text = "Pin";
            // 
            // recordPinUnselect
            // 
            this.recordPinUnselect.Name = "recordPinUnselect";
            this.recordPinUnselect.Size = new System.Drawing.Size(252, 46);
            this.recordPinUnselect.Text = "Remove Pin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recordList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 1702);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Records";
            // 
            // recordList
            // 
            this.recordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.recordUser,
            this.recordEntity,
            this.recordName,
            this.recordPinned,
            this.recordLastAccessed});
            this.recordList.ContextMenuStrip = this.pinUnpinContextMenu;
            this.recordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordList.FullRowSelect = true;
            this.recordList.GridLines = true;
            this.recordList.HideSelection = false;
            this.recordList.Location = new System.Drawing.Point(3, 34);
            this.recordList.Name = "recordList";
            this.recordList.Size = new System.Drawing.Size(847, 1665);
            this.recordList.TabIndex = 0;
            this.recordList.UseCompatibleStateImageBehavior = false;
            this.recordList.View = System.Windows.Forms.View.Details;
            this.recordList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.recentItemsList_ColumnClick);
            this.recordList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.recordList_MouseDoubleClick);
            // 
            // recordEntity
            // 
            this.recordEntity.Text = "Entity";
            this.recordEntity.Width = 100;
            // 
            // recordName
            // 
            this.recordName.Text = "Name";
            this.recordName.Width = 250;
            // 
            // recordUser
            // 
            this.recordUser.Text = "User";
            // 
            // viewUser
            // 
            this.viewUser.Text = "User";
            // 
            // recordPinned
            // 
            this.recordPinned.Text = "Pinned";
            // 
            // recordLastAccessed
            // 
            this.recordLastAccessed.Text = "Last Accessed";
            this.recordLastAccessed.Width = 125;
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pinUnpinContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton tsbRetrieveStats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbEditInFXB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView recordList;
        private System.Windows.Forms.ListView viewList;
        private System.Windows.Forms.ColumnHeader recordEntity;
        private System.Windows.Forms.ColumnHeader recordName;
        private System.Windows.Forms.ColumnHeader viewEntity;
        private System.Windows.Forms.ColumnHeader viewName;
        private System.Windows.Forms.ColumnHeader viewLastAccessed;
        private System.Windows.Forms.ColumnHeader viewIsPinned;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView recordsPinList;
        private System.Windows.Forms.ListView viewPinList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip pinUnpinContextMenu;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStripMenuItem recordPinSelect;
        private System.Windows.Forms.ToolStripMenuItem recordPinUnselect;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripButton tsbPin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbRetrievePins;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColumnHeader recordUser;
        private System.Windows.Forms.ColumnHeader viewUser;
        private System.Windows.Forms.ColumnHeader recordPinned;
        private System.Windows.Forms.ColumnHeader recordLastAccessed;
    }
}
