using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTraderApi.Application.Interfaces.Services;

namespace StockTraderApi.API.Areas.Trade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        private readonly ITradeService _tradeService;


        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Trade API is working!");

            IEnumerable<Domain.Entities.Trade> trades = await _tradeService.GetTradesByUserIdAsync("1");

            return Ok(trades);
        }
    }
}
