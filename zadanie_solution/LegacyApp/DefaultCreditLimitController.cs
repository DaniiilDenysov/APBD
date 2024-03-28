namespace LegacyApp
{
    public class DefaultCreditLimitController : ICreditLimitController
    {

        public int AdjustCreditLimit(Client.Tag type,int creditLimit)
        {
            return type switch
            {
                Client.Tag.VeryImportantClient => int.MaxValue,
                Client.Tag.ImportantClient => creditLimit * 2,
                _ => creditLimit
            };
        }
    }
}