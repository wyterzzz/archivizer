using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using SevenZip;
using Archivizor_Project.Classes.Algorithms.Compressing;
using Archivizor_Project.Classes.Algorithms.Encryption;
using Archivizor_Project.Classes.Misc;
using Archivizor_Project.Classes;
using System.Reflection;

namespace Archivizor_Project
{
    public partial class ExtractForm : Form
    {
        private String outPutPath = String.Empty;
        private String archivePath = String.Empty;
        private String szFolder = Application.StartupPath + @"\resources\7z\7z.exe";
        private SevenZipExtractor extractor;
        public String[] extensionList = 
        { 
            #region Formats
            ".7z", 
            ".rar", 
            ".zip", 
            ".tar", 
            ".arj", 
            ".bzip2", 
            ".cab", 
            ".chm", 
            ".deb", 
            ".gzip", 
            ".iso", 
            ".lzh", 
            ".lzma", 
            ".nsis", 
            ".rmp", 
            ".split", 
            ".wim", 
            ".lzw",
            ".udf",
            ".xar",
            ".mub",
            ".hfs",
            ".dmg",
            ".xz",
            ".mslz",
            ".swf",
            ".exe",
            ".msi",
            ".vhd",
            ".elf",
            ".paq8o",
            ".arc"
#endregion
        };
        
        #region Properties
        public String ArchivePath
        {
            get { return archivePath; }
            set { archivePath = value; }
        }
        public String[] ExtensionList
        {
            get { return extensionList; }
            set { extensionList = value; }
        }
        #endregion

        public ExtractForm()
        {
            InitializeComponent();
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + @"\resources\7z\7zLib.dll");
        }

        public ExtractForm(String[] file) : this()
        {
            if (CorrectFormat(file[file.Length - 1]))
            {
                archiveTextBox.Text = file[file.Length - 1];
                this.archivePath = file[file.Length - 1];
                PasswordControlsEnable(HasPassword(this.archivePath));
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hideCheckBox.Checked == true)
                passwordTextBox.PasswordChar = '\u25CF'; //bullet character from the Unicode table
            else
                passwordTextBox.PasswordChar = (char)0; //the null character from the ASCII table 
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(outPutPath))
            {
                String password = passwordTextBox.Text;

                StatusRichTextBox.Text += "[" + DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss") + "] " + "Extracting window opened." + Environment.NewLine;

                if (archivePath.EndsWith(".arc"))
                {
                    StatusProgressBar.Style = ProgressBarStyle.Marquee;
                    ARC arcExtract = new ARC(Application.StartupPath + @"\resources\arc\Arc.exe");
                    arcExtract.ProcessFinished += new EventHandler(extr_ExtractionFinished);
                    arcExtract.ExtractArchive(this.archivePath, this.outPutPath);
                }
                else if (archivePath.EndsWith(".paq8o"))
                {
                    StatusProgressBar.Style = ProgressBarStyle.Marquee;
                    PAQ8O paqExtract = new PAQ8O(Application.StartupPath + @"\resources\paq\paq8o.exe");
                    paqExtract.ProcessFinished += new EventHandler(extr_ExtractionFinished);
                    paqExtract.ExtractArchive(this.archivePath, this.outPutPath);
                }
                else
                {
                    StatusProgressBar.Style = ProgressBarStyle.Blocks;
                    if (!passwordTextBox.Enabled && String.IsNullOrEmpty(password))
                    {
                        extractor = new SevenZipExtractor(archivePath);
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(password))
                        {
                            MessageBox.Show("You need to type password!");
                            return;
                        }
                        else
                        {
                            extractor = new SevenZipExtractor(archivePath, password);
                        }
                    }
                    extractor.Extracting += new EventHandler<ProgressEventArgs>(extr_Extracting);
                    extractor.FileExtractionStarted += new EventHandler<FileInfoEventArgs>(extr_FileExtractionStarted);
                    extractor.FileExists += new EventHandler<FileOverwriteEventArgs>(extr_FileExists);
                    extractor.ExtractionFinished += new EventHandler<EventArgs>(extr_ExtractionFinished);
                    extractor.BeginExtractArchive(outPutPath);
                }
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    outPutPath = folderBrowserDialog1.SelectedPath;
                    outPutTextBox.Text = outPutPath;
                }
            }
        }

        void extr_ExtractionFinished(object sender, EventArgs e)
        {
            StatusRichTextBox.Text += String.Format("[{0}] Finished." + Environment.NewLine, DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss"));
            StatusProgressBar.Value = 100;

            if (!shutdownCheck.Checked)
            {
                if (MessageBox.Show("Do you want to open the destination folder?", "Option", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", outPutPath);
                }

                this.Close();
            }
            else
            {
                Process.Start("shutdown", "/s /t 0");
            }
        }

        void extr_FileExists(object sender, FileOverwriteEventArgs e)
        {
            StatusRichTextBox.Text += String.Format("[{0}] Warning: \"{1}\" already exists; overwritten." + Environment.NewLine, DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss"), e.FileName);
        }

        void extr_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            StatusRichTextBox.Text += String.Format("[{0}] Extracting \"{1}\"" + Environment.NewLine, DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss"), e.FileInfo.FileName);
        }

        void extr_Extracting(object sender, ProgressEventArgs e)
        {
            StatusProgressBar.Value += e.PercentDelta;
        }

        private void archiveTextBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (CorrectFormat(ofd.FileName))
                {
                    archiveTextBox.Text = ofd.FileName;
                    this.archivePath = ofd.FileName;
                    PasswordControlsEnable(HasPassword(this.archivePath));
                }
            }
        }

        private void ExtractForm_Load(object sender, EventArgs e)
        {
            archiveTextBox.Text = archivePath;
        }

        private void outPutTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outPutPath = folderBrowserDialog1.SelectedPath;
                outPutTextBox.Text = outPutPath;
            }
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open the password file from which you want to copy the password...";
            ofd.Filter = "Archivizor password key (*.apk)|*.apk"
                       + "|Text file (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String password = Encoding.ASCII.GetString(PolyAES.PolyAESDecrypt(Convert.FromBase64String(File.ReadAllText(ofd.FileName)), "Archivizer"));;
                passwordTextBox.Text = password;
            }
        }

        private void archiveTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void archiveTextBox_DragDrop(object sender, DragEventArgs e)
        {
            String[] archivePath = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (String item in archivePath)
            {
                if (CorrectFormat(item))
                {
                    archiveTextBox.Text = item;
                    this.archivePath = item;
                    PasswordControlsEnable(HasPassword(this.archivePath));
                }
            }
        }

        private void extractDirCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (extractDirCheck.Checked)
            {
                outPutTextBox.Enabled = false;
                outPutTextBox.Text = archivePath.Substring(0, archivePath.LastIndexOf(@"."));
                outPutPath = outPutTextBox.Text;
            }
            else
            {
                outPutTextBox.Enabled = true;
                if (outPutPath != String.Empty)
                {
                    outPutTextBox.Text = outPutPath;
                }
                else
                {
                    outPutTextBox.Text = "Click here to open the save dialog!";
                }
            }
        }

        private bool CorrectFormat(String fileName)
        {
            foreach (String format in extensionList)
            {
                if (fileName.Contains(format))
                    return true;
            }
            return false;
        }

        private bool HasPassword(String fileName)
        {
            try
            {
                foreach (var item in new SevenZipExtractor(archivePath).ArchiveFileData)
                {
                    if (item.Encrypted)
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void PasswordControlsEnable(bool hasPassword)
        {
            passwordTextBox.Enabled = hasPassword;
            readButton.Enabled = hasPassword;
            hideCheckBox.Enabled = hasPassword;
        }
    }
}