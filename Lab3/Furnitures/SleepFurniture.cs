using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class SleepFurniture : Furniture
    {
        public SleepFurniture() : base()
        {
            ClassName = "SleepFurniture";
        }

        public SleepFurniture(string name) : base(name)
        {
            ClassName = "SleepFurniture";   
        }

        public override string ToString()
        {
            return base.ToString() + $"SleepPlaceLenght: {SleepPlaceLength}\nSleepPlaceWidth: {SleepPlaceWidth}\n";
        }

        public static new SleepFurniture GetFurniture()
        {
            return new SleepFurniture();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)>  res = base.GetFieldsInfo();
            res.Add(("SleepPlaceLength", TypeCode.Double));
            res.Add(("SleepPlaceWidth", TypeCode.Double));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            SleepPlaceLength = Double.Parse(fields_values["SleepPlaceLength"]);
            SleepPlaceWidth = Double.Parse(fields_values["SleepPlaceWidth"]);
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("SleepPlaceLength", SleepPlaceLength.ToString());
            res.Add("SleepPlaceWidth", SleepPlaceWidth.ToString());
            return res;
        }

        // in meters
        public double SleepPlaceLength { get; set; }
        public double SleepPlaceWidth { get; set; }
    }
}
