using Lab3.JSONSerializer;
using Lab3.Furnitures;

class Program
{
    static void Main()
    {
        //List<Furniture> list = new List<Furniture>()
        //{
        //    new Furniture("Aboba"),
        //    new SleepFurniture("Sleepy"),
        //    new Furniture("Kraust"),
        //};
        //JSONSerializer.SaveFurnitureListAsJSON(list, "furniture.txt");       

        List<Furniture> list = JSONSerializer.LoadFromJSON<List<Furniture>>("furniture.txt");              
        OutputFurnitureList(list);
        Console.ReadKey();  
    }

    static void OutputFurnitureList(List<Furniture> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No furniture in list.");
            return;
        }

        Console.WriteLine("##################");
        foreach (Furniture furniture in list)
        {
            string str;
            switch (furniture.ClassName)
            {
                case "SleepFurniture":
                    str = ((SleepFurniture)furniture).ToString();
                    break;
                default: 
                    str = furniture.ToString();
                    break;
            }
            Console.Write(str);
            Console.WriteLine("##################");
        }
    }
}