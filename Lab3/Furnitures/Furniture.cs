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
        public static Dictionary<string, Type> FurnitureTypes = new Dictionary<string, Type>()
        {
            ["Furniture"] = typeof (Furniture),
            ["SleepFurniture"] = typeof (SleepFurniture),
        };

        public string ClassName { get; set; }

        public Furniture()
        {
            Name = "";            
            Producer = "";
            ClassName = "Furniture";
        }

        public Furniture(string name)
        {
            Name = name;            
            Producer = "";
            ClassName = "Furniture";
        }

        public override string ToString()
        {
            return $"{ClassName} '{Name}'\nProducer: {Producer}\nPrice: {Price:f4}\nWarranty: {Warranty}\n" +
                $"OverallLength: {OverallLength}\nOverallWidth: {OverallWidth}\nOverallHeight: {OverallHeight}\n";
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
