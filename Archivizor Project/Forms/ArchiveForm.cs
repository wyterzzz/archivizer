#region Usings
using System;
using SevenZip;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Drawing;
using Archivizer_Project;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Archivizor_Project.Forms;
using Archivizor_Project.Classes;
using System.Text.RegularExpressions;
using Archivizor_Project.Classes.Misc;
using Archivizor_Project.Classes.ReaderWriter;
using Archivizor_Project.Classes.Algorithms.Compressing;
using Archivizor_Project.Classes.Algorithms.Encryption;
#endregion

namespace Archivizor_Project
{
    public partial class ArchiveForm : Form
    {
        private String tempFolder = String.Empty;
        private IniFile iniFile;

        public ArchiveForm()
        {
            InitializeComponent();
            this.iniFile = new IniFile(Application.StartupPath + @"\configs\favs.ini");
            cmbFormat.Items.AddRange(Enum.GetNames(typeof(OutputFormats)));
            cmbMethod.Items.AddRange(Enum.GetNames(typeof(CompressionMethod)));
            desktopBuildCheck.Checked = true;

            if (this.iniFile.HasAnyFavs)
            {
                cmbFormat.SelectedIndex = cmbFormat.Items.IndexOf(this.iniFile.IniReadValue("Favourites", "Format"));
                cmbMethod.Text = this.iniFile.IniReadValue("Favourites", "Method");
                cmbLevel.Text = this.iniFile.IniReadValue("Favourites", "Level");
            }
            else
            {
                cmbFormat.SelectedIndex = 0;
                cmbMethod.SelectedIndex = 0;
                cmbLevel.SelectedIndex = 0;
            }
        }

        public ArchiveForm(String[] files)
            : this()
        {
            foreach (String filePath in files)
                AddFiles(filePath);
        }

        private void build_Click(object sender, EventArgs e)
        {
            if (filesListView.Items.Count < 0) return;

            String randomPath = DateTime.Now.Millisecond.ToString();
            tempFolder = Path.GetTempPath() + @"Archive (" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + @")\";
            String type = outputTextBox.Text.Substring(outputTextBox.Text.LastIndexOf(@".") + 1);

            CheckFolder();
            CopyFiles(tempFolder);

            if (!String.IsNullOrEmpty(outputTextBox.Text))
            {
                StatusRichTextBox.Text += "[" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + "] " + "Archiving window opened." + Environment.NewLine;
                if (cmbFormat.SelectedIndex <= 2)
                {
                    StatusProgressBar.Style = ProgressBarStyle.Blocks;
                    SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\resources\7z\7zLib.dll");
                    SevenZipCompressor cmp = new SevenZipCompressor();
                    cmp.Compressing += new EventHandler<ProgressEventArgs>(cmp_Compressing);
                    cmp.FileCompressionStarted += new EventHandler<FileNameEventArgs>(cmp_FileCompressionStarted);
                    cmp.CompressionFinished += new EventHandler<EventArgs>(cmp_CompressionFinished);
                    cmp.ArchiveFormat = (OutArchiveFormat)Enum.Parse(typeof(OutArchiveFormat), cmbFormat.Text);
                    cmp.CompressionLevel = (CompressionLevel)int.Parse(cmbLevel.Text);
                    cmp.CompressionMethod = (CompressionMethod)Enum.Parse(typeof(CompressionMethod), cmbMethod.Text);
                    if (String.IsNullOrEmpty(passwordTextBox.Text))
                        cmp.BeginCompressDirectory(tempFolder, outputTextBox.Text);
                    else
                        cmp.BeginCompressDirectory(tempFolder, outputTextBox.Text, passwordTextBox.Text);
                }
                else
                {
                    StatusProgressBar.Style = ProgressBarStyle.Marquee;
                    StatusProgressBar.Value = 1;
                    if (cmbFormat.SelectedIndex == 3)
                    {
                        Classes.Algorithms.Compressing.SevenZip archiver = new Classes.Algorithms.Compressing.SevenZip(Application.StartupPath + @"\resources\7z\7z.exe");
                        archiver.Add(tempFolder);
                        archiver.ProcessFinished += new EventHandler(cmp_CompressionFinished);
                        archiver.GenerateArchive(outputTextBox.Text);
                    }
                    else if (cmbFormat.SelectedIndex == 4)
                    {
                        PAQ8O archiver = new PAQ8O(Application.StartupPath + @"\resources\paq\paq8o.exe");
                        archiver.CompressionLevel = cmbLevel.Text;
                        archiver.Add(tempFolder);
                        archiver.ProcessFinished += new EventHandler(cmp_CompressionFinished);
                        archiver.GenerateArchive(outputTextBox.Text);
                    }
                    else if (cmbFormat.SelectedIndex == 5)
                    {
                        ARC archiver = new ARC(Application.StartupPath + @"\resources\arc\Arc.exe");
                        archiver.CompressionLevel = cmbLevel.Text;
                        archiver.Add(tempFolder.Remove(tempFolder.Length - 1));
                        archiver.ProcessFinished += new EventHandler(cmp_CompressionFinished);
                        archiver.GenerateArchive(outputTextBox.Text);
                    }
                    else if (cmbFormat.SelectedIndex == 6)
                    {
                        Classes.Algorithms.Compressing.SevenZip archiver = new Classes.Algorithms.Compressing.SevenZip(Application.StartupPath + @"\resources\7z\7z.exe");
                        archiver.CompressionMethod = cmbMethod.Text;
                        archiver.Password = passwordTextBox.Text;
                        archiver.Add(tempFolder);
                        archiver.ProcessFinished += new EventHandler(cmp_CompressionFinished);
                        archiver.GenerateSFX(outputTextBox.Text);
                    }
                }
            }
            else
            {
                Save();
            }
        }

