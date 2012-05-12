using System;
using System.Windows.Forms;

namespace Archivizer.Plugins
{
    public interface IPlugin
    {
        UserControl PluginGUI { get; }

        String PluginName { get; }
        String PluginAuthor { get; }
        String PluginDescription { get; }
        String PluginVersion { get; }

        void Initialize();
        void Dispose();
    }
}
