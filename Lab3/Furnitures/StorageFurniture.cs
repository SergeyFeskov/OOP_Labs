using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Furnitures
{
    public class StorageFurniture : Furniture
    {
        public StorageFurniture() : base()
        {            
            ClassName = "StorageFurniture";
        }

        public StorageFurniture(string name) : base(name)
        {
            ClassName = "StorageFurniture";
        }

        public override string ToString()
        {
            return base.ToString() + $"CellsNum: {CellsNum}\nStorageVolume: {StorageVolume:f3}\n";
        }

        public static new StorageFurniture GetFurniture()
        {
            return new StorageFurniture();
        }

        public override List<(string name, TypeCode type)> GetFieldsInfo()
        {
            List<(string name, TypeCode type)> res = base.GetFieldsInfo();
            res.Add(("CellsNum", TypeCode.Int32));
            res.Add(("StorageVolume", TypeCode.Double));
            return res;
        }

        public override void SetFields(Dictionary<string, string> fields_values)
        {
            base.SetFields(fields_values);
            CellsNum = Int32.Parse(fields_values["CellsNum"]);
            StorageVolume = Double.Parse(fields_values["StorageVolume"]);
        }

        public override Dictionary<string, string> GetFields()
        {
            Dictionary<string, string> res = base.GetFields();
            res.Add("CellsNum", CellsNum.ToString());
            res.Add("StorageVolume", StorageVolume.ToString());
            return res;
        }

        public int CellsNum { get; set; }
        public double StorageVolume { get; set; }  // in m^3
    }
}
