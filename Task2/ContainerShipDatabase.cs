namespace Task2;

public class ContainerShipDatabase
{
    private static readonly List<ContainerShip?> Ships = new List<ContainerShip?>();


    public static void AddShip(ContainerShip? ship)
    {
        Ships.Add(ship);
    }

    public static void PrintContainerShips()
    {
        Console.WriteLine("Available ships:");
        foreach (ContainerShip? containerShip in Ships)
        {
            Console.WriteLine(containerShip);
        }
    }
    
    public static void RemoveShip(string? name)
    {
        if (Exists(name))
        {
            Ships.Remove(GetShipByName(name));
            Console.WriteLine($"{name} has been removed successfully!");
        }
      else Console.WriteLine($"Unable to remove not existing container ship with name {name}");
    }

    public static ContainerShip? GetShipByName(string? name)
    {
        return Ships.Find(c => c?.Name == name);
    }

    private static bool Exists(string? name)
    {
        return GetShipByName(name)!=null;
    }
    
}