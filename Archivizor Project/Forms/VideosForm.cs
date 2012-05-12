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
    public partial class VideosForm : Form
    {
        public VideosForm()
        {
            InitializeComponent();
        }

        private void VideosForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(ServerConfig.ServerAddress + "index.html");
        }
    }
}
