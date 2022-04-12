using CodeTest.Infrastructure.Models;
using System.Collections.Generic;

namespace PortfolioService.Core.Implementations.Calculator
{
    public interface IStockQuotesCalculator
    {
        double GetStockPrices(ICollection<StockData> stocks, CurrencyConversionDTO currencyConversionRates);
    }
}