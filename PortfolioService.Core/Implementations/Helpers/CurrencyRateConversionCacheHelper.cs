using Microsoft.Extensions.Caching.Memory;
using PortfolioService.Core.Interfaces.Clients;
using System.Threading.Tasks;

using static PortfolioService.Core.Common.Constants.Configurations;

namespace PortfolioService.Core.Implementations.Helpers
{
    public class CurrencyRateConversionCacheHelper : ICurrencyRateConversionCacheHelper
    {
        public CurrencyRateConversionCacheHelper(
            IMemoryCache cache,
             ICurrencyClient currencyClient)
        {
            _cache = cache;
            _currencyClient = currencyClient;
        }

        private IMemoryCache _cache { get; }
        private ICurrencyClient _currencyClient { get; }

        public async Task<CurrencyConversionDTO> GetCurrencyConversionRates()
        {
            _cache.TryGetValue(ConcurencyCacheKey, out CurrencyConversionDTO currencyConversionData);

            if (currencyConversionData == null)
            {
                currencyConversionData = await _currencyClient.GetUSDCurrencyCoversions<CurrencyConversionDTO>();
                _cache.Set(ConcurencyCacheKey, currencyConversionData);
            }

            return currencyConversionData;
        }
    }
}
