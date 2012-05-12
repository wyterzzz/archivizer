using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Archivizor_Project
{
    public partial class ViewBytesForm : Form
    {
        private String bytesAsBase64;
        private String extension;

        #region "Properties"
        public String BytesAsBase64
        {
            get { return bytesAsBase64; }
            set { bytesAsBase64 = value; }
        }
        public String Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        #endregion

        public ViewBytesForm()
        {
            InitializeComponent();
        }

        private void ViewBytesForm_Load(object sender, EventArgs e)
        {
            bytesTextBox.Text = bytesAsBase64;
        }


        #region "TopMenu"
        #region "File"

        private void base64StringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as...";
            sfd.Filter = "Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, bytesAsBase64);
                MessageBox.Show("The data was successfully written to:\n" + sfd.FileName + ".", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void byteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as...";
            sfd.Filter = "(*" + extension + ")|*" + extension;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, Convert.FromBase64String(bytesAsBase64));
                MessageBox.Show("The data was successfully written to:\n" + sfd.FileName + ".", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Edit"
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bytesTextBox.SelectionStart = 0;
            bytesTextBox.SelectionLength = bytesTextBox.Text.Length;
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(bytesAsBase64);
                MessageBox.Show("The data was successfully copied to your clipboard!", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("null"))
                {
                    MessageBox.Show("You can't copy null to clipboard !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #endregion


    }
}