        private void cmp_Compressing(object sender, ProgressEventArgs e)
        {
            StatusProgressBar.Value += (e.PercentDelta);
        }

        private void cmp_FileCompressionStarted(object sender, FileNameEventArgs e)
        {
            StatusRichTextBox.Text += "[" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + "] " + String.Format("Compressing \"{0}\".", e.FileName) + Environment.NewLine;
        }

        private void cmp_CompressionFinished(object sender, EventArgs e)
        {
            StatusRichTextBox.Text += "[" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + "] " + "Finished." + Environment.NewLine;
            //Directory.Delete(tempFolder, true);

            if (!shutdownCheck.Checked)
            {
                if (cbFTP.Checked)
                { 
                    if (FTPUpload(tbServer.Text, tbUsername.Text, tbPassword.Text, outputTextBox.Text))
                    {
                        MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (MessageBox.Show("Do you want to open the generated archive?", "Option", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(outputTextBox.Text);
                }
                this.Close();
            }
            else
            {
                Process.Start("shutdown", "/s /t 0");
            }
        }

        //Checks if this folder exists and if exists it will delete all files in it
        private void CheckFolder()
        {
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            else
            {
                foreach (String file in Directory.GetFiles(tempFolder))
                {
                    File.Delete(file);
                }
            }
        }

        //Copy all files to the generated folder
        private void CopyFiles(String folder)
        {
            foreach (ListViewItem item in filesListView.Items)
            {
                String itemType = item.SubItems[1].Text; //item type - file or folder
                String itemF = item.SubItems[2].Text; //path of the file or the folder

                String output = folder + itemF.Substring(itemF.LastIndexOf(@"\") + 1);
                //String outputFolder = folder + itemF.Substring(itemF.LastIndexOf(@"\") + 1);

                try
                {
                    if (itemType == "Folder")
                    {
                        new Microsoft.VisualBasic.Devices.Computer().
                            FileSystem.CopyDirectory(itemF, output);
                    }
                    else
                    {
                        File.Copy(itemF, output);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Open save dialog
        private void outputTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (Save())
            {
                cmbFormat.Enabled = true;
                cmbLevel.Enabled = true;
                cmbMethod.Enabled = true;
                desktopBuildCheck.Checked = false;
                String cfgName = EnumUtilities.enumValueOf(FormatsMethods.GetFormat(outputTextBox.Text), typeof(OutputFormats)).ToString();
                cmbFormat.SelectedIndex = cmbFormat.Items.IndexOf(cfgName);
            }
        }

        //Generate new password
        private void button2_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = new Password().RandomString(15);
        }

        //Hide/Show password characters
        private void hideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hideCheckBox.Checked == true)
                passwordTextBox.PasswordChar = '\u25CF'; //bullet character from the Unicode table
            else
                passwordTextBox.PasswordChar = (char)0; //the null character from the ASCII table 
        }

        //Load file
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AddFiles(ofd.FileName);
            }
        }

        private void AddFiles(String itemPath)
        {
            Boolean isFolder = File.GetAttributes(itemPath) == FileAttributes.Directory;
            FileInfo fileInfo = new FileInfo(itemPath);
            DirectoryInfo dirInfo = new DirectoryInfo(itemPath);

            String imageKey;
            Explorer explorerImages = new Explorer();

            if (isFolder)
            {
                imageKey = "folder.png";
                filesListView.Items.Add(new ListViewItem(new String[] { fileInfo.Name, "Folder", fileInfo.FullName }, imageKey));
            }
            else
            {
                imageKey = fileInfo.Extension;

                if (!imageList.Images.ContainsKey(imageKey))
                {
                    explorerImages.AddFileIcons(imageKey, imageList);
                }

                filesListView.Items.Add(new ListViewItem(new String[] { fileInfo.Name, fileInfo.Extension, fileInfo.FullName, (fileInfo.Length / 1024).ToString() + " KB" }, imageKey));
            }
        }

        //Unload file
        private void unloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in filesListView.SelectedItems)
            {
                item.Remove();
            }
        }

        //Copy password
        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(passwordTextBox.Text);
                MessageBox.Show("The password was successfully copied to your clipboard!", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("null"))
                {
                    MessageBox.Show("You can't copy null to clipboard !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Save password to *.apk file
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as...";
            sfd.Filter = "Archivizor password key (*.apk)|*.apk";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                String password = passwordTextBox.Text;
                File.WriteAllText(sfd.FileName, Convert.ToBase64String(PolyAES.PolyAESEncrypt(Encoding.ASCII.GetBytes(password), "Archivizer")));
            }
        }

        //Read password from *.apk or *.txt file
        private void readButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open the password file from which you want to copy the password...";
            ofd.Filter = "Archivizor password key (*.apk)|*.apk"
                       + "|Text file (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String password = Encoding.ASCII.GetString(PolyAES.PolyAESDecrypt(Convert.FromBase64String(File.ReadAllText(ofd.FileName)), "Archivizer"));
                passwordTextBox.Text = password;
            }
        }

