using System.Threading.Tasks;

namespace PortfolioService.Core.Interfaces.Services
{
    public interface IStockService
    {
        (double Price, string NativeCurrency) GetCurrentStockPrice(string baseCurrency, CurrencyConversionDTO currencyConversion);
    }
}
