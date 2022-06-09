using System.Reflection;
using Lab5_6;
using yakov = yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace Lab4
{
    public class PluginsLoader
    {
        public List<IPlugin> Plugins { get; protected set; }
        public string PluginsDirPath { get; protected set; }

        public PluginsLoader(string pluginsDirPath)
        {
            PluginsDirPath = pluginsDirPath;
            LoadPlugins();
        }

        public void LoadPlugins()
        {
            if (PluginsDirPath == null)
            {
                throw new Exception("Plugins directory path isn't set");
            }
            Plugins = new List<IPlugin>();
            DirectoryInfo plugins_dir = new DirectoryInfo(PluginsDirPath);
            if (!plugins_dir.Exists)
            {
                plugins_dir.Create();
                return;
            }
            FileInfo[] dll_files = plugins_dir.GetFiles("*.dll");
            foreach (FileInfo file in dll_files)
            {
                Assembly asm = Assembly.LoadFrom(file.FullName);
                Type plugin_interface_type = typeof(IPlugin);
                Type[] types = asm.GetTypes().Where(p => plugin_interface_type.IsAssignableFrom(p) && p.IsClass).ToArray();                
                foreach (Type type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    Plugins.Add(plugin);
                }

                Type adaptee_interface_type = typeof(yakov::IRabinCrypter);                
                Type[] adaptee_types = asm.GetTypes().Where(p => adaptee_interface_type.IsAssignableFrom(p) && p.IsClass).ToArray();
                foreach (Type type in adaptee_types)
                {
                    var adaptee = (yakov::IRabinCrypter)asm.CreateInstance(type.FullName);
                    var adapter = (IPlugin)(new RabinCrypterPluginAdapter(adaptee));
                    Plugins.Add(adapter);
                }
            }
        }
    }
}
