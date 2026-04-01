using backend_dotnet.DTOs;
using backend_dotnet.Models;
using backend_dotnet.Repositories;

namespace backend_dotnet.Services
{
    public class PriceService
    {
        private readonly PriceRepository _repository;

        public PriceService(PriceRepository repository)
        {
            _repository = repository;
        }

       public async Task<(List<PriceResponseDto>, int)> GetAllPricesAsync(PriceQueryParams queryParams)
        {
            if (queryParams.Page <= 0)
            {
                throw new ArgumentException("O parâmetro 'Page' deve ser maior que zero.");
            }

            if (queryParams.PageSize <= 0)
            {
                throw new ArgumentException("O parâmetro 'PageSize' deve ser maior que zero.");
            }

            if (queryParams.PageSize > 50)
            {
                throw new ArgumentException("O parâmetro 'PageSize' não pode ser maior que 50.");
            }

            if (queryParams.MinPrice.HasValue && queryParams.MinPrice < 0)
            {
                throw new ArgumentException("O parâmetro 'MinPrice' não pode ser negativo.");
            }

            if (queryParams.MaxPrice.HasValue && queryParams.MaxPrice < 0)
            {
                throw new ArgumentException("O parâmetro 'MaxPrice' não pode ser negativo.");
            }

            if (queryParams.MinPrice.HasValue && queryParams.MaxPrice.HasValue &&
                queryParams.MinPrice > queryParams.MaxPrice)
            {
                throw new ArgumentException("O parâmetro 'MinPrice' não pode ser maior que 'MaxPrice'.");
            }    

            var prices = await _repository.GetAllAsync(
                queryParams.Page,
                queryParams.PageSize,
                queryParams.MinPrice,
                queryParams.MaxPrice,
                queryParams.Sort
            );

            var totalItems = await _repository.CountAsync(
                queryParams.MinPrice,
                queryParams.MaxPrice
            );

            var response = prices.Select(price => new PriceResponseDto
            {
                Id = price.Id,
                AssetName = price.AssetName,
                Price = price.Price,
                Timestamp = price.Timestamp
            }).ToList();

            return (response, totalItems);
        }

        public async Task<PriceResponseDto> AddPriceAsync(CreatePriceDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.AssetName))
            {
                throw new ArgumentException("O nome do ativo é obrigatório.");
            }

            if (dto.Price <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }

            var price = new PriceHistory
            {
                AssetName = dto.AssetName,
                Price = dto.Price,
                Timestamp = DateTime.UtcNow
            };

            var createdPrice = await _repository.AddAsync(price);

            return new PriceResponseDto
            {
                Id = createdPrice.Id,
                AssetName = createdPrice.AssetName,
                Price = createdPrice.Price,
                Timestamp = createdPrice.Timestamp
            };
        }

        public async Task<List<PriceResponseDto>> GetPricesByAssetAsync(string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
            {
                throw new ArgumentException("O nome do ativo é obrigatório.");
            }

            var prices = await _repository.GetByAssetNameAsync(assetName);

            return prices.Select(price => new PriceResponseDto
            {
                Id = price.Id,
                AssetName = price.AssetName,
                Price = price.Price,
                Timestamp = price.Timestamp
            }).ToList();
        }
    }
}