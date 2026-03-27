namespace backend_dotnet.DTOs
{
    public class PriceResponseDto
    {
        public int Id { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}