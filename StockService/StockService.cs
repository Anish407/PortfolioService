using PortfolioService.Core.Interfaces.Services;
using System.Collections.Generic;

namespace PortfolioService.Services
{
    public class StockService : IStockService
    {
        public (double Price, string NativeCurrency) GetCurrentStockPrice(string baseCurrency, CurrencyConversionDTO currencyConversion)
        {
            string currencyBase = "USD";

            double price = currencyConversion.quotes[$"{currencyBase}{baseCurrency.ToUpper()}"];
            return (1/price, baseCurrency);
        }
    }
}