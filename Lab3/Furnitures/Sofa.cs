using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class Sofa : SleepFurniture
    {
        public Sofa() : base()
        {            
            Upholstery = "Leather";
            ClassName = "Sofa";
        }

        public Sofa(string name) : base(name)
        {
            Upholstery = "Leather";
            ClassName = "Sofa";
        }

        public override string ToString()
        {
            return base.ToString() + $"Upholstery: {Upholstery}\nHasArmrests: {(HasArmrests ? "yes" : "no")}\nSeatsNum: {SeatsNum}";
        }

        public static new Sofa GetFurniture()
        {
            return new Sofa();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("Upholstery", TypeCode.String));
            res.Add(("HasArmrests", TypeCode.Boolean));
            res.Add(("SeatsNum", TypeCode.Int32));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            Upholstery = fields_values["Upholstery"];           
            HasArmrests = (fields_values["HasArmrests"] == "yes") ? true : false;
            SeatsNum = Int32.Parse(fields_values["SeatsNum"]);
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("Upholstery", Upholstery);
            res.Add("HasArmrests", (HasArmrests ? "yes" : "no"));
            res.Add("SeatsNum", SeatsNum.ToString());
            return res;
        }

        public string Upholstery { get; set; }
        public bool HasArmrests { get; set; }
        public int SeatsNum { get; set; }
    }
}
