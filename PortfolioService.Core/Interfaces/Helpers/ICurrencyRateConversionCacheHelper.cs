using System.Threading.Tasks;

namespace PortfolioService.Core.Implementations.Helpers
{
    public interface ICurrencyRateConversionCacheHelper
    {
        Task<CurrencyConversionDTO> GetCurrencyConversionRates();
    }
}