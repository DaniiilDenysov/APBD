namespace Task2;

public class ProductsDatabase
{
    private static Dictionary<string, Tuple<double,bool>> _products = new Dictionary<string,  Tuple<double,bool>>();
    
    public static void Initialize()
    {
        string filePath = "Products.txt";
        if (File.Exists(filePath))
        {
                StreamReader reader = new StreamReader(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] separated = line.Split(";");
                    double val;
                    bool hazardous;
                    double.TryParse(separated[1], out val);
                    bool.TryParse(separated[2], out hazardous);
                    _products.Add(separated[0].ToLower(),new Tuple<double,bool>(val,hazardous));
                   // Console.WriteLine($"{(val,hazardous).val} | {(val,hazardous).hazardous}");
                }
                reader.Close();
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }


    public static Tuple<double,bool> GetData(string name)
    {
        return _products.GetValueOrDefault(name.ToLower(),new Tuple<double,bool>(0,false));
    }
}