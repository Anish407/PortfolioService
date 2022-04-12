using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioService.Core.Interfaces.Clients;
using System.Threading;
using System.Threading.Tasks;
using static PortfolioService.Core.Common.Constants.Configurations;

namespace PortfolioService.Api.Middleware
{
    public class RefreshCurrencyConversionCacheBackGroundService : BackgroundService
    {
        private readonly IMemoryCache _cache;
        private readonly ICurrencyClient _currencyClient;
        private IConfiguration _configuration;

        public RefreshCurrencyConversionCacheBackGroundService(IServiceScopeFactory scopeFactory)
        {
            ScopeFactory = scopeFactory;
        }

        public IServiceScopeFactory ScopeFactory { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = ScopeFactory.CreateScope())
                {
                    IMemoryCache cache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
                    ICurrencyClient currencyClient = scope.ServiceProvider.GetRequiredService<ICurrencyClient>();
                    _cache.Remove(ConcurencyCacheKey);
                    var data = await _currencyClient.GetUSDCurrencyCoversions<CurrencyConversionDTO>();
                    _cache.Set(ConcurencyCacheKey, data);
                }

                await Task.Delay(System.TimeSpan.FromHours(24));
            }
        }
    }

}


