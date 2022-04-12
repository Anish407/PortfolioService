using CodeTest.Infrastructure.Models;
using PortfolioService.Core.Interfaces.Services;
using System.Collections.Generic;

namespace PortfolioService.Core.Implementations.Calculator
{
    public class StockQuotesCalculator : IStockQuotesCalculator
    {
        public StockQuotesCalculator(IStockService stockService)
        {
            _stockService = stockService;
        }

        private IStockService _stockService { get; }

        public double GetStockPrices(ICollection<StockData> stocks, CurrencyConversionDTO currencyConversionRates)
        {
            double totalAmount = 0;

            foreach (var stock in stocks)
            {
                double price = (stock.BaseCurrency.ToUpper().Equals("USD")) ? 1 : _stockService.GetCurrentStockPrice(stock.BaseCurrency, currencyConversionRates).Price;
                totalAmount += price * stock.NumberOfShares;
            }

            return totalAmount;
        }
    }
}
