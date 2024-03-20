namespace Task2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        
        private float _payloadLimiter = 1f;
        
        // public LiquidContainer(string containerType, Cargo? cargoInfo, double tareWeight, double maxPayload) 
        //     : base(containerType, cargoInfo, tareWeight, maxPayload)
        // {
        //     _payloadLimiter = CargoInfo.Hazardous ? 0.5f : 0.9f;
        // }
        
        public LiquidContainer() : base()
        {
            
        }
                                        
        public override void LoadCargo(Cargo? cargoInfo)
        {
            _payloadLimiter = cargoInfo!.Hazardous ? 0.5f : 0.9f;
            if(cargoInfo!.Mass>MaxPayload*_payloadLimiter)
            {
               if (!cargoInfo.Hazardous) throw new OverfillException("Cargo mass exceeds maximum payload.");
               else NotifyHazard($"Hazardous situation {SerialNumber}");
            }
            CargoInfo = cargoInfo;
        }

        public override void EmptyCargo()
        {
            CargoInfo!.Mass = 0;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine(message);
        }
    }
}
