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

        public async Task<List<PriceHistory>> GetAllAsync(int page, int pageSize)
        {
            return await _context.PriceHistories
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
    }
}