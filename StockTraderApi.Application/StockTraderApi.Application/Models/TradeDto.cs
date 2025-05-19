using StockTraderApi.Domain.Enums;

namespace StockTraderApi.Application.Models
{
    public class TradeDto
    {
        public Guid Id { get; set; }

        public long CodigoTrade { get; set; }

        public string UserId { get; set; } = default!;

        public string StockSymbol { get; set; } = default!;

        public ETradeOperationType OperationType { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime TradeDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
