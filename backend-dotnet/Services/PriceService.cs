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

        public async Task<List<PriceHistory>> GetAllPricesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PriceHistory> AddPriceAsync(PriceHistory price)
        {
            price.Timestamp = DateTime.UtcNow;

            return await _repository.AddAsync(price);
        }
    }
}