namespace backend_dotnet.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}