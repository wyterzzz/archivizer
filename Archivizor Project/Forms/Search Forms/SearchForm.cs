using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Archivizer_Project;

namespace Archivizor_Project
{
    public partial class SearchForm : Form
    {
        private String folderPath;
        private String argument;
        private bool option;
        MainForm form = new MainForm();

        #region "Properties"
        public String FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }
        public String Argument
        {
            get { return argument; }
            set { argument = value; }
        }
        public bool Option
        {
            get { return option; }
            set { option = value; }
        }
        #endregion

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            foreach (string d in Directory.GetDirectories(folderPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(d);
                Explorer explorerImages = new Explorer();

                if (!dirInfo.Attributes.ToString().Contains("System"))
                {
                    try
                    {
                        if (option == true)
                        {
                            foreach (string f in Directory.GetFiles(d, argument, SearchOption.AllDirectories))
                            {
                                Add(explorerImages, f);
                            }
                        }
                        else
                        {
                            foreach (string f in Directory.GetFiles(d, argument, SearchOption.TopDirectoryOnly))
                            {
                                Add(explorerImages, f);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Add(Explorer explorerImages, string f)
        {
            FileInfo fileInfo = new FileInfo(f);
            String imageKey = fileInfo.Extension;

            if (!imageList.Images.ContainsKey(imageKey))
            {
                explorerImages.AddFileIcons(imageKey, imageList);
            }
            searchListView.Items.Add(new ListViewItem(new String[] { fileInfo.Name, fileInfo.Extension, fileInfo.FullName, (fileInfo.Length / 1024).ToString() + " KB" }, imageKey));
        }

        #region "Context Menu"
        private void selectAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in searchListView.Items)
            {
                item.Selected = true;
            }
        }

        private void deselectAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in searchListView.Items)
            {
                item.Selected = false;
            }
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.AddToArchive(searchListView, true, imageList);
        }
        private void extractManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.AddToExtract(searchListView, 2);
        }
        #endregion



    }
}

