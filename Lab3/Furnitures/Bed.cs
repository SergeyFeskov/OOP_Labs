using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class Bed : SleepFurniture
    {
        public Bed() : base()
        {
            FrameMaterial = "Metall";
            BackMaterial = "Wood";
            ClassName = "Bed";
        }

        public Bed(string name) : base(name)
        {
            FrameMaterial = "Metall";
            BackMaterial = "Wood";
            ClassName = "Bed";
        }

        public override string ToString()
        {
            return base.ToString() + $"FrameMaterial: {FrameMaterial}\nBackMaterial: {BackMaterial}\nHasMattress: {(HasMattress ? "yes" : "no")}\n";
        }

        public static new Bed GetFurniture()
        {
            return new Bed();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("FrameMaterial", TypeCode.String));
            res.Add(("BackMaterial", TypeCode.String));
            res.Add(("HasMattress", TypeCode.Boolean));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            FrameMaterial = fields_values["FrameMaterial"];
            BackMaterial = fields_values["BackMaterial"];
            HasMattress = (fields_values["HasMattress"] == "yes") ? true : false;
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("FrameMaterial", FrameMaterial);
            res.Add("BackMaterial", BackMaterial);
            res.Add("HasMattress", (HasMattress ? "yes" : "no"));
            return res;
        }

        public string FrameMaterial { get; set; }
        public string BackMaterial { get; set; }
        public bool HasMattress { get; set; }
    }
}
