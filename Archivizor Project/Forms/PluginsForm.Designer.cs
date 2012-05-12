namespace Archivizor_Project.Forms
{
    partial class PluginsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsForm));
            this.lvPlugins = new System.Windows.Forms.ListView();
            this.pluginName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsPluginManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPluginManager_btnRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPluginManager_btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPluginManager_btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPlugins = new DotNetBarTabcontrol();
            this.tpLocalPlugins = new System.Windows.Forms.TabPage();
            this.tpActivePlugins = new System.Windows.Forms.TabPage();
            this.tcActivePlugins = new System.Windows.Forms.TabControl();
            this.cmsTabControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTabControl_btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tpServerPlugins = new System.Windows.Forms.TabPage();
            this.lvServerPlugins = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsServerPlugins = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsServerPlugins_btnDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsServerPlugins_btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tpUploadPlugin = new System.Windows.Forms.TabPage();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmsPluginManager.SuspendLayout();
            this.tcPlugins.SuspendLayout();
            this.tpLocalPlugins.SuspendLayout();
            this.tpActivePlugins.SuspendLayout();
            this.cmsTabControl.SuspendLayout();
            this.tpServerPlugins.SuspendLayout();
            this.cmsServerPlugins.SuspendLayout();
            this.tpUploadPlugin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPlugins
            // 
            this.lvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pluginName,
            this.pluginPath,
            this.pluginDescription,
            this.pluginVersion,
            this.pluginAuthor});
            this.lvPlugins.ContextMenuStrip = this.cmsPluginManager;
            this.lvPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlugins.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvPlugins.FullRowSelect = true;
            this.lvPlugins.GridLines = true;
            this.lvPlugins.Location = new System.Drawing.Point(3, 3);
            this.lvPlugins.Name = "lvPlugins";
            this.lvPlugins.Size = new System.Drawing.Size(534, 434);
            this.lvPlugins.TabIndex = 0;
            this.lvPlugins.UseCompatibleStateImageBehavior = false;
            this.lvPlugins.View = System.Windows.Forms.View.Details;
            this.lvPlugins.DoubleClick += new System.EventHandler(this.lvPlugins_DoubleClick);
            // 
            // pluginName
            // 
            this.pluginName.Text = "Name";
            this.pluginName.Width = 103;
            // 
            // pluginPath
            // 
            this.pluginPath.Text = "Path";
            this.pluginPath.Width = 156;
            // 
            // pluginDescription
            // 
            this.pluginDescription.Text = "Description";
            this.pluginDescription.Width = 120;
            // 
            // pluginVersion
            // 
            this.pluginVersion.Text = "Version";
            // 
            // pluginAuthor
            // 
            this.pluginAuthor.Text = "Author";
            this.pluginAuthor.Width = 85;
            // 
            // cmsPluginManager
            // 
            this.cmsPluginManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPluginManager_btnRun,
            this.toolStripSeparator1,
            this.cmsPluginManager_btnAdd,
            this.cmsPluginManager_btnDelete});
            this.cmsPluginManager.Name = "contextMenuStrip1";
            this.cmsPluginManager.Size = new System.Drawing.Size(108, 76);
            // 
            // cmsPluginManager_btnRun
            // 
            this.cmsPluginManager_btnRun.Name = "cmsPluginManager_btnRun";
            this.cmsPluginManager_btnRun.Size = new System.Drawing.Size(107, 22);
            this.cmsPluginManager_btnRun.Text = "Run";
            this.cmsPluginManager_btnRun.Click += new System.EventHandler(this.cmsPluginManger_btnRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // cmsPluginManager_btnAdd
            // 
            this.cmsPluginManager_btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmsPluginManager_btnAdd.Image")));
            this.cmsPluginManager_btnAdd.Name = "cmsPluginManager_btnAdd";
            this.cmsPluginManager_btnAdd.Size = new System.Drawing.Size(107, 22);
            this.cmsPluginManager_btnAdd.Text = "Add";
            this.cmsPluginManager_btnAdd.Click += new System.EventHandler(this.cmsPluginManger_btnAdd_Click);
            // 
            // cmsPluginManager_btnDelete
            // 
            this.cmsPluginManager_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmsPluginManager_btnDelete.Image")));
            this.cmsPluginManager_btnDelete.Name = "cmsPluginManager_btnDelete";
            this.cmsPluginManager_btnDelete.Size = new System.Drawing.Size(107, 22);
            this.cmsPluginManager_btnDelete.Text = "Delete";
            this.cmsPluginManager_btnDelete.Click += new System.EventHandler(this.cmsPluginManger_btnDelete_Click);
            // 
            // tcPlugins
            // 
            this.tcPlugins.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcPlugins.Controls.Add(this.tpLocalPlugins);
            this.tcPlugins.Controls.Add(this.tpActivePlugins);
            this.tcPlugins.Controls.Add(this.tpServerPlugins);
            this.tcPlugins.Controls.Add(this.tpUploadPlugin);
            this.tcPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPlugins.ImageList = this.imageList1;
            this.tcPlugins.ItemSize = new System.Drawing.Size(44, 136);
            this.tcPlugins.Location = new System.Drawing.Point(0, 0);
            this.tcPlugins.Multiline = true;
            this.tcPlugins.Name = "tcPlugins";
            this.tcPlugins.SelectedIndex = 0;
            this.tcPlugins.Size = new System.Drawing.Size(684, 448);
            this.tcPlugins.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcPlugins.TabIndex = 1;
            // 
            // tpLocalPlugins
            // 
            this.tpLocalPlugins.BackColor = System.Drawing.Color.White;
            this.tpLocalPlugins.Controls.Add(this.lvPlugins);
            this.tpLocalPlugins.ImageIndex = 0;
            this.tpLocalPlugins.Location = new System.Drawing.Point(140, 4);
            this.tpLocalPlugins.Name = "tpLocalPlugins";
            this.tpLocalPlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalPlugins.Size = new System.Drawing.Size(540, 440);
            this.tpLocalPlugins.TabIndex = 0;
            this.tpLocalPlugins.Text = "      Local Plugins";
            // 
            // tpActivePlugins
            // 
            this.tpActivePlugins.BackColor = System.Drawing.Color.White;
            this.tpActivePlugins.Controls.Add(this.tcActivePlugins);
            this.tpActivePlugins.ImageIndex = 1;
            this.tpActivePlugins.Location = new System.Drawing.Point(140, 4);
            this.tpActivePlugins.Name = "tpActivePlugins";
            this.tpActivePlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tpActivePlugins.Size = new System.Drawing.Size(540, 440);
            this.tpActivePlugins.TabIndex = 1;
            this.tpActivePlugins.Text = "        Active Plugins";
            // 
            // tcActivePlugins
            // 
            this.tcActivePlugins.ContextMenuStrip = this.cmsTabControl;
            this.tcActivePlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcActivePlugins.Location = new System.Drawing.Point(3, 3);
            this.tcActivePlugins.Name = "tcActivePlugins";
            this.tcActivePlugins.SelectedIndex = 0;
            this.tcActivePlugins.Size = new System.Drawing.Size(534, 434);
            this.tcActivePlugins.TabIndex = 0;
            // 
            // cmsTabControl
            // 
            this.cmsTabControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTabControl_btnClose});
            this.cmsTabControl.Name = "contextMenuStrip1";
            this.cmsTabControl.Size = new System.Drawing.Size(107, 26);
            // 
            // cmsTabControl_btnClose
            // 
            this.cmsTabControl_btnClose.Image = ((System.Drawing.Image)(resources.GetObject("cmsTabControl_btnClose.Image")));
            this.cmsTabControl_btnClose.Name = "cmsTabControl_btnClose";
            this.cmsTabControl_btnClose.Size = new System.Drawing.Size(106, 22);
            this.cmsTabControl_btnClose.Text = "Close ";
            this.cmsTabControl_btnClose.Click += new System.EventHandler(this.cmsTabControl_btnClose_Click);
            // 
            // tpServerPlugins
            // 
            this.tpServerPlugins.BackColor = System.Drawing.Color.White;
            this.tpServerPlugins.Controls.Add(this.lvServerPlugins);
            this.tpServerPlugins.ImageIndex = 2;
            this.tpServerPlugins.Location = new System.Drawing.Point(140, 4);
            this.tpServerPlugins.Name = "tpServerPlugins";
            this.tpServerPlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tpServerPlugins.Size = new System.Drawing.Size(540, 440);
            this.tpServerPlugins.TabIndex = 2;
            this.tpServerPlugins.Text = "        Server Plugins";
            // 
            // lvServerPlugins
            // 
            this.lvServerPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvServerPlugins.ContextMenuStrip = this.cmsServerPlugins;
            this.lvServerPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServerPlugins.FullRowSelect = true;
            this.lvServerPlugins.GridLines = true;
            this.lvServerPlugins.Location = new System.Drawing.Point(3, 3);
            this.lvServerPlugins.Name = "lvServerPlugins";
            this.lvServerPlugins.Size = new System.Drawing.Size(534, 434);
            this.lvServerPlugins.TabIndex = 0;
            this.lvServerPlugins.UseCompatibleStateImageBehavior = false;
            this.lvServerPlugins.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "DLink";
            this.columnHeader5.Width = 118;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Author";
            this.columnHeader4.Width = 77;
            // 
            // cmsServerPlugins
            // 
            this.cmsServerPlugins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsServerPlugins_btnDownload,
            this.cmsServerPlugins_btnRefresh});
            this.cmsServerPlugins.Name = "cmsServerPlugins";
            this.cmsServerPlugins.Size = new System.Drawing.Size(129, 48);
            // 
            // cmsServerPlugins_btnDownload
            // 
            this.cmsServerPlugins_btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmsServerPlugins_btnDownload.Image")));
            this.cmsServerPlugins_btnDownload.Name = "cmsServerPlugins_btnDownload";
            this.cmsServerPlugins_btnDownload.Size = new System.Drawing.Size(128, 22);
            this.cmsServerPlugins_btnDownload.Text = "Download";
            this.cmsServerPlugins_btnDownload.Click += new System.EventHandler(this.cmsServerPlugins_btnDownload_Click);
            // 
            // cmsServerPlugins_btnRefresh
            // 
            this.cmsServerPlugins_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmsServerPlugins_btnRefresh.Image")));
            this.cmsServerPlugins_btnRefresh.Name = "cmsServerPlugins_btnRefresh";
            this.cmsServerPlugins_btnRefresh.Size = new System.Drawing.Size(128, 22);
            this.cmsServerPlugins_btnRefresh.Text = "Refresh";
            this.cmsServerPlugins_btnRefresh.Click += new System.EventHandler(this.cmsServerPlugins_btnRefresh_Click);
            // 
            // tpUploadPlugin
            // 
            this.tpUploadPlugin.BackColor = System.Drawing.Color.White;
            this.tpUploadPlugin.Controls.Add(this.btnUpload);
            this.tpUploadPlugin.Controls.Add(this.tbAuthor);
            this.tpUploadPlugin.Controls.Add(this.label5);
            this.tpUploadPlugin.Controls.Add(this.tbVersion);
            this.tpUploadPlugin.Controls.Add(this.label4);
            this.tpUploadPlugin.Controls.Add(this.tbDesc);
            this.tpUploadPlugin.Controls.Add(this.label3);
            this.tpUploadPlugin.Controls.Add(this.tbName);
            this.tpUploadPlugin.Controls.Add(this.label2);
            this.tpUploadPlugin.Controls.Add(this.tbPath);
            this.tpUploadPlugin.Controls.Add(this.label1);
            this.tpUploadPlugin.ImageIndex = 3;
            this.tpUploadPlugin.Location = new System.Drawing.Point(140, 4);
            this.tpUploadPlugin.Name = "tpUploadPlugin";
            this.tpUploadPlugin.Padding = new System.Windows.Forms.Padding(3);
            this.tpUploadPlugin.Size = new System.Drawing.Size(540, 440);
            this.tpUploadPlugin.TabIndex = 3;
            this.tpUploadPlugin.Text = "        Upload Plugin";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(138, 250);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(89, 23);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(18, 219);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(209, 21);
            this.tbAuthor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Author:";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(18, 172);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(209, 21);
            this.tbVersion.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Version:";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(18, 125);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(209, 21);
            this.tbDesc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(18, 77);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(209, 21);
            this.tbName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(18, 30);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(209, 21);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "Click here to open the open dialog!";
            this.tbPath.DoubleClick += new System.EventHandler(this.tbPath_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plugins.png");
            this.imageList1.Images.SetKeyName(1, "test.png");
            this.imageList1.Images.SetKeyName(2, "server.png");
            this.imageList1.Images.SetKeyName(3, "upload.png");
            // 
            // PluginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 448);
            this.Controls.Add(this.tcPlugins);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginsForm";
            this.Text = "Plugin Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PluginsForm_FormClosed);
            this.Load += new System.EventHandler(this.PluginsForm_Load);
            this.cmsPluginManager.ResumeLayout(false);
            this.tcPlugins.ResumeLayout(false);
            this.tpLocalPlugins.ResumeLayout(false);
            this.tpActivePlugins.ResumeLayout(false);
            this.cmsTabControl.ResumeLayout(false);
            this.tpServerPlugins.ResumeLayout(false);
            this.cmsServerPlugins.ResumeLayout(false);
            this.tpUploadPlugin.ResumeLayout(false);
            this.tpUploadPlugin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPlugins;
        private System.Windows.Forms.ColumnHeader pluginName;
        private System.Windows.Forms.ColumnHeader pluginPath;
        private System.Windows.Forms.ContextMenuStrip cmsPluginManager;
        private System.Windows.Forms.ToolStripMenuItem cmsPluginManager_btnAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsPluginManager_btnDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsPluginManager_btnRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DotNetBarTabcontrol tcPlugins;
        private System.Windows.Forms.TabPage tpLocalPlugins;
        private System.Windows.Forms.TabPage tpActivePlugins;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tpServerPlugins;
        private System.Windows.Forms.TabPage tpUploadPlugin;
        private System.Windows.Forms.TabControl tcActivePlugins;
        private System.Windows.Forms.ContextMenuStrip cmsTabControl;
        private System.Windows.Forms.ToolStripMenuItem cmsTabControl_btnClose;
        private System.Windows.Forms.ColumnHeader pluginDescription;
        private System.Windows.Forms.ColumnHeader pluginVersion;
        private System.Windows.Forms.ColumnHeader pluginAuthor;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvServerPlugins;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip cmsServerPlugins;
        private System.Windows.Forms.ToolStripMenuItem cmsServerPlugins_btnDownload;
        private System.Windows.Forms.ToolStripMenuItem cmsServerPlugins_btnRefresh;
    }
}