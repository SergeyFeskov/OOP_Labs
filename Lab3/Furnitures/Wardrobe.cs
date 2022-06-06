using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class Wardrobe : StorageFurniture
    {
        public Wardrobe() : base()
        {
            ClassName = "Wardrobe";
        }

        public Wardrobe(string name) : base(name)
        {
            ClassName = "Wardrobe";
        }

        public override string ToString()
        {
            return base.ToString() + $"DoorsNum: {DoorsNum}\nHasMirrors: {(HasMirrors ? "yes" : "no")}\nIsCloset: {(IsCloset ? "yes" : "no")}\n";
        }

        public static new Wardrobe GetFurniture()
        {
            return new Wardrobe();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("DoorsNum", TypeCode.Int32));
            res.Add(("HasMirrors", TypeCode.Boolean));
            res.Add(("IsCloset", TypeCode.Boolean));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            DoorsNum = Int32.Parse(fields_values["DoorsNum"]);
            HasMirrors = (fields_values["HasMirrors"] == "yes") ? true : false;
            IsCloset = (fields_values["IsCloset"] == "yes") ? true : false;
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("DoorsNum", DoorsNum.ToString());            
            res.Add("HasMirrors", (HasMirrors ? "yes" : "no"));
            res.Add("IsCloset", (IsCloset ? "yes" : "no"));
            return res;
        }

        public int DoorsNum { get; set; }
        public bool HasMirrors { get; set; }
        public bool IsCloset { get; set; }
    }
}
