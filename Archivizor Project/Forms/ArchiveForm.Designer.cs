namespace Archivizor_Project
{
    partial class ArchiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbFavourites = new System.Windows.Forms.PictureBox();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.shutdownCheck = new System.Windows.Forms.CheckBox();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.desktopBuildCheck = new System.Windows.Forms.CheckBox();
            this.readButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.hideCheckBox = new System.Windows.Forms.CheckBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.filesListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbFTP = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.StatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.build = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.closeButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.unloadFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadFileToolStripMenuItem.Image")));
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.loadFileToolStripMenuItem.Text = "Load file";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // unloadFileToolStripMenuItem
            // 
            this.unloadFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unloadFileToolStripMenuItem.Image")));
            this.unloadFileToolStripMenuItem.Name = "unloadFileToolStripMenuItem";
            this.unloadFileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.unloadFileToolStripMenuItem.Text = "Unload file";
            this.unloadFileToolStripMenuItem.Click += new System.EventHandler(this.unloadFileToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pbFavourites);
            this.tabPage2.Controls.Add(this.pbHelp);
            this.tabPage2.Controls.Add(this.shutdownCheck);
            this.tabPage2.Controls.Add(this.cmbLevel);
            this.tabPage2.Controls.Add(this.cmbMethod);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmbFormat);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.desktopBuildCheck);
            this.tabPage2.Controls.Add(this.readButton);
            this.tabPage2.Controls.Add(this.saveButton);
            this.tabPage2.Controls.Add(this.copyButton);
            this.tabPage2.Controls.Add(this.hideCheckBox);
            this.tabPage2.Controls.Add(this.outputTextBox);
            this.tabPage2.Controls.Add(this.passwordTextBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.generateButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(500, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pbFavourites
            // 
            this.pbFavourites.Image = ((System.Drawing.Image)(resources.GetObject("pbFavourites.Image")));
            this.pbFavourites.Location = new System.Drawing.Point(249, 103);
            this.pbFavourites.Name = "pbFavourites";
            this.pbFavourites.Size = new System.Drawing.Size(16, 16);
            this.pbFavourites.TabIndex = 24;
            this.pbFavourites.TabStop = false;
            this.pbFavourites.Click += new System.EventHandler(this.pbFavourites_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((System.Drawing.Image)(resources.GetObject("pbHelp.Image")));
            this.pbHelp.Location = new System.Drawing.Point(229, 103);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(16, 16);
            this.pbHelp.TabIndex = 23;
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // shutdownCheck
            // 
            this.shutdownCheck.AutoSize = true;
            this.shutdownCheck.Location = new System.Drawing.Point(114, 75);
            this.shutdownCheck.Name = "shutdownCheck";
            this.shutdownCheck.Size = new System.Drawing.Size(157, 17);
            this.shutdownCheck.TabIndex = 22;
            this.shutdownCheck.Text = "Turn PC off when done";
            this.shutdownCheck.UseVisualStyleBackColor = true;
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.Enabled = false;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbLevel.Location = new System.Drawing.Point(114, 168);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(109, 21);
            this.cmbLevel.TabIndex = 21;
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.Enabled = false;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(114, 134);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(109, 21);
            this.cmbMethod.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Comp. method:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Compress level:";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.Enabled = false;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(114, 100);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(109, 21);
            this.cmbFormat.TabIndex = 15;
            this.cmbFormat.SelectedIndexChanged += new System.EventHandler(this.changeTypeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Output format:";
            // 
            // desktopBuildCheck
            // 
            this.desktopBuildCheck.AutoSize = true;
            this.desktopBuildCheck.Location = new System.Drawing.Point(114, 52);
            this.desktopBuildCheck.Name = "desktopBuildCheck";
            this.desktopBuildCheck.Size = new System.Drawing.Size(123, 17);
            this.desktopBuildCheck.TabIndex = 13;
            this.desktopBuildCheck.Text = "Build on Desktop";
            this.desktopBuildCheck.UseVisualStyleBackColor = true;
            this.desktopBuildCheck.CheckedChanged += new System.EventHandler(this.desktopBuildCheck_CheckedChanged);
            // 
            // readButton
            // 
            this.readButton.Image = ((System.Drawing.Image)(resources.GetObject("readButton.Image")));
            this.readButton.Location = new System.Drawing.Point(370, 200);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(25, 25);
            this.readButton.TabIndex = 12;
            this.toolTip1.SetToolTip(this.readButton, "Read password from key file.");
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(462, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(25, 25);
            this.saveButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.saveButton, "Save password to a key file.");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.Location = new System.Drawing.Point(432, 200);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(25, 25);
            this.copyButton.TabIndex = 10;
            this.toolTip1.SetToolTip(this.copyButton, "Copy password to clipboard.");
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // hideCheckBox
            // 
            this.hideCheckBox.AutoSize = true;
            this.hideCheckBox.Location = new System.Drawing.Point(114, 231);
            this.hideCheckBox.Name = "hideCheckBox";
            this.hideCheckBox.Size = new System.Drawing.Size(109, 17);
            this.hideCheckBox.TabIndex = 9;
            this.hideCheckBox.Text = "Hide password";
            this.hideCheckBox.UseVisualStyleBackColor = true;
            this.hideCheckBox.CheckedChanged += new System.EventHandler(this.hideCheckBox_CheckedChanged);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(114, 24);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(373, 21);
            this.outputTextBox.TabIndex = 6;
            this.outputTextBox.Text = "Click here to open the save dialog!";
            this.outputTextBox.DoubleClick += new System.EventHandler(this.outputTextBox_DoubleClick);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(114, 201);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(250, 24);
            this.passwordTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output file path:";
            // 
            // generateButton
            // 
            this.generateButton.Image = ((System.Drawing.Image)(resources.GetObject("generateButton.Image")));
            this.generateButton.Location = new System.Drawing.Point(401, 200);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(25, 25);
            this.generateButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.generateButton, "Generate random password.");
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.filesListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(500, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // filesListView
            // 
            this.filesListView.AllowDrop = true;
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type,
            this.fullPath,
            this.size});
            this.filesListView.ContextMenuStrip = this.contextMenuStrip1;
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.FullRowSelect = true;
            this.filesListView.Location = new System.Drawing.Point(3, 3);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(494, 262);
            this.filesListView.SmallImageList = this.imageList;
            this.filesListView.TabIndex = 0;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.filesListView_DragDrop);
            this.filesListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.filesListView_DragEnter);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 113;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 71;
            // 
            // fullPath
            // 
            this.fullPath.Text = "Full Path";
            this.fullPath.Width = 215;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 72;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "uFile.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(508, 294);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbFTP);
            this.tabPage4.Controls.Add(this.tbPassword);
            this.tabPage4.Controls.Add(this.lbPassword);
            this.tabPage4.Controls.Add(this.tbUsername);
            this.tabPage4.Controls.Add(this.lbUsername);
            this.tabPage4.Controls.Add(this.tbServer);
            this.tabPage4.Controls.Add(this.lbServer);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(500, 265);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Uploader";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbFTP
            // 
            this.cbFTP.AutoSize = true;
            this.cbFTP.Location = new System.Drawing.Point(8, 6);
            this.cbFTP.Name = "cbFTP";
            this.cbFTP.Size = new System.Drawing.Size(92, 17);
            this.cbFTP.TabIndex = 9;
            this.cbFTP.Text = "FTP Uploader";
            this.cbFTP.UseVisualStyleBackColor = true;
            this.cbFTP.CheckedChanged += new System.EventHandler(this.cbFTP_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(80, 88);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(144, 21);
            this.tbPassword.TabIndex = 8;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Enabled = false;
            this.lbPassword.Location = new System.Drawing.Point(12, 91);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(66, 13);
            this.lbPassword.TabIndex = 7;
            this.lbPassword.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Enabled = false;
            this.tbUsername.Location = new System.Drawing.Point(80, 61);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(144, 21);
            this.tbUsername.TabIndex = 6;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Enabled = false;
            this.lbUsername.Location = new System.Drawing.Point(8, 64);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(70, 13);
            this.lbUsername.TabIndex = 5;
            this.lbUsername.Text = "Username:";
            // 
            // tbServer
            // 
            this.tbServer.Enabled = false;
            this.tbServer.Location = new System.Drawing.Point(80, 34);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(144, 21);
            this.tbServer.TabIndex = 4;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Enabled = false;
            this.lbServer.Location = new System.Drawing.Point(27, 37);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(51, 13);
            this.lbServer.TabIndex = 3;
            this.lbServer.Text = "Server:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.StatusRichTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(500, 265);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Status";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // StatusRichTextBox
            // 
            this.StatusRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.StatusRichTextBox.Name = "StatusRichTextBox";
            this.StatusRichTextBox.ReadOnly = true;
            this.StatusRichTextBox.Size = new System.Drawing.Size(494, 262);
            this.StatusRichTextBox.TabIndex = 0;
            this.StatusRichTextBox.Text = "";
            // 
            // build
            // 
            this.build.Image = ((System.Drawing.Image)(resources.GetObject("build.Image")));
            this.build.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.build.Location = new System.Drawing.Point(222, -1);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(141, 25);
            this.build.TabIndex = 2;
            this.build.Text = "Build Archive";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.StatusProgressBar);
            this.splitContainer1.Panel2.Controls.Add(this.closeButton);
            this.splitContainer1.Panel2.Controls.Add(this.build);
            this.splitContainer1.Size = new System.Drawing.Size(508, 320);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Location = new System.Drawing.Point(4, 0);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(214, 23);
            this.StatusProgressBar.TabIndex = 17;
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(365, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(141, 25);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 320);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ArchiveForm";
            this.Text = "New Archive";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unloadFileToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox hideCheckBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader fullPath;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button build;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button readButton;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox desktopBuildCheck;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar StatusProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox StatusRichTextBox;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox shutdownCheck;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cbFTP;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.PictureBox pbFavourites;
    }
}