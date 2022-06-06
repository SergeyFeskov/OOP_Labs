using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Lab3.Furnitures
{
    public class Furniture
    {
        public string ClassName { get; set; }

        public Furniture()
        {
            Name = "Aboba" + Random.Shared.NextInt64(1, 999);            
            Producer = "IKEA";
            ClassName = "Furniture";
        }

        public Furniture(string name)
        {
            Name = name;            
            Producer = "IKEA";
            ClassName = "Furniture";
        }

        public override string ToString()
        {
            return $"{ClassName} '{Name}'\nProducer: {Producer}\nPrice: {Price:f4}\nWarranty: {Warranty}\n" +
                $"OverallLength: {OverallLength}\nOverallWidth: {OverallWidth}\nOverallHeight: {OverallHeight}\n";
        }

        public static Furniture GetFurniture()
        {
            return new Furniture();
        }

        public virtual List<(string name, TypeCode type)> GetFieldsInfo()
        {
            return new List<(string name, TypeCode type)>
            {
                ("Name", TypeCode.String),
                ("Producer", TypeCode.String),
                ("Price", TypeCode.Double),
                ("Warranty", TypeCode.Int32),
                ("OverallLength", TypeCode.Double),
                ("OverallWidth", TypeCode.Double),
                ("OverallHeight", TypeCode.Double),
            };
        }

        public virtual void SetFields(Dictionary<string,string> fields_values)
        {
            Name = fields_values["Name"];
            Producer = fields_values["Producer"];
            Price = Double.Parse(fields_values["Price"]);
            Warranty = Int32.Parse(fields_values["Warranty"]);
            OverallLength = Double.Parse(fields_values["OverallLength"]);
            OverallWidth = Double.Parse(fields_values["OverallWidth"]);
            OverallHeight = Double.Parse(fields_values["OverallHeight"]);
        }        

        public virtual Dictionary<string, string> GetFields()
        {
            return new Dictionary<string, string>()
            {
                {"Name", Name},
                {"Producer", Producer},
                {"Price", Price.ToString()},
                {"Warranty", Warranty.ToString()},
                {"OverallLength", OverallLength.ToString()},
                {"OverallWidth", OverallWidth.ToString()},
                {"OverallHeight", OverallHeight.ToString()},
            };
        }

        public string Name { get; set; }       
        public string Producer { get; set; }

        public double Price { get; set; }  // in BYN
        public int Warranty { get; set; }  // in months        

        // in meters
        public double OverallLength { get; set; }
        public double OverallWidth { get; set; }
        public double OverallHeight { get; set; }
    }
}
