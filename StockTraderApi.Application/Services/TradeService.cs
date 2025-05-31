using StockTraderApi.Application.Interfaces.Services;
using StockTraderApi.Domain.Entities;
using StockTraderApi.Domain.Interfaces.Repositories;

namespace StockTraderApi.Application.Services
{
    public class TradeService : ITradeService
    {

        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task<Trade> GetTradeByIdAsync(long tradeId)
            => await _tradeRepository.GetTradeByIdAsync(tradeId);

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(string userId)
            => await _tradeRepository.GetTradesByUserIdAsync(userId);

        public Task SaveTradeAsync(Trade trade)
        {
            throw new NotImplementedException();
        }
    }
}
