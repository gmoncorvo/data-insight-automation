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

        public async Task<List<PriceHistory>> GetAllAsync()
        {
            return await _context.PriceHistories.ToListAsync();
        }

        public async Task<PriceHistory> AddAsync(PriceHistory price)
        {
            _context.PriceHistories.Add(price);
            await _context.SaveChangesAsync();
            return price;
        }
    }
}