using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6
{
    public class PluginsProxy : IPlugin
    {
        private readonly IPlugin plugin;
        private string? cachedParseInRes;
        private string? cachedParseOutRes;
        
        public PluginsProxy(IPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string Name { get { return plugin.Name; } }
        public string Description { get { return plugin.Description; } }
        public string ParseIn(string input)
        {
            if (cachedParseInRes == null || cachedParseOutRes == null || cachedParseOutRes != input)
            {
                cachedParseInRes = plugin.ParseIn(input);
                cachedParseOutRes = input;
            }
            return cachedParseInRes;
        }
        public string ParseOut(string input)
        {
            if (cachedParseOutRes == null || cachedParseInRes == null || cachedParseInRes != input)
            {
                cachedParseOutRes = plugin.ParseOut(input);
                cachedParseInRes = input;
            }
            return cachedParseOutRes;
        }
    }
}
