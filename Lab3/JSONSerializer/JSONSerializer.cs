using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Furnitures;
using Newtonsoft.Json;

namespace Lab3.JSONSerializer
{
    internal class JSONSerializer
    {
        private static readonly JsonSerializerSettings SerializeOptions = new JsonSerializerSettings()
        { 
            TypeNameHandling = TypeNameHandling.All,
        };

        public static string Serialize<T>(T obj)
        {

            return JsonConvert.SerializeObject(obj, SerializeOptions);
        }

        public static T Deserialize<T>(string json)
        {
            T? obj = JsonConvert.DeserializeObject<T>(json, SerializeOptions);
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
    }
}
