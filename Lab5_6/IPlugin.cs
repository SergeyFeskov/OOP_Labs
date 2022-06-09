using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string ParseIn(string input);
        string ParseOut(string input);
    }
}
