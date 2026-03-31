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

        public async Task<(List<PriceResponseDto> Prices, int TotalItems)> GetAllPricesAsync(int page, int pageSize)
        {
            var prices = await _repository.GetAllAsync(page, pageSize);
            var totalItems = await _repository.CountAsync();

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