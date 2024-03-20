namespace Task2
{
    public class GasContainer : Container, IHazardNotifier
    {
        
        // public GasContainer(string containerType,Cargo? cargoInfo, double tareWeight, double maxPayload) 
        //     : base(containerType, cargoInfo,  tareWeight,  maxPayload)
        // {
        //    
        // }

        public GasContainer() : base()
        {
            
        }
        
        public override void LoadCargo(Cargo? cargoInfo)
        {
            if(cargoInfo!.Mass>MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds maximum payload.");
            }
            CargoInfo = cargoInfo;
        }

        public override void EmptyCargo()
        {
            CargoInfo!.Mass -= 0.95f * CargoInfo.Mass;
        }
        

        public void NotifyHazard(string message)
        {
            Console.WriteLine(message);
        }
    }
}
