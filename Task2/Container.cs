namespace Task2
{
    public abstract class Container
    {
        private static readonly List<int> ExistingIds = new List<int>();
        protected Container(string containerType,double height,double depth, Cargo? cargoInfo, double tareWeight, double maxPayload)
        {
            SerialNumber = GenerateSerialNumber(containerType);
            CargoInfo = cargoInfo;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
        }

        protected Container()
        {
            
        }

        public string SerialNumber { get; set; } = "";
        protected Cargo CargoInfo { get; set; }
        public double Height { get; }
       public double TareWeight { get; set; } = 0; 
       public double Depth { get; }
       public double MaxPayload { get; set; } = 0;

        public double GetCurrentTotalWeight() => CargoInfo!.Mass + TareWeight;
        
        public abstract void LoadCargo(Cargo? cargoInfo);
        public abstract void EmptyCargo();
        
        public static string GenerateSerialNumber(string type)
        {
            var id = ExistingIds.Count;
            ExistingIds.Add(id);
            return $"KON-{type}-{id}";
        }

        public static Container GetContainerType(string type)
        {
            switch (type)
            {
                case "B" : return new GasContainer();
                case "C" : return new RefrigeratedContainer();
                default: return new LiquidContainer();
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"{GetType().Name} with serial number:{SerialNumber} cargo mass:{CargoInfo.Mass}/{MaxPayload} tare weight:{TareWeight}  total weight:{GetCurrentTotalWeight()}  product: {CargoInfo}";
        }
    }
}
