using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Lab3.Furnitures;

namespace Lab3.JSONSerializer
{
    internal class JSONSerializer
    {
        private static readonly JsonSerializerOptions SerializeOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,           
        };

        private static readonly JsonSerializerOptions DeserializeOptions = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,            
        };

        public static string Serialize<T>(T obj)
        {            
            return JsonSerializer.Serialize<T>(obj, SerializeOptions);
        }

        public static string Serialize(object obj, Type type)
        {            
            return JsonSerializer.Serialize(obj, type, SerializeOptions);
        }

        public static T Deserialize<T>(string json)
        {            
            object? obj = JsonSerializer.Deserialize<T>(json, DeserializeOptions);
            if (obj == null)
                throw new Exception("Deserialize method returned null.");
            return (T)obj;
        }

        public static object Deserialize(string json, Type type)
        {            
            object? obj = JsonSerializer.Deserialize(json, type, DeserializeOptions);
            if (obj == null)
                throw new Exception("Deserialize method returned null.");
            return obj;
        }

        public static void SaveAsJSON<T>(string path, T obj)
        {
            string json = JSONSerializer.Serialize<T>(obj);
            using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        public static T LoadFromJSON<T>(string path)
        {           
            string json;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return JSONSerializer.Deserialize<T>(json);
        }

        public static void SaveFurnitureListAsJSON(List<Furniture> list, string path)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[\n");
            foreach (Furniture furniture in list)
            {
                json.Append(JSONSerializer.Serialize(furniture, Furniture.FurnitureTypes[furniture.ClassName]) + ",\n");
            }
            json.Append("]\n");
            
            using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        //public static List<Furniture> LoadFurnitureListFromJSON(string path)
        //{
        //    string json;
        //    using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
        //    {
        //        json = reader.ReadToEnd();
        //    }
        //    return JSONSerializer.Deserialize<T>(json);
        //}
    }
}
