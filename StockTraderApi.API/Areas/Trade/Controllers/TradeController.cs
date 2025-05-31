using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTraderApi.Application.Interfaces.Services;
using StockTraderApi.Application.Models;

namespace StockTraderApi.API.Areas.Trade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;


        public TradeController(ITradeService tradeService, 
                               IMapper mapper)
        {
            _tradeService = tradeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os trades do usuário.
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Trade API is working!");

            IEnumerable<Domain.Entities.Trade> trades = await _tradeService.GetTradesByUserIdAsync("1");

            return Ok(trades);
        }

        [HttpGet("{tradeId}")]
        [Authorize]
        public async Task<IActionResult> Get(long tradeId)
        {
            _logger.LogInformation("Trade API is working!");
            Domain.Entities.Trade trade = await _tradeService.GetTradeByIdAsync(tradeId);
            if (trade == null)
                return NotFound();
            return Ok(trade);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] TradeDto tradeDto)
        {
            if (tradeDto == null)
                return BadRequest();

            _logger.LogInformation("Trade API is working!");

            var trade = _mapper.Map<Domain.Entities.Trade>(tradeDto);

            await _tradeService.SaveTradeAsync(trade);
            
            return CreatedAtAction(nameof(Get), new { tradeId = trade.CodigoTrade }, trade);
        }
    }
}
