namespace Task2;

public class ContainerDatabase
{
    private static readonly List<Container?> Containers = new List<Container?>();


    public static void AddContainer(Container? container)
    {
        Containers.Add(container);
    }
    
    public static void PrintContainers()
    {
        Console.WriteLine("Available containers:");
        foreach (Container? container in Containers)
        {
            Console.WriteLine(container);
        }
    }

    public static void RemoveContainer(string serialNumber)
    {
        if (Exists(serialNumber)) Containers.Remove(GetBySerialNumber(serialNumber));
        else Console.WriteLine($"Unable to remove not existing container ship with name {serialNumber}");
    }

    public static Container? GetBySerialNumber (string serialNumber)
    {
        return Containers.Find(c => c?.SerialNumber == serialNumber);
    }

    private static bool Exists(string serialNumber)
    {
        return GetBySerialNumber(serialNumber)!=null;
    }

}