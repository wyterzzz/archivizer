using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Archivizer.Plugins.ExeCompressor.Classes
{
    public class Plugin : IPlugin, IDisposable
    {
        #region Properties
        public UserControl PluginGUI
        {
            get { return new MainCtrl(); }
        }

        public String PluginName
        {
            get { return "Exe compressor"; } 
        }

        public String PluginAuthor
        {
            get { return "Nikolay Dakov"; }
        }

        public String PluginDescription
        {
            get { return "Compressor for executable files."; } 
        }

        public String PluginVersion
        {
            get { return "1.0"; } 
        }
        #endregion
        #region Methods
        public void Initialize()
        {
           
        }
        public void Dispose()
        {
            
        }
        #endregion
    }
}
