using CodeTest.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioService.Core.Implementations.Calculator;
using PortfolioService.Core.Implementations.Handler;
using PortfolioService.Core.Implementations.Helpers;
using PortfolioService.Core.Interfaces.Clients;
using PortfolioService.Core.Interfaces.Services;
using PortfolioService.Core.Models;
using PortfolioService.Services;

namespace PortfolioService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<ICurrencyClient, CurrencyClient>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStockQuotesCalculator, StockQuotesCalculator>();
            services.AddScoped<ICurrencyRateConversionCacheHelper, CurrencyRateConversionCacheHelper>();
            services.AddScoped<IStockHandler, StockHandler>();
            services.AddScoped<IDataService, DataService>();
            services.AddMemoryCache();
        }

        public static void RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CurrencyConfiguration>(options =>
            {
                options.BaseAddress = configuration["CurrencyConfiguration:BaseAddress"];
                options.ApiKey = configuration["CurrencyConfiguration:ApiKey"];
            });
        }

    }
}
