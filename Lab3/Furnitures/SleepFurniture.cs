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

        // in meters
        public double SleepPlaceLength { get; set; }
        public double SleepPlaceWidth { get; set; }
    }
}
