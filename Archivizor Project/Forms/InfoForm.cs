using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Archivizor_Project.Classes;

namespace Archivizor_Project.Forms
{
    public partial class InfoForm : Form
    {
        private String fullItemPath;
        private String extension;
        private bool isFile;
        private bool isFolder;
        private bool isDrive;

        #region "Properties"
        public bool IsFile
        {
            get { return isFile; }
            set { isFile = value; }
        }
        
        public bool IsFolder
        {
            get { return isFolder; }
            set { isFolder = value; }
        }

        public bool IsDrive
        {
            get { return isDrive; }
            set { isDrive = value; }
        }

        public String FullItemPath
        {
            get { return fullItemPath; }
            set { fullItemPath = value; }
        }
        public String Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        #endregion

        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            List<String> newList = new List<String>();
            newList = Info.GetInformation(fullItemPath, IsFile, isFolder, IsDrive);
            name.Text = newList[0];
            type.Text = extension;
            path.Text = newList[1];
            size.Text = newList[2];
            dateCreated.Text = newList[3];
            dateModified.Text = newList[4];
            attributes.Text = newList[5];

        }
    }
}
