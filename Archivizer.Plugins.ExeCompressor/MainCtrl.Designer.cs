namespace Archivizer.Plugins.ExeCompressor
{
    partial class MainCtrl
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
            this.btnBuild = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuildPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuild
            // 
            this.btnBuild.Enabled = false;
            this.btnBuild.Location = new System.Drawing.Point(207, 28);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(70, 23);
            this.btnBuild.TabIndex = 5;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File path:";
            // 
            // tbBuildPath
            // 
            this.tbBuildPath.Location = new System.Drawing.Point(11, 28);
            this.tbBuildPath.Multiline = true;
            this.tbBuildPath.Name = "tbBuildPath";
            this.tbBuildPath.ReadOnly = true;
            this.tbBuildPath.Size = new System.Drawing.Size(190, 23);
            this.tbBuildPath.TabIndex = 3;
            this.tbBuildPath.Text = "Double click to browse!";
            this.tbBuildPath.DoubleClick += new System.EventHandler(this.tbBuildPath_DoubleClick);
            // 
            // MainCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBuildPath);
            this.Name = "MainCtrl";
            this.Size = new System.Drawing.Size(328, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuildPath;
    }
}
