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
            Form = "Circle";
            CountertopMaterial = "Wood";
            ClassName = "Table";
        }

        public Table(string name) : base(name)
        {
            Form = "Circle";
            CountertopMaterial = "Wood";
            ClassName = "Table";
        }

        public override string ToString()
        {
            return base.ToString() + $"Form: {Form}\nCounertopMaterial: {CountertopMaterial}\nIsFolding: {(IsFolding ? "yes" : "no")}\n";
        }

        public static new Table GetFurniture()
        {
            return new Table();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("Form", TypeCode.String));
            res.Add(("CountertopMaterial", TypeCode.String));
            res.Add(("IsFolding", TypeCode.Boolean));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            Form = fields_values["Form"];
            CountertopMaterial = fields_values["CountertopMaterial"];
            IsFolding = (fields_values["IsFolding"] == "yes") ? true : false;
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("Form", Form);
            res.Add("CountertopMaterial", CountertopMaterial);
            res.Add("IsFolding", (IsFolding ? "yes" : "no"));
            return res;
        }

        public string Form { get; set; }
        public string CountertopMaterial { get; set; }
        public bool IsFolding { get; set; }
    }
}
