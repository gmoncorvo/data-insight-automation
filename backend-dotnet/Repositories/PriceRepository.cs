using backend_dotnet.Data;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class PriceRepository
    {
        private readonly AppDbContext _context;

        public PriceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PriceHistory>> GetAllAsync(
            int page,
            int pageSize,
            decimal? minPrice,
            decimal? maxPrice,
            string? sort)
        {
            var query = _context.PriceHistories.AsQueryable();

            // Filtro por preço
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            // Ordenação
            query = sort switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "date_asc" => query.OrderBy(p => p.Timestamp),
                "date_desc" => query.OrderByDescending(p => p.Timestamp),
                _ => query.OrderByDescending(p => p.Id)
            };

            // Paginação
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<PriceHistory> AddAsync(PriceHistory price)
        {
            _context.PriceHistories.Add(price);
            await _context.SaveChangesAsync();
            return price;
        }

        public async Task<List<PriceHistory>> GetByAssetNameAsync(string assetName)
        {
            return await _context.PriceHistories
                .Where(p => p.AssetName.ToLower() == assetName.ToLower())
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.PriceHistories.CountAsync();
        }

        public async Task<int> CountAsync(decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.PriceHistories.AsQueryable();

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return await query.CountAsync();
        }
    }
}