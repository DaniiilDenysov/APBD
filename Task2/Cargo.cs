namespace Task2;

public class Cargo
{
    public string Name { get; }
    public double Mass { get; set; } = 0;

    public bool Hazardous { get; set; }

    public double Temperature { get; set; }

    public Cargo (string name,double mass)
    {
        Name = name;
        Mass = mass;
        GetRecommendedTemperature();
    }

    public void GetRecommendedTemperature()
    {
        var data = ProductsDatabase.GetData(Name);
        if (data != null)
        {
            Temperature = data.Item1;
            Hazardous = data.Item2;
        }
    }
}