using StockTraderApi.Domain.Entities;

namespace StockTraderApi.Domain.Interfaces.Repositories
{
    public interface ITradeRepository
    {
        Task<IEnumerable<Trade>> GetTradesByUserIdAsync(string userId);

        Task<Trade> GetTradeByIdAsync(long tradeId);

    }
}
