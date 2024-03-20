namespace Task2
{
    public class ContainerShip
    {

        public string Name { get; }

        public ContainerShip(string name, int maxSpeed, int maxContainerNumber, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainerNumber = maxContainerNumber;
            MaxWeight = maxWeight;
        }

        public List<Container> Containers { get; } = new List<Container>();
        public int MaxSpeed { get; }
        public int MaxContainerNumber { get; }
        public double MaxWeight { get; }

        public void AddContainer(Container container)
        {
            if (CalculateTotalWeight(Containers) + container.GetCurrentTotalWeight() < MaxWeight && Containers.Count < MaxContainerNumber)
            {
                if (!Containers.Contains(container))
                {
                    Containers.Add(container);
                    Console.WriteLine($"{container.SerialNumber} was loaded onto {Name}");
                }
                else
                {
                    throw new OverfillException("Unable to load same container twice!");
                }
            }
            else
            {
                throw new Exception("Unable to load, exceeded limit!");
            }
        }

        public override string ToString()
        {
            return $"Cargo ship, max speed{MaxSpeed}, maximum number of containers:{MaxContainerNumber},  maximum weight:{MaxWeight}, current load:{CalculateTotalWeight(Containers)}";
        }

        public void AddContainers(List<Container> containers)
        {
            IterateArray(containers, AddContainer);
        }

        public double CalculateTotalWeight (List<Container> containers)
        {
            double count = 0;
            IterateArray(containers,(c)=>count+=c.GetCurrentTotalWeight());
            return count;
        }

        public void IterateArray (List<Container> containers,Action<Container> action)
        {
            foreach (Container c in containers)
            {
                action.Invoke(c);
            }
        }

        public void RemoveContainer(string serialNumber)
        {
            Containers.Remove(GetBySerialNumber(serialNumber));
        }

        public Container GetBySerialNumber(string serialNumber)
        {
            return Containers.Find(c => c.SerialNumber == serialNumber)!;
        }

        public void TransferContainer(ContainerShip? destination, string serialNumber)
        {
            Container? container = GetBySerialNumber(serialNumber);
            RemoveContainer(serialNumber);
            destination!.AddContainer(container);
            Console.WriteLine($"{container.SerialNumber} was transferred from {Name} to {destination.Name}");
        }
        
        
        public void PrintCargoInfo()
        {
            Console.WriteLine($"List of containers on {Name}, current load: {CalculateTotalWeight(Containers)}/{MaxWeight}");       
            IterateArray(Containers,c=>Console.WriteLine(c.ToString()));
           // Console.WriteLine($"List of containers, current load: {CalculateTotalWeight(Containers)}/{MaxWeight}");
        }
        
        public void Replace(string oldSerialNumber, Container newContainer)
        {
            int id = Containers.FindIndex(c=>c.SerialNumber==oldSerialNumber);
            Containers.Insert(id,newContainer);
        }
    }
}