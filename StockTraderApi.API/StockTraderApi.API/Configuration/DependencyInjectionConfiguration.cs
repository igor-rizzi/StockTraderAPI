using StockTraderApi.Application.Interfaces.Services;
using StockTraderApi.Application.Services;
using StockTraderApi.Domain.Interfaces.Repositories;
using StockTraderApi.Infrastructure.Repositories;

namespace StockTraderApi.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<ITradeService, TradeService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
