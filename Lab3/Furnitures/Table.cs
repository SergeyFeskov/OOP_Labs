using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class Table : Furniture
    {
        public Table() : base()
        {
            Form = "";
            CountertopMaterial = "";
            ClassName = "Table";
        }

        public Table(string name) : base(name)
        {
            Form = "";
            CountertopMaterial = "";
            ClassName = "Table";
        }

        public string Form { get; set; }
        public string CountertopMaterial { get; set; }
        public bool IsFolding { get; set; }
    }
}
