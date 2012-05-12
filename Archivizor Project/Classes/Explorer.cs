using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OSIcon;
using OSIcon.WinAPI;
using System.Drawing;
using System.Diagnostics;

class Explorer
{
    #region Fields
        //array = {Tag, Text, ImageKey}
        private String[] computerItems = { "Computer", "My Computer", "computer.png" };
        private String[] desktopItems = { Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Desktop", "desktop.png" };
        private String[] docsItems = { Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documents", "docs.png" };

        private String[] driveItems = { "Logical Drive", "drive.png" };
        private String[] folderParentItems = { "..", "Parent Folder", "folderParent.png" };
        private String[] folderItems = { "Folder", "folder.png" };

        private IList<String> history;
        private Int32 currentHistoryItem = 0;

        private ExceptionMessages eMessage = new ExceptionMessages();
    #endregion
    #region Properties

    public IList<String> History
    {
        get { return history; }
        set { history = value; }
    }

    public Int32 CurrentHistoryItem
    {
        get { return currentHistoryItem; }
        set { currentHistoryItem = value; }
    }
    #endregion

    public Explorer()
    {
        history = new List<String>();
    }

    /// <summary>
    /// Adds My Computer, Desktop and Documents to the TreeView
    /// </summary>
    /// <param name="treeView">My Computer, Desktop and Documents items will be added to this TreeView</param>
    public void AddComputerItems(TreeView treeView)
    {
        String[][] Items = { computerItems, desktopItems, docsItems };
        foreach (String[] parentArray in Items)
        {
            TreeNode pcItem = new TreeNode();
            pcItem.Tag = parentArray[0];
            pcItem.Text = parentArray[1];
            pcItem.ImageKey = parentArray[2];
            pcItem.SelectedImageKey = parentArray[2];
            treeView.Nodes.Add(pcItem);
        }
    }

    /// <summary>
    /// Adds the logical drives to the ListView or to the TreeView ; e.g. C:\, D:\..
    /// </summary>
    /// <param name="computerNode">If you add to TreeView</param>
    /// <param name="listView">If you add to ListView</param>
    public void AddLogicalDrives(TreeNode computerNode = null, ListView listView = null)
    {
        try
        {
            if (computerNode != null)
            {
                foreach (String drive in Environment.GetLogicalDrives())
                {
                    if (Directory.Exists(drive))
                    {
                        TreeNode driveNode = new TreeNode();
                        driveNode.Tag = drive;
                        driveNode.Text = drive;
                        driveNode.ImageKey = driveItems[1];
                        driveNode.SelectedImageKey = driveItems[1];
                        computerNode.Nodes.Add(driveNode);
                    }
                }
            }
            else
            {
                listView.Items.Clear();
                foreach (String drive in Environment.GetLogicalDrives())
                {
                    if (Directory.Exists(drive))
                    {
                        DriveInfo driveInfo = new DriveInfo(drive);
                        long d = 1073741824;
                        listView.Items.Add(new ListViewItem(new String[] { drive, driveItems[0], String.Empty, drive, (driveInfo.TotalSize / d).ToString() + " GB" }, driveItems[1]));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Gets the tag(path) of the TreeNode and adds subfolders to it
    /// </summary>
    /// <param name="selectedDirNode">Subfolders will be added to this TreeNode</param>
    public void AddSubfolders(TreeNode selectedDirNode)
    {
        string path = selectedDirNode.Tag.ToString();

        if (selectedDirNode.Nodes.Count == 0)
        {
            try
            {
                foreach (String subDirectory in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subDirectory);
                    if (!dirInfo.Attributes.ToString().Contains("System"))
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Tag = subDirectory;
                        childNode.Text = subDirectory.Substring(subDirectory.LastIndexOf(@"\") + 1);
                        childNode.ImageKey = folderItems[1];
                        childNode.SelectedImageKey = folderItems[1];
                        selectedDirNode.Nodes.Add(childNode);
                    }
                }
            }
            catch (Exception ex)
            {
                String message = eMessage.GetMessage(ex.Message, path);

                if (MessageBox.Show(message, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }

    #region Add files and folders
    /// <summary>
    /// Adds all files and folders of the selected directory to the ListView and also adds images of the extensions
    /// </summary>
    /// <param name="selectedDir">Selected ListView item which shows the directory</param>
    /// <param name="listView">The ListView you want to use</param>
    /// <param name="smallIconImageList">Small icon ImageList - 16x16 icon size</param>
    /// <param name="largeIconImageList">Large icon ImageList - 48x48 icon size</param>
    public void AddFilesFolders(String selectedDir, ListView listView, ImageList smallIconImageList, ImageList largeIconImageList)
    {
        String parentDirPath;
        listView.Items.Clear();
        try
        {
            if (!IsDrive(selectedDir))
            {
                if (selectedDir == "Computer")
                {
                    AddLogicalDrives(null, listView);
                }
                else
                {
                    DirectoryInfo parentDirInfo = new DirectoryInfo(selectedDir);
                    parentDirPath = parentDirInfo.Parent.FullName;
                    AddFilesFoldersHelper(selectedDir, listView, smallIconImageList, largeIconImageList, parentDirPath);
                }
            }
            else
            {
                parentDirPath = "Computer";
                AddFilesFoldersHelper(selectedDir, listView, smallIconImageList, largeIconImageList, parentDirPath);
            }
        }
        catch (Exception ex)
        {
            String message = eMessage.GetMessage(ex.Message, selectedDir);

            if (MessageBox.Show(message, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }

    /// <summary>
    /// Adds all files and folders of the selected directory to the ListView and also adds images of the extensions(This is the actual function)
    /// </summary>
    /// <param name="selectedDir">Selected ListView item which shows the directory</param>
    /// <param name="listView">The ListView you want to use</param>
    /// <param name="smallIconImageList">Small icon ImageList - 16x16 icon size</param>
    /// <param name="largeIconImageList">Large icon ImageList - 48x48 icon size</param>
    /// <param name="parentDirPath">Parent Directory</param>
    private void AddFilesFoldersHelper(String selectedDir, ListView listView, ImageList smallIconImageList, ImageList largeIconImageList, String parentDirPath)
    {
        listView.Items.Add(new ListViewItem(new String[] { folderParentItems[0], folderParentItems[1], String.Empty, parentDirPath, String.Empty }, folderParentItems[2]));

        foreach (String subDirectory in Directory.GetDirectories(selectedDir))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(subDirectory);
            if (!dirInfo.Attributes.ToString().Contains("System"))
            {
                listView.Items.Add(new ListViewItem(new String[] { dirInfo.Name, folderItems[0], dirInfo.LastWriteTime.ToString(), dirInfo.FullName, String.Empty }, folderItems[1]));
            }
        }

        foreach (String file in Directory.GetFiles(selectedDir))
        {
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Extension != String.Empty)
            {
                AddFileIcons(fileInfo.Extension, smallIconImageList, largeIconImageList);
                listView.Items.Add(new ListViewItem(new String[] { fileInfo.Name, fileInfo.Extension, fileInfo.LastWriteTime.ToString(), fileInfo.FullName, (fileInfo.Length / 1024).ToString() + " KB" }, fileInfo.Extension));
            }
            else
            {
                listView.Items.Add(new ListViewItem(new String[] { fileInfo.Name, "Unknown", fileInfo.LastWriteTime.ToString(), fileInfo.FullName, (fileInfo.Length / 1024).ToString() + " KB" }, "unknown.png"));
            }
        }
    }
#endregion
    
    /// <summary>
    /// Adds images of the file extensions to the ImageLists
    /// </summary>
    /// <param name="itemExtension">File extension ; e.g. .exe, .dll, .png</param>
    /// <param name="smallIconImageList">Small icon ImageList - 16x16 icon size</param>
    /// <param name="largeIconImageList">Large icon ImageList - 48x48 icon size</param>
    public void AddFileIcons(String itemExtension, ImageList smallIconImageList, ImageList largeIconImageList = null)
    {
        OSIcon.WinAPI.Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
        Icon smallIcon = IconReader.GetFileIcon(itemExtension, IconReader.IconSize.Small, false, ref shfi);
        Icon largeIcon = IconReader.GetFileIcon(itemExtension, IconReader.IconSize.ExtraLarge, false, ref shfi);

        if (largeIconImageList != null)
        {
            if (!(smallIconImageList.Images.ContainsKey(itemExtension) && largeIconImageList.Images.ContainsKey(itemExtension)))
            {
                smallIconImageList.Images.Add(itemExtension, smallIcon.ToBitmap());
                largeIconImageList.Images.Add(itemExtension, largeIcon.ToBitmap());
            }
        }
        else
        {
            if (!(smallIconImageList.Images.ContainsKey(itemExtension) && largeIconImageList.Images.ContainsKey(itemExtension)))
            {
                smallIconImageList.Images.Add(itemExtension, smallIcon.ToBitmap());
            }
        }
    }

    /// <summary>
    /// Checks if the selected directory is logical drive
    /// </summary>
    /// <param name="drive">Selected logical drive</param>
    /// <returns>isDrive (true or false)</returns>
    public bool IsDrive(String drive)
    {
        bool isDrive = false;

        foreach (String item in Environment.GetLogicalDrives())
        {
            if (drive.Equals(item))
            {
                isDrive = true;
            }
        }

        return isDrive;
    }

    /// <summary>
    /// Updates the navigation(back, forward)
    /// </summary>
    /// <param name="currentPath">Current folder(path)</param>
    public void UpdateNavigation(String currentPath)
    {
        if (this.currentHistoryItem != this.history.Count - 1)
        {
            for (int i = this.history.Count - 1; i > this.currentHistoryItem; i--)
            {
                this.history.RemoveAt(i);
            }
        }

        this.history.Add(currentPath);
        this.currentHistoryItem = this.history.Count - 1;
    }
}

