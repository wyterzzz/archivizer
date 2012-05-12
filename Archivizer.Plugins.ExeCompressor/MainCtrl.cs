using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using ExeCompressor.Classes;

namespace Archivizer.Plugins.ExeCompressor
{
    public partial class MainCtrl : UserControl
    {
        #region Fields
        private Boolean isNet;
        #endregion

        #region Constructor
        public MainCtrl()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private Boolean isNetOrNative(String filePath)
        {
            try
            {
                Assembly.Load(File.ReadAllBytes(filePath));
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Event Handlers
        private void tbBuildPath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executable files (*.exe)|*.exe";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                isNet = isNetOrNative(ofd.FileName);
                tbBuildPath.Text = ofd.FileName;
                btnBuild.Enabled = true;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            btnBuild.Enabled = false;

            AbstractCompressor ac;

            if (isNet)
                ac = new MPRESS(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\resources\mpress\mpress.exe");
            else
                ac = new UPX(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\resources\upx\upx.exe");

            ac.ProcessFinished += new EventHandler(ProcessFinished);
            ac.Compress(tbBuildPath.Text);
        }

        private void ProcessFinished(object sender, EventArgs e)
        {
            MessageBox.Show("Finished", "Compression completed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBuild.Enabled = true;
        }
        #endregion
    }
}
