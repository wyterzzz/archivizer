namespace Archivizor_Project.Forms
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.dateModified = new System.Windows.Forms.Label();
            this.dateCreated = new System.Windows.Forms.Label();
            this.attributes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Full Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date created:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Date modified:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Attributes:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(57, 11);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(11, 13);
            this.name.TabIndex = 11;
            this.name.Text = " ";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Location = new System.Drawing.Point(56, 39);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(11, 13);
            this.type.TabIndex = 12;
            this.type.Text = " ";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(76, 65);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(11, 13);
            this.path.TabIndex = 13;
            this.path.Text = " ";
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Location = new System.Drawing.Point(52, 91);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(11, 13);
            this.size.TabIndex = 14;
            this.size.Text = " ";
            // 
            // dateModified
            // 
            this.dateModified.AutoSize = true;
            this.dateModified.Location = new System.Drawing.Point(108, 117);
            this.dateModified.Name = "dateModified";
            this.dateModified.Size = new System.Drawing.Size(11, 13);
            this.dateModified.TabIndex = 15;
            this.dateModified.Text = " ";
            // 
            // dateCreated
            // 
            this.dateCreated.AutoSize = true;
            this.dateCreated.Location = new System.Drawing.Point(102, 143);
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.Size = new System.Drawing.Size(11, 13);
            this.dateCreated.TabIndex = 16;
            this.dateCreated.Text = " ";
            // 
            // attributes
            // 
            this.attributes.AutoSize = true;
            this.attributes.Location = new System.Drawing.Point(83, 170);
            this.attributes.Name = "attributes";
            this.attributes.Size = new System.Drawing.Size(11, 13);
            this.attributes.TabIndex = 17;
            this.attributes.Text = " ";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 197);
            this.Controls.Add(this.attributes);
            this.Controls.Add(this.dateCreated);
            this.Controls.Add(this.dateModified);
            this.Controls.Add(this.size);
            this.Controls.Add(this.path);
            this.Controls.Add(this.type);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " File/Folder Information";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Label dateModified;
        private System.Windows.Forms.Label dateCreated;
        private System.Windows.Forms.Label attributes;
    }
}