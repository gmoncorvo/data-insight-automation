namespace backend_dotnet.DTOs
{
    public class CreatePriceDto
    {
        public string AssetName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}