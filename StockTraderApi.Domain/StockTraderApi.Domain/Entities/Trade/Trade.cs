using StockTraderApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTraderApi.Domain.Entities.Trade
{
    public class Trade
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = default!;

        public string StockSymbol { get; set; } = default!;

        public ETradeOperationType OperationType { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal TotalAmount => Quantity * PricePerUnit;

        public DateTime TradeDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
