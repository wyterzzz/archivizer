using System;
using System.Reflection;
using Archivizer.Plugins;

namespace Archivizor_Project.Classes
{
    public class PluginHostUtility
    {
        public IPlugin PluginInstance { get; private set; }

        public bool CheckPlugin(String path)
        {
            Assembly pluginAssembly = null;
            
            try
            {
                pluginAssembly = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                return false;
            }
            
            foreach (Type type in pluginAssembly.GetTypes())
            {
                if (type.GetInterface(typeof(IPlugin).Name) != null)
                {
                    PluginInstance = (IPlugin)Activator.CreateInstance(type);
                    return true;
                }
            }
            return false;
        }
    }
}