        //Save Dialog
        private bool Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as...";
            sfd.Filter = "7z archive (*.7z)|*.7z"
                    + "|ZIP archive (*.zip)|*.zip"
                    + "|TAR archive (*.tar)|*.tar"
                    + "|WIM archive (*.wim)|*.wim"
                    + "|PAQ8O archive (*.paq8o)|*.paq8o"
                    + "|ARC archive (*.arc)|*.arc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = sfd.FileName;
                return true;
            }
            return false;
        }

        private void filesListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                String[] data = (String[])e.Data.GetData(DataFormats.FileDrop);
                foreach (String file in data)
                {
                    AddFiles(file);
                }
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection", false))
            {
                ListView.SelectedListViewItemCollection lvi = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");

                foreach (ListViewItem item in lvi)
                {
                    AddFiles(item.SubItems[3].Text);
                }
            }
        }

        private void filesListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void desktopBuildCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (desktopBuildCheck.Checked)
            {
                outputTextBox.Enabled = false;
                cmbLevel.Enabled = true;
                cmbMethod.Enabled = true;
                cmbFormat.Enabled = true;
                outputTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Archive (" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + ").7z";
            }
            else
            {
                cmbFormat.Enabled = false;
                cmbLevel.Enabled = false;
                cmbMethod.Enabled = false;
                outputTextBox.Enabled = true;
                outputTextBox.Text = "Click here to open the save dialog!";
            }
        }

        private void changeTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTextBox.Text = FormatsMethods.GetName(outputTextBox.Text) + EnumUtilities.stringValueOf((OutputFormats)Enum.Parse(typeof(OutputFormats), cmbFormat.Text));

            SettingsReader sReader = new SettingsReader(SettingsReader.defConfigsPath + cmbFormat.Text + ".cfg");
            passwordTextBox.Enabled = sReader.HasPassword;
            cmbLevel.Items.Clear();
            cmbMethod.Items.Clear();
            cmbLevel.Items.AddRange(sReader.Levels.ToArray());
            cmbMethod.Items.AddRange(sReader.Methods.ToArray());
            cmbLevel.SelectedIndex = 0;
            cmbMethod.SelectedIndex = 0;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFTP_CheckedChanged(object sender, EventArgs e)
        {
            ChangeStatusUploader(cbFTP.Checked);
        }

        private void ChangeStatusUploader(bool isEnabled)
        {
            lbServer.Enabled = isEnabled;
            lbUsername.Enabled = isEnabled;
            lbPassword.Enabled = isEnabled;

            tbServer.Enabled = isEnabled;
            tbUsername.Enabled = isEnabled;
            tbPassword.Enabled = isEnabled;
        }

        private bool FTPUpload(String server, String userName, String password, String filePath)
        {
            try
            {
	            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server);
	            request.Method = WebRequestMethods.Ftp.UploadFile;
	
	            request.Credentials = new NetworkCredential(userName, password);
	
	            byte[] fileContents = File.ReadAllBytes(filePath);
	
	            request.ContentLength = fileContents.Length;
	
	            Stream requestStream = request.GetRequestStream();
	            requestStream.Write(fileContents, 0, fileContents.Length);
	            requestStream.Close();
	
	            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
	
	            response.Close();
	
	            return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            AlgorithmHelpForm ahf = new AlgorithmHelpForm();
            ahf.Show();
        }

        private void pbFavourites_Click(object sender, EventArgs e)
        {
            if (this.iniFile.HasAnyFavs)
            {
                File.WriteAllText(this.iniFile.path, String.Empty);
            }
            iniFile.IniWriteValue("Favourites", "Format", cmbFormat.Text.ToString());
            iniFile.IniWriteValue("Favourites", "Method", cmbMethod.Text.ToString());
            iniFile.IniWriteValue("Favourites", "Level", cmbLevel.Text.ToString());
        }
    }
}
