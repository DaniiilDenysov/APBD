namespace LegacyApp
{
    public class Client
    {
        public int ClientId { get; internal set; }
        public Address ClientAddress { get; internal set; }
        public Tag Type { get; set; }
        
        public enum Tag
        {
            VeryImportantClient,
            ImportantClient,
            NormalClient
        }
    }
}