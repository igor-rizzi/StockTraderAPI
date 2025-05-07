using StockTraderApi.Domain.Entities;

namespace StockTraderApi.Application.Interfaces.Services
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> GetTradesByUserIdAsync(string userId);
        Task<Trade> GetTradeByIdAsync(long tradeId);
    }
}
