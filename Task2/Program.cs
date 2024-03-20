namespace Task2
{
    public class Program
    {
        private Dictionary<string?, Action?> _commands = new Dictionary<string?, Action?>();

        private bool _isAlive = true;
        
        public static void Main(string[] args)
        {
           ProductsDatabase.Initialize();  
           Program p = new Program();
           p.Loop();

        }

        public void LoadContainerToShip()
        {
            Console.WriteLine("Please provide name of the ship:");
            string name = Console.ReadLine() ?? "No name";
            ContainerShip? ship = ContainerShipDatabase.GetShipByName(name);
            if (ship == null)
            {
                Console.WriteLine($"Ship with name {name} doesn't exist!");
                return;
            }
            Console.WriteLine("Please serial number of the container:");
            string serialNumber = Console.ReadLine() ?? "";
            Container? container = ContainerDatabase.GetBySerialNumber(serialNumber);
            if (container == null)
            {
                Console.WriteLine($"Container with serial number {serialNumber} doesn't exist!");
                return;
            }
            ship!.AddContainer(container!);
        }

        public void InitializeCommands()
        {
            _commands.Add("Add container ship",AddContainerShip);
            _commands.Add("Remove container ship",RemoveContainerShip);
            _commands.Add("Add container",AddContainer);
            _commands.Add("Load container onto ship",LoadContainerToShip);
            _commands.Add("Exit",Exit);
        }

        public void AddContainerShip()
        {
            Console.WriteLine("Please provide container ship name:");
            string name = Console.ReadLine() ?? "No name";
            Console.WriteLine("Please provide max speed:");
            int maxSpeed = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please provide max container number:");
            int maxContainerNumber = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please provide max weight:");
            double maxContainerWeight = double.Parse(Console.ReadLine() ?? "0");
            ContainerShip ship = new ContainerShip(name, maxSpeed, maxContainerNumber, maxContainerWeight);
            Console.WriteLine($"{ship} has been added!");
            ContainerShipDatabase.AddShip(ship);
        }
        
        public void RemoveContainerShip()
        {
            Console.WriteLine("Please provide container ship name:");
            string? name = Console.ReadLine();
            ContainerShipDatabase.RemoveShip(name);
        }

        public void AddContainer()
        {
            Console.WriteLine("Please provide container type (A,B,C):");
            string name = Console.ReadLine() ?? "A";
            var container = (Container)Activator.CreateInstance(Container.GetContainerType(name))!;
            Console.WriteLine("Please provide tare weight:");
            double.TryParse(Console.ReadLine(),out double tareWeight);
            Console.WriteLine("Please provide max payload:");
            double.TryParse(Console.ReadLine(),out double maxPayload);
            Console.WriteLine("Please provide product name:");
            string product = Console.ReadLine() ?? "Fish";
            Console.WriteLine("Please provide product weight:");
            double.TryParse(Console.ReadLine(), out double productMass);
            container.SerialNumber = Container.GenerateSerialNumber(name);
            container.TareWeight = tareWeight;
            container.MaxPayload = maxPayload;
            Cargo cargo = new Cargo(product, productMass);
            container.LoadCargo(cargo);
            ContainerDatabase.AddContainer(container);
        }

        public void Exit()
        {
            Console.WriteLine("Thank you for running this application! Have a nice day!");
            _isAlive = false;
        }

        private void Loop ()
        {
            InitializeCommands();
            while (_isAlive)
            {
                ContainerShipDatabase.PrintContainerShips();
                ContainerDatabase.PrintContainers();
                ShowMenu();
                string? command = Console.ReadLine();
                if (_commands.TryGetValue(command,out Action? action))
                {
                    action?.Invoke();
                }
                else
                {
                    Console.WriteLine("Wrong command!");
                }
            }
        }

        public void ShowMenu()
        {
            int count = 1;
            foreach (var keyValuePair in _commands)
            {
                Console.WriteLine($"{count}.{keyValuePair.Key}");
                count++;
            }
        }
    }
}