namespace Task2
{
    public class RefrigeratedContainer : Container
    {
        // public RefrigeratedContainer(string containerType, Cargo? cargoInfo, double tareWeight, double maxPayload, string productType, double temperature)
        //     : base(containerType, cargoInfo,  tareWeight, maxPayload)
        // {
        //     ProductType = productType;
        //     Temperature = temperature;
        // }
        
        public RefrigeratedContainer() : base()
        {
            
        }

        public override void EmptyCargo()
        {
            CargoInfo!.Mass = 0;
        }

        public override void LoadCargo(Cargo? cargoInfo)
        {
            if(cargoInfo!.Mass>MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds maximum payload.");
            }
            CargoInfo = cargoInfo;
        }
    }
}
