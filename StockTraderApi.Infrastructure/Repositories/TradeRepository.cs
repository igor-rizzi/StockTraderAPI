using Microsoft.EntityFrameworkCore;
using StockTraderApi.Domain.Entities;
using StockTraderApi.Domain.Interfaces.Repositories;
using StockTraderApi.Infrastructure.Context;

namespace StockTraderApi.Infrastructure.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly StockTraderDbContext _context;

        public TradeRepository(StockTraderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(string userId)
        => await _context.Trades
                .Where(t => t.UserId == userId)
                .ToListAsync();

        public async Task<Trade> GetTradeByIdAsync(long tradeId)
        => await _context.Trades
                .FirstOrDefaultAsync(t => t.CodigoTrade == tradeId);
    }
}
