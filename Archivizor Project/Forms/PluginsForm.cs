using System;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Archivizer.Plugins;
using Archivizor_Project.Classes;
using System.Drawing;

namespace Archivizor_Project.Forms
{
    public partial class PluginsForm : Form
    {
        #region Fields
        private Dictionary<String, IPlugin> pluginsInstances;
        private PluginHostUtility pluginHostUtility;
        #endregion

        #region Constructor
        public PluginsForm()
        {
            InitializeComponent();
            this.pluginHostUtility = new PluginHostUtility();
            this.pluginsInstances = new Dictionary<String, IPlugin>();
            //GetAllPlugins();
        }
        #endregion

        #region Event-handlers
        private void PluginsForm_Load(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"plugin\d>(.*)>(.*)>(.*)>(.*)>(.*)");
            Match match;
            String tempLine, name, path;

            using (StreamReader streamReader = new StreamReader(Application.StartupPath + @"\configs\plugins.cfg"))
            {
                while ((tempLine = streamReader.ReadLine()) != null)
                {
                    if (regex.IsMatch(tempLine))
                    {
                        match = regex.Match(tempLine);
                        //path = match.Groups[1].Value;
                        lvPlugins.Items.Add(new ListViewItem(new String[] { match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value }));
                    }
                }
            }

            GetPlugins();
        }

        private void PluginsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < lvPlugins.Items.Count; i++)
            {
                sBuilder.AppendLine(String.Format("plugin{0}>{1}>{2}>{3}>{4}>{5}", i, lvPlugins.Items[i].SubItems[0].Text, lvPlugins.Items[i].SubItems[1].Text, lvPlugins.Items[i].SubItems[2].Text, lvPlugins.Items[i].SubItems[3].Text, lvPlugins.Items[i].SubItems[4].Text));
            }

            File.WriteAllText(Application.StartupPath + @"\configs\plugins.cfg", sBuilder.ToString());

            foreach (TabPage tp in tcActivePlugins.TabPages)
            {
                this.pluginsInstances[tp.Name].Dispose();
            }
        }

        private void cmsPluginManger_btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Library files (*.dll)|*.dll";

            if (ofd.ShowDialog() == DialogResult.OK && !PluginExists(ofd.FileName))
            {
                AddPlugin(ofd.FileName);
            }
        }

        private void cmsPluginManger_btnDelete_Click(object sender, EventArgs e)
        {
            if (lvPlugins.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvPlugins.SelectedItems)
                {
                    lvPlugins.Items.Remove(item);
                    this.pluginsInstances.Remove(item.Text);
                }
            }
        }

        private void cmsPluginManger_btnRun_Click(object sender, EventArgs e)
        {
            RunPlugin();
        }

        private void cmsTabControl_btnClose_Click(object sender, EventArgs e)
        {
            this.pluginsInstances[tcActivePlugins.SelectedTab.Name].Dispose();
            tcActivePlugins.TabPages.Remove(tcActivePlugins.SelectedTab);
        }

        private void cmsServerPlugins_btnDownload_Click(object sender, EventArgs e)
        {
            DownloadSave(lvServerPlugins.SelectedItems[0].SubItems[0].Text);
        }

        private void lvPlugins_DoubleClick(object sender, EventArgs e)
        {
            RunPlugin();
        }

        private void cmsServerPlugins_btnRefresh_Click(object sender, EventArgs e)
        {
            lvServerPlugins.Items.Clear();
            GetPlugins();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbPath.Text) && 
                !String.IsNullOrEmpty(tbAuthor.Text) && 
                !String.IsNullOrEmpty(tbDesc.Text) && 
                !String.IsNullOrEmpty(tbName.Text) && 
                !String.IsNullOrEmpty(tbVersion.Text))
            {
                UploadPlugin(tbPath.Text);
                WriteToDB(Path.GetFileName(tbPath.Text), tbName.Text, tbDesc.Text, tbVersion.Text, tbAuthor.Text);
            }
            else
            {
                MessageBox.Show("Incorrect fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "ZIP (*.zip)|*.zip"
                + "|7z (*.7z)|*.7z"
                + "|RAR (*.rar)|*.rar";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = ofd.FileName;
            }
        }
#endregion

        #region Methods
        private bool PluginExists(String filePath)
        {
            foreach (ListViewItem item in lvPlugins.Items)
            {
                if (filePath == item.SubItems[1].Text)
                    return true;
            }
            return false;
        }
        private void GetPlugins()
        {
            //if (!ServerConfig.IsServerOnline)
            //    return;

            List<String> plugins = new List<String>();
            String source = String.Empty;

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            
            try
            {
                source = wc.DownloadString(ServerConfig.ServerAddress + "getall.php?get=true");
            }
            catch (WebException)
            {
                MessageBox.Show("Can't connect to the web server. Contact with the developer!", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Regex regex = new Regex(@"\*>(.*\..*)>(.*)>(.*)>(.*)>(.*)");

            foreach (Match match in regex.Matches(source))
            {
                lvServerPlugins.Items.Add(new ListViewItem(new String[] { ServerConfig.ServerAddress + "plugins/" + match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value }));
            }
        }
        private void WriteToDB(String archiveName, String pluginName, String pluginDesc, String pluginVersion, String pluginAuthor)
        {
            //if (!ServerConfig.IsServerOnline)
            //    return;

            String address = ServerConfig.ServerAddress + "dbwrite.php";
            String strPostData = String.Format("archivename={0}&name={1}&desc={2}&version={3}&author={4}&writebtn=write", archiveName, pluginName, pluginDesc, pluginVersion, pluginAuthor);

            byte[] postData = Encoding.UTF8.GetBytes(strPostData);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(address);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.KeepAlive = true;
            request.Method = "POST";
            request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:11.0) Gecko/20100101 Firefox/11.0";

            Stream stream = request.GetRequestStream();
            stream.Write(postData, 0, postData.Length);
        }
        private void UploadPlugin(String pluginPath)
        {
            //if (!ServerConfig.IsServerOnline)
            //    return;

            String address = ServerConfig.ServerAddress + "upload.php";
            String boundary = Path.GetRandomFileName();
            StringBuilder header = new StringBuilder();
            
            header.AppendLine("--" + boundary);
            header.Append("Content-Disposition: form-data; name=\"uploadedfile\";"); 
            header.AppendFormat("filename=\"{0}\"", Path.GetFileName(pluginPath));
            header.AppendLine();
            header.AppendLine("Content-Type: application/octet-stream");
            header.AppendLine();

            byte[] pluginBytes = File.ReadAllBytes(pluginPath);
            byte[] headerBytes = Encoding.UTF8.GetBytes(header.ToString());
            byte[] endBytes = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--" + Environment.NewLine);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(address);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.ContentLength = headerBytes.Length + new FileInfo(pluginPath).Length + endBytes.Length;
            request.Method = "POST";

            Stream stream = request.GetRequestStream();
            stream.Write(headerBytes, 0, headerBytes.Length);
            stream.Write(pluginBytes, 0, pluginBytes.Length);
            stream.Write(endBytes, 0, endBytes.Length);
        }
        /*private void AddAllPlugins(String[] matches)
        {
            //if (!ServerConfig.IsServerOnline)
            //    return; //"Connection problem.";

            Regex regex = new Regex(@"> ((.*)\..*)<");
            String pageSource = null;
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            
            try
            {
            	pageSource = wc.DownloadString(ServerConfig.ServerAddress + "plugins");
            }
            catch (WebException)
            {
                return;
            }
            
            foreach (Match match in regex.Matches(pageSource))
            {
                Console.WriteLine(match.Groups[3].Value);
            }
        }*/
        private void AddPlugin(String path)
        {
            if (pluginHostUtility.CheckPlugin(path))
            {
                lvPlugins.Items.Add(new ListViewItem(new String[] 
                { 
                    this.pluginHostUtility.PluginInstance.PluginName, 
                    path, 
                    this.pluginHostUtility.PluginInstance.PluginDescription, 
                    this.pluginHostUtility.PluginInstance.PluginVersion, 
                    this.pluginHostUtility.PluginInstance.PluginAuthor 
                }
                ));
                this.pluginsInstances.Add(this.pluginHostUtility.PluginInstance.PluginName, this.pluginHostUtility.PluginInstance);
            }
        }
        private void RunPlugin()
        {
            String pluginName = lvPlugins.SelectedItems[0].SubItems[0].Text;

            if (!tcActivePlugins.TabPages.ContainsKey(pluginName))
            {
                this.pluginsInstances[pluginName].PluginGUI.Dock = DockStyle.Fill;

                TabPage tp = new TabPage(this.pluginsInstances[pluginName].PluginName);
                tp.Name = pluginName;
                tp.UseVisualStyleBackColor = true;
                tp.Controls.Add(this.pluginsInstances[pluginName].PluginGUI);

                this.tcActivePlugins.TabPages.Add(tp);
                this.pluginsInstances[pluginName].Initialize();
            }
        }
        private void DownloadSave(String link)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ZIP (*.zip)|*.zip"
                + "|7z (*.7z)|*.7z"
                + "|RAR (*.rar)|*.rar";

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
        #endregion
    }
}
