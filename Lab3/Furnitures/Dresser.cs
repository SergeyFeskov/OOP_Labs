using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class Dresser : StorageFurniture
    {
        public Dresser() : base()
        {
            ClassName = "Dresser";
        }

        public Dresser(string name) : base(name)
        {
            ClassName = "Dresser";
        }

        public override string ToString()
        {
            return base.ToString() + $"ShelfsNum: {ShelfsNum}\n";
        }

        public static new Dresser GetFurniture()
        {
            return new Dresser();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("ShelfsNum", TypeCode.Int32));            
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);            
            ShelfsNum = Int32.Parse(fields_values["ShelfsNum"]);
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("ShelfsNum", ShelfsNum.ToString());            
            return res;
        }

        public int ShelfsNum { get; set; }
    }
}
