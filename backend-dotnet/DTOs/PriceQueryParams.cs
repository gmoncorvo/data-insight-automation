namespace backend_dotnet.DTOs
{
    public class PriceQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string? Sort { get; set; }
    }
}