using Lab3.JSONSerializer;
using Lab3.Furnitures;
using Lab3.Parsers;
using Lab4;
using Lab5_6;

class Program
{
    delegate Furniture GetFurnitureDelegate();
    static List<GetFurnitureDelegate> furniture_constructors = new List<GetFurnitureDelegate>()
    {
        Furniture.GetFurniture,
        SleepFurniture.GetFurniture,
        Bed.GetFurniture,
        Sofa.GetFurniture,
        StorageFurniture.GetFurniture,
        Wardrobe.GetFurniture,
        Dresser.GetFurniture,
        Table.GetFurniture,
    };

    static List<Furniture> furnitures = new List<Furniture>();
    static readonly string json_file = "furniture.json";
    
    static readonly string plugins_dir = System.IO.Path.Combine(
                                                Directory.GetCurrentDirectory(),
                                                "Plugins");
    static PluginsLoader plugins_loader;

    static void Main()
    {
        plugins_loader = PluginsLoader.GetPluginsLoader(plugins_dir);        
        while (true)
        {
            Console.Clear();
            if (OutputFurnitureList(furnitures) == 0)
            {
                Console.WriteLine("No furniture in list!");
            }
            Console.Write('\n');
            Console.WriteLine("1. Add furniture");
            Console.WriteLine("2. Delete furniture");
            Console.WriteLine("3. View furniture info");
            Console.WriteLine("4. Change furniture fields");
            Console.WriteLine("5. Save list to JSON file");
            Console.WriteLine("6. Load list from JSON file");
            Console.WriteLine("7. Exit");
            Console.Write('\n');
            Console.Write("Enter operation number: ");
            long opNum;
            while (!Int64.TryParse(Console.ReadLine(), out opNum) || (opNum < 1 || opNum > 7))
            {
                Console.Write("Enter operation number: ");
            }
            switch (opNum)
            {
                case 1:
                    AddToList();
                    break;
                case 2:
                    DeleteFromList();
                    break;
                case 3:
                    ViewFurnitureInfo();
                    break;
                case 4:
                    ChangeFurnitureFields();
                    break;
                case 5:
                    SaveToFile(furnitures);
                    break;
                case 6:
                    LoadFromFile(ref furnitures);
                    break;
                case 7:
                    return;                   
            }
        }       
    }

    static void ChangeFurnitureFields()
    {
        Console.Clear();
        int ind = ReadFurnitureInd();        
        if (ind == -1)
        {
            return;
        }
        Dictionary<string, string> fields_values = furnitures[ind].GetFields();
        List<(string name, TypeCode type)> fields_info = furnitures[ind].GetFieldsInfo();            
        while (true)
        {
            Console.Clear();
            int count = 0;
            foreach (var field in fields_info)
            {
                Console.WriteLine($"{++count}) {field.name}");
            }
            Console.WriteLine();
            Console.Write("Enter number of field, you want to change (to save changes enter 'done'): ");
            string str = Console.ReadLine();
            if (str == "done")
            {
                Console.Clear();                
                furnitures[ind].SetFields(fields_values);
                Console.WriteLine("Fields values changed!");
                Console.ReadKey();
                return;
            }
            int fieldNum;
            while (!Int32.TryParse(str, out fieldNum) || (fieldNum < 1 || fieldNum > fields_values.Count))
            {
                Console.Write("Enter number of field, you want to change (to save changes enter 'done'): ");
                str = Console.ReadLine();
                if (str == "done")
                {
                    Console.Clear();
                    furnitures[ind].SetFields(fields_values);
                    Console.WriteLine("Fields values changed!");
                    Console.ReadKey();
                    return;
                }                
            }
            Console.Clear();
            Console.Write($"{fields_info[fieldNum - 1].name} (past value '{fields_values[fields_info[fieldNum - 1].name]}'): ");
            string field_value = Console.ReadLine();
            while (!Checker.Checkers[fields_info[fieldNum - 1].type](field_value))
            {
                Console.Write($"Enter correct '{fields_info[fieldNum - 1].name}' (past value '{fields_values[fields_info[fieldNum - 1].name]}'): ");
                field_value = Console.ReadLine();
            }
            fields_values[fields_info[fieldNum - 1].name] = field_value;
        }        
    }

    static void ViewFurnitureInfo()
    {
        Console.Clear();
        int ind = ReadFurnitureInd();
        Console.Clear();
        if (ind == -1)
        {            
            return;
        }
        Console.Write(furnitures[ind].ToString());
        Console.ReadKey();
    }

    static void DeleteFromList()
    {
        Console.Clear();
        int ind = ReadFurnitureInd();
        Console.Clear();
        if (ind == -1)
        {            
            return;
        }
        furnitures.RemoveAt(ind);
        Console.WriteLine("Furniture is deleted!");
        Console.ReadKey();
    }

    static int ReadFurnitureInd()
    {
        if (OutputFurnitureList(furnitures) == 0)
        {
            Console.WriteLine("No furniture in list!");
            Console.ReadKey();
            return -1;
        }
        Console.WriteLine();
        Console.Write("Enter number of needed furniture: ");
        int furnitureNum;
        while (!Int32.TryParse(Console.ReadLine(), out furnitureNum) || (furnitureNum < 1 || furnitureNum > furnitures.Count))
        {
            Console.Write("Enter number of needed furniture: ");
        }
        return furnitureNum - 1;
    }

    static void AddToList()
    {
        Console.Clear();
        Console.WriteLine("1. Furniture");
        Console.WriteLine("2. SleepFurniture");
        Console.WriteLine("3. Bed");
        Console.WriteLine("4. Sofa");
        Console.WriteLine("5. StorageFurniture");
        Console.WriteLine("6. Wardrobe");
        Console.WriteLine("7. Dresser");
        Console.WriteLine("8. Table");
        Console.WriteLine();
        Console.Write("Enter number of type, which corresponds the best way to new furniture: ");
        int typeNum;
        while (!Int32.TryParse(Console.ReadLine(), out typeNum) || (typeNum < 1 || typeNum > 8))
        {
            Console.Write("Enter number of type: ");
        }
        
        Console.Clear();
        Furniture furniture = furniture_constructors[typeNum - 1]();
        List<(string name, TypeCode type)> fields = furniture.GetFieldsInfo();
        Dictionary<string,string> fields_values = new Dictionary<string,string>();
        Console.WriteLine("Enter furniture characteristics.");
        foreach (var field in fields)
        {
            Console.Write($"{field.name}: ");
            string field_value = Console.ReadLine();
            while (!Checker.Checkers[field.type](field_value))
            {
                Console.Write($"Enter correct '{field.name}': ");
                field_value = Console.ReadLine();
            }
            fields_values.Add(field.name, field_value);
        }
        furniture.SetFields(fields_values);
        furnitures.Add(furniture);

        Console.Clear();
        Console.WriteLine($"{furniture.ClassName} '{furniture.Name}' added to list!");
        Console.ReadKey();
    }

    static void LoadFromFile(ref List<Furniture> furnitures)
    {
        Console.Clear();
        if (!File.Exists(json_file))
        {
            Console.WriteLine($"'{json_file}' doesn't exist!");
        } 
        else
        {
            string header;
            string content;
            using (StreamReader reader = new StreamReader(json_file, System.Text.Encoding.UTF8))
            {
                header = reader.ReadLine();
                content = reader.ReadToEnd();
            }
            if (header != "")
            {
                IPlugin plugin;
                try
                {
                    plugin = plugins_loader.Plugins.Where(p => p.Name == header).First();
                } catch (InvalidOperationException) {
                    Console.WriteLine($"ERROR: plugin '{header}' not found in loaded plugins!");
                    Console.WriteLine("Furniture list can't be loaded.");
                    Console.ReadKey(true);
                    return;
                }                
                content = plugin.ParseOut(content);                
            }
            furnitures = JSONSerializer.Deserialize<List<Furniture>>(content);
            Console.WriteLine($"List loaded from '{json_file}'!");
        }        
        Console.ReadKey();        
    }

    static void SaveToFile(List<Furniture> furnitures)
    {
        Console.Clear();
        string json_string = JSONSerializer.Serialize(furnitures);
        string header = "";
        string string_to_save = json_string;                
        if (plugins_loader.Plugins.Count != 0)
        {
            Console.WriteLine("Do you want to process furniture list before saving? (type 'yes' or 'no')");
            string answer = Console.ReadLine();            
            while (!String.Equals(answer, "yes") && !String.Equals(answer, "no"))
            {
                Console.Write("Type 'yes' or 'no': ");
                answer = Console.ReadLine();
            }            
            if (answer == "yes")
            {
                Console.Clear();
                int count = 0;
                foreach (IPlugin plugin in plugins_loader.Plugins)
                {
                    Console.WriteLine($"{++count}) {plugin.Name} ({plugin.Description})");
                }
                Console.WriteLine();
                Console.Write("Enter number of plugin-processor, which will process furniture list: ");
                int pluginNum;
                while (!Int32.TryParse(Console.ReadLine(), out pluginNum) || (pluginNum < 1 || pluginNum > count))
                {
                    Console.Write("Enter number of plugin-processor: ");
                }
                IPlugin curr_plugin = plugins_loader.Plugins[pluginNum - 1];
                header = curr_plugin.Name;
                string_to_save = curr_plugin.ParseIn(json_string);
                Console.Clear();
            }           
        }            
        File.WriteAllText(json_file, header + "\n" + string_to_save);
        Console.WriteLine($"List saved to '{json_file}'!");
        Console.ReadKey();
    }

    static int OutputFurnitureList(List<Furniture> list)
    {
        int count = 0;
        foreach (Furniture furniture in list)
        {                        
            Console.WriteLine($"{++count}) {furniture.ClassName} '{furniture.Name}'");           
        }
        return count;
    }
}