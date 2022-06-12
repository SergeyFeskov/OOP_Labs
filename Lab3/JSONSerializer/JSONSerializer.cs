using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Furnitures;
using Newtonsoft.Json;
using Lab5_6;

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
    }
}
