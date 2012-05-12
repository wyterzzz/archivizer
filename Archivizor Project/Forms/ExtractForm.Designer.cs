namespace Archivizor_Project
{
    partial class ExtractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractForm));
            this.label1 = new System.Windows.Forms.Label();
            this.archiveTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.hideCheckBox = new System.Windows.Forms.CheckBox();
            this.outPutTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.extractDirCheck = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.shutdownCheck = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.StatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Archive path:";
            // 
            // archiveTextBox
            // 
            this.archiveTextBox.AllowDrop = true;
            this.archiveTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.archiveTextBox.Location = new System.Drawing.Point(9, 24);
            this.archiveTextBox.Multiline = true;
            this.archiveTextBox.Name = "archiveTextBox";
            this.archiveTextBox.ReadOnly = true;
            this.archiveTextBox.Size = new System.Drawing.Size(307, 24);
            this.archiveTextBox.TabIndex = 2;
            this.archiveTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.archiveTextBox_DragDrop);
            this.archiveTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.archiveTextBox_DragOver);
            this.archiveTextBox.DoubleClick += new System.EventHandler(this.archiveTextBox_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output path:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(9, 173);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(276, 24);
            this.passwordTextBox.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(256, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(180, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // hideCheckBox
            // 
            this.hideCheckBox.AutoSize = true;
            this.hideCheckBox.Location = new System.Drawing.Point(9, 151);
            this.hideCheckBox.Name = "hideCheckBox";
            this.hideCheckBox.Size = new System.Drawing.Size(109, 17);
            this.hideCheckBox.TabIndex = 10;
            this.hideCheckBox.Text = "Hide password";
            this.hideCheckBox.UseVisualStyleBackColor = true;
            this.hideCheckBox.CheckedChanged += new System.EventHandler(this.hideCheckBox_CheckedChanged);
            // 
            // outPutTextBox
            // 
            this.outPutTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outPutTextBox.Location = new System.Drawing.Point(9, 75);
            this.outPutTextBox.Multiline = true;
            this.outPutTextBox.Name = "outPutTextBox";
            this.outPutTextBox.ReadOnly = true;
            this.outPutTextBox.Size = new System.Drawing.Size(307, 24);
            this.outPutTextBox.TabIndex = 11;
            this.outPutTextBox.Text = "Click here to open the save dialog!";
            this.outPutTextBox.DoubleClick += new System.EventHandler(this.outPutTextBox_DoubleClick);
            // 
            // readButton
            // 
            this.readButton.Enabled = false;
            this.readButton.Image = ((System.Drawing.Image)(resources.GetObject("readButton.Image")));
            this.readButton.Location = new System.Drawing.Point(291, 172);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(25, 25);
            this.readButton.TabIndex = 13;
            this.toolTip1.SetToolTip(this.readButton, "Read password from a key file.");
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // extractDirCheck
            // 
            this.extractDirCheck.AutoSize = true;
            this.extractDirCheck.Location = new System.Drawing.Point(9, 105);
            this.extractDirCheck.Name = "extractDirCheck";
            this.extractDirCheck.Size = new System.Drawing.Size(192, 17);
            this.extractDirCheck.TabIndex = 14;
            this.extractDirCheck.Text = "Extract in the same directory";
            this.extractDirCheck.UseVisualStyleBackColor = true;
            this.extractDirCheck.CheckedChanged += new System.EventHandler(this.extractDirCheck_CheckedChanged);
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
            this.splitContainer1.Panel2.Controls.Add(this.okButton);
            this.splitContainer1.Panel2.Controls.Add(this.cancelButton);
            this.splitContainer1.Size = new System.Drawing.Size(333, 254);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(333, 228);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.shutdownCheck);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.extractDirCheck);
            this.tabPage1.Controls.Add(this.archiveTextBox);
            this.tabPage1.Controls.Add(this.readButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.passwordTextBox);
            this.tabPage1.Controls.Add(this.outPutTextBox);
            this.tabPage1.Controls.Add(this.hideCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(325, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // shutdownCheck
            // 
            this.shutdownCheck.AutoSize = true;
            this.shutdownCheck.Location = new System.Drawing.Point(9, 128);
            this.shutdownCheck.Name = "shutdownCheck";
            this.shutdownCheck.Size = new System.Drawing.Size(157, 17);
            this.shutdownCheck.TabIndex = 15;
            this.shutdownCheck.Text = "Turn PC off when done";
            this.shutdownCheck.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StatusRichTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(325, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StatusRichTextBox
            // 
            this.StatusRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.StatusRichTextBox.Name = "StatusRichTextBox";
            this.StatusRichTextBox.ReadOnly = true;
            this.StatusRichTextBox.Size = new System.Drawing.Size(319, 196);
            this.StatusRichTextBox.TabIndex = 0;
            this.StatusRichTextBox.Text = "";
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Location = new System.Drawing.Point(4, 0);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(174, 23);
            this.StatusProgressBar.TabIndex = 15;
            // 
            // ExtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 254);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtractForm";
            this.Text = "Extract Manager";
            this.Load += new System.EventHandler(this.ExtractForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox archiveTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox hideCheckBox;
        private System.Windows.Forms.TextBox outPutTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.CheckBox extractDirCheck;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox StatusRichTextBox;
        private System.Windows.Forms.ProgressBar StatusProgressBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox shutdownCheck;
    }
}