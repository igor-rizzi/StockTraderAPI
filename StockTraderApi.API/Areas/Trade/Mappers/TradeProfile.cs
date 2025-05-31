using AutoMapper;
using StockTraderApi.Application.Models;

namespace StockTraderApi.API.Areas.Trade.Mappers
{
    public class TradeProfile : Profile
    {
        public TradeProfile() 
        {
            CreateMap<Domain.Entities.Trade, TradeDto>();
        }
    }
}
