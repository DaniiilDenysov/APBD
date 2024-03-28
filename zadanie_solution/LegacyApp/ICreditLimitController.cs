namespace LegacyApp
{
    public interface ICreditLimitController
    {
        int AdjustCreditLimit(Client.Tag type, int creditLimit);
    }
}