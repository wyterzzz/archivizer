using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Archivizor_Project.Forms;
using Archivizor_Project;
using Archivizor_Project.Forms.Search_Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace Archivizer_Project
{
    public partial class MainForm : Form
    {
        private Explorer explorerWork = new Explorer();
        private String currentPath;

        public MainForm()
        {
            InitializeComponent();
            //Adding the computer components to the TreeView and ListView
            explorerWork.AddComputerItems(explorerDrivesTv);
            explorerWork.AddLogicalDrives(explorerDrivesTv.Nodes[0]);
            foreach (TreeNode node in explorerDrivesTv.Nodes)
            {
                explorerWork.AddSubfolders(node);
            }
            UpdateButtons();
            if (OSCheck.getOSInfo().Contains("XP"))
            {
                MessageBox.Show(
                    "Sorry, but we are experiencing some problems with some of the compressing methods in Windows XP because there is a bug in the .Net Framework or in the OS."
                + "You can use some of the compression methods but not all of them will work properly."
                + "If you want to use all of them - try with Vista or 7.", 
                "Information", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            }
        }

        #region Explorer Stuff

        #region TreeView Event Handlers

        //TreeView
        private void explorerDrivesTv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentPath = e.Node.Tag.ToString();
            explorerPathTextBox.Text = currentPath;
            try
            {
                explorerWork.UpdateNavigation(currentPath);
                UpdateButtons();
                explorerWork.AddSubfolders(e.Node);
                explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void explorerDrivesTv_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                try
                {
                    explorerWork.AddSubfolders(node);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region ListView Event Handlers

        //ListView
        private void explorerFilesLv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = explorerFilesLv.SelectedItems[0];
                String selectedItemType = selectedItem.SubItems[1].Text;
                String selectedItemFullPath = selectedItem.SubItems[3].Text;

                if (selectedItemType.Contains("Folder") || selectedItemType.Contains("Logical Drive"))
                {
                    currentPath = selectedItemFullPath;
                    explorerPathTextBox.Text = currentPath;
                    explorerWork.UpdateNavigation(currentPath);
                    UpdateButtons();
                    explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
                }
                else
                {
                    Process.Start(selectedItemFullPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void explorerFilesLv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(explorerFilesLv.SelectedItems, DragDropEffects.Copy);
        }
        #endregion

        #region ListView Menu Event Handlers

        private void viewStyleButton_Click(object sender, EventArgs e)
        {
            if (viewStylePanel.Visible == false)
            {
                viewStylePanel.Visible = true;
            }
            else
            {
                viewStylePanel.Visible = false;
            }
        }

        private void viewStylePanel_Leave(object sender, EventArgs e)
        {
            viewStylePanel.Visible = false;
        }

        private void viewStyleTrackBar_Scroll(object sender, EventArgs e)
        {
            //changing view style
            switch (viewStyleTrackBar.Value)
            {
                case 0:
                    explorerFilesLv.View = View.Details;
                    explorerFilesLv.Refresh();
                    break;
                case 1:
                    explorerFilesLv.View = View.List;
                    explorerFilesLv.Refresh();
                    break;
                case 2:
                    explorerFilesLv.View = View.Tile;
                    explorerFilesLv.Refresh();
                    break;
                case 3:
                    explorerFilesLv.View = View.LargeIcon;
                    explorerFilesLv.Refresh();
                    break;
            }
        }

        private void explorerBackButton_Click(object sender, EventArgs e)
        {
            if (explorerWork.CurrentHistoryItem > 0)
            {
                explorerWork.CurrentHistoryItem -= 1;
            }
            currentPath = explorerWork.History[explorerWork.CurrentHistoryItem];
            explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
            UpdateButtons();
            explorerPathTextBox.Text = currentPath;
        }

        private void explorerForwardButton_Click(object sender, EventArgs e)
        {
            if (explorerWork.CurrentHistoryItem < explorerWork.History.Count)
            {
                explorerWork.CurrentHistoryItem += 1;
            }
            currentPath = explorerWork.History[explorerWork.CurrentHistoryItem];
            explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
            UpdateButtons();
            explorerPathTextBox.Text = currentPath;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
        }

        private void explorerPathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (explorerPathTextBox.Text == "Desktop")
                {
                    currentPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    explorerPathTextBox.Text = currentPath;
                }
                else if (explorerPathTextBox.Text == "Documents")
                {
                    currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    explorerPathTextBox.Text = currentPath;
                }
                else if (Directory.Exists(explorerPathTextBox.Text) || explorerPathTextBox.Text == "Computer")
                {
                    currentPath = explorerPathTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Directory does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
            }

        }
        #endregion

        private void UpdateButtons()
        {
            //updating navigation buttons
            if (explorerWork.CurrentHistoryItem < explorerWork.History.Count - 1
                    && explorerWork.CurrentHistoryItem > 0)
            {
                explorerForwardButton.Enabled = true;
                explorerBackButton.Enabled = true;
            }
            else if (explorerWork.CurrentHistoryItem == 0)
            {
                if (explorerWork.History.Count > 1)
                {
                    explorerForwardButton.Enabled = true;
                }
                explorerBackButton.Enabled = false;
            }
            else
            {
                explorerForwardButton.Enabled = false;
                explorerBackButton.Enabled = true;
            }
        }

        #endregion
        #region Menu Stuff
        #region TopMenu
        #region File
        private void selectAllTmItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in explorerFilesLv.Items)
            {
                item.Selected = true;
            }
        }

        private void deSelectAllTmItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in explorerFilesLv.Items)
            {
                item.Selected = false;
            }
        }

        private void exitTmItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Commands
        private void archiveTmItem_Click(object sender, EventArgs e)
        {
            AddToArchive(explorerFilesLv, false);
        }

        private void openTmItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void deleteTmItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void extractManagerTmItem_Click(object sender, EventArgs e)
        {
            AddToExtract(explorerFilesLv, 3);
        }

        #endregion
        #region Tools
        private void pluginsTmItem_Click(object sender, EventArgs e)
        {
            new PluginsForm().Show();
        }
        private void searchTmItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr");
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control");
        }

        private void showInfoTmItem_Click(object sender, EventArgs e)
        {
            Info();
        }
        #endregion
        #region Help
        private void helpTmItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There will be soon tutorials on how to use Archivizer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void videoTmItem_Click(object sender, EventArgs e)
        {
            new VideosForm().Show();
        }

        private void DownloadSave(String link)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ZIP (*.zip)|*.zip";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    new WebClient().DownloadFile(link, sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void sourceTmItem_Click(object sender, EventArgs e)
        {
            DownloadSave("http://80.80.146.252/archivizer/src/Archivizor.zip");
        }

        private void updateTmItem_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"http://.*/(\d*)\.zip");
            try
            {
                String updateInfo = new WebClient().DownloadString("http://80.80.146.252/archivizer/updates/latestUpdate.txt");
                if (regex.IsMatch(updateInfo))
                {
                    Match match = regex.Match(updateInfo); 
                    if (int.Parse(match.Groups[1].Value) > int.Parse(Archivizor_Project.Properties.Resources.Update))
                    {
                        DownloadSave(match.Groups[0].Value);
                    }
                    else
                    {
                        MessageBox.Show("You are using the latest update of Archivizer.", "Update",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void aboutTmItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }
        #endregion
        #region Language
            private void bgTmItem_Click(object sender, EventArgs e)
            {
                MessageBox.Show("The program is not fully translated to Bulgarian language and you may face some problems because this is not the newest version of the application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(Application.StartupPath + @"\Archivizer Project_bg.exe");
                Application.Exit();
            }
        #endregion
        #endregion
        #region MainMenu
        private void newArchiveButton_Click(object sender, EventArgs e)
        {
            AddToArchive(explorerFilesLv, false);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void showInfoButton_Click(object sender, EventArgs e)
        {
            Info();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            AddToExtract(explorerFilesLv, 3);
        }

        private void pluginsButton_Click(object sender, EventArgs e)
        {
            new PluginsForm().Show();
        }
        #endregion
        #region Explorer Menu Strip
        private void deselectAllEmItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in explorerFilesLv.Items)
            {
                item.Selected = false;
            }
        }

        private void selectAllEmItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in explorerFilesLv.Items)
            {
                item.Selected = true;
            }
        }

        private void openEmItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void deleteEmItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void showInfoEmItem_Click(object sender, EventArgs e)
        {
            Info();
        }
        private void archiveEmItem_Click(object sender, EventArgs e)
        {
            AddToArchive(explorerFilesLv, false);
        }
        private void extractManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToExtract(explorerFilesLv, 3);
        }
        #endregion
        #region Help Functions
        private void Delete()
        {
            Int32 selectedItemsCount = explorerFilesLv.SelectedItems.Count;
            bool error = false;

            if (selectedItemsCount > 0)
            {
                if (MessageBox.Show("Do you really want to delete these items?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    foreach (ListViewItem item in explorerFilesLv.SelectedItems)
                    {
                        String selectedItemType = item.SubItems[1].Text;
                        String selectedItemFullPath = item.SubItems[3].Text;
                        FileInfo checkIfSystem = new FileInfo(selectedItemFullPath);
                        if (selectedItemType.Contains("Logical Drive") || selectedItemType.Contains("Parent Folder") || checkIfSystem.Attributes.ToString().Contains("System"))
                        {
                            error = true;
                        }
                        else
                        {
                            try
                            {
                                if (selectedItemType == "Folder")
                                {
                                    if (MessageBox.Show("Do you really want to delete:\n" + selectedItemFullPath + "\n including all subdirectories and files in it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        Directory.Delete(selectedItemFullPath, true);
                                    }
                                }
                                else
                                {
                                    File.Delete(selectedItemFullPath);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
                    if (error == true)
                    {
                        MessageBox.Show("You can't delete logical drives, parent folders or system files!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select the item/s you want to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Open()
        {
            try
            {
                Int32 selectedItemsCount = explorerFilesLv.SelectedItems.Count;

                if (selectedItemsCount > 0)
                {
                    ListViewItem selectedItems = explorerFilesLv.SelectedItems[0];
                    String selectedItemType = selectedItems.SubItems[1].Text;
                    String selectedItemFullPath = selectedItems.SubItems[3].Text;

                    if (selectedItemType.Contains("Folder") || selectedItemType.Contains("Logical Drive"))
                    {
                        currentPath = selectedItemFullPath;
                        explorerPathTextBox.Text = currentPath;
                        explorerWork.UpdateNavigation(currentPath);
                        UpdateButtons();
                        explorerWork.AddFilesFolders(currentPath, explorerFilesLv, smallImageList, largeImageList);
                    }
                    else
                    {
                        Process.Start(selectedItemFullPath);
                    }
                }
                else
                {
                    MessageBox.Show("You must select the item you want to open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Info()
        {
            try
            {
                Int32 selectedItemsCount = explorerFilesLv.SelectedItems.Count;

                if (selectedItemsCount > 0)
                {
                    foreach (ListViewItem item in explorerFilesLv.SelectedItems)
                    {
                        List<String> info = new List<String>();
                        String selectedItemType = item.SubItems[1].Text;
                        String selectedItemFullPath = item.SubItems[3].Text;
                        InfoForm form = new InfoForm();

                        form.FullItemPath = selectedItemFullPath;
                        form.Extension = selectedItemType;
                        if (selectedItemType.Contains("Folder"))
                        {
                            form.IsFolder = true;
                            form.IsFile = false;
                            form.IsDrive = false;
                        }
                        else if (selectedItemType.Contains("Drive"))
                        {
                            form.IsFolder = false;
                            form.IsFile = false;
                            form.IsDrive = true;
                        }
                        else
                        {
                            form.IsFolder = false;
                            form.IsFile = true;
                            form.IsDrive = false;
                        }

                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You must select the item you want to get info from!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Search()
        {
            Int32 selectedItemsCount = explorerFilesLv.SelectedItems.Count;
            SearchFormOptions form = new SearchFormOptions();

            if (selectedItemsCount > 0)
            {
                ListViewItem selectedItem = explorerFilesLv.SelectedItems[0];
                String selectedItemPath = selectedItem.SubItems[3].Text;
                form.ChosenPath = selectedItemPath;
            }
            form.Show();
        }
        //this method needs optimization
        public void AddToArchive(ListView listView, Boolean fromSearch, ImageList searchImageList = null)
        {
            Int32 selectedItemsCount = listView.SelectedItems.Count;
            ArchiveForm archiveForm = new ArchiveForm();
            bool error = false;

            if (selectedItemsCount > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    String name = item.SubItems[0].Text;
                    String type = item.SubItems[1].Text;
                    String imageKey;

                    if (type == "Logical Drive")
                    {
                        continue;
                    }
                    if (type == "Folder")
                    {
                        imageKey = "folder.png";
                    }
                    else if (type == "Unknown")
                    {
                        imageKey = "unknown.png";
                    }
                    else
	                {
                        if (!archiveForm.imageList.Images.ContainsKey(type))
                        {
                            if (searchImageList != null)
                            {
                                archiveForm.imageList.Images.Add(type, searchImageList.Images[type]);
                            }
                            else
                            {
                                archiveForm.imageList.Images.Add(type, smallImageList.Images[type]);
                            }
                        }
                        imageKey = type;
	                }
                    
                    if (!fromSearch)
                    {
                        String fullPath = item.SubItems[3].Text;
                        String size = item.SubItems[4].Text;
                        FileInfo checkIfSystem = new FileInfo(fullPath);
                        if (!checkIfSystem.Attributes.ToString().Contains("System"))
                        {
                            archiveForm.filesListView.Items.Add(new ListViewItem(new String[] { name, type, fullPath, size }, imageKey));
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        String fullPath = item.SubItems[2].Text;
                        String size = item.SubItems[3].Text;
                        FileInfo checkIfSystem = new FileInfo(fullPath);
                        if (!checkIfSystem.Attributes.ToString().Contains("System"))
                        {
                            archiveForm.filesListView.Items.Add(new ListViewItem(new String[] { name, type, fullPath, size }, imageKey));
                        }
                        else
                        {
                            error = true;
                        }
                    }
                }
                if (error == true)
                {
                    MessageBox.Show("You can add only files (except system files)!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                archiveForm.Show();
            }
            else
            {
                MessageBox.Show("You must select the items you want to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddToExtract(ListView listView, Int32 pathColumn)
        {
            Int32 selectedItemsCount = listView.SelectedItems.Count;

            if (selectedItemsCount > 0)
            {
                ExtractForm form = new ExtractForm();
                ListViewItem selectedItems = listView.SelectedItems[0];
                String selectedItemType = selectedItems.SubItems[1].Text;
                String selectedItemFullPath = selectedItems.SubItems[pathColumn].Text;
                bool isSupported = false;

                foreach (String item in form.ExtensionList)
                {
                    if (item == selectedItemType)
                    {
                        isSupported = true;
                    }
                }

                if (isSupported)
                {
                    //form.ArchivePath = selectedItemFullPath;
                    form = new ExtractForm(new String[] { selectedItemFullPath });
                    form.Show();
                }
                else
                {
                    MessageBox.Show("This type isn't supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must select the archive you want to extract!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion
    }
}