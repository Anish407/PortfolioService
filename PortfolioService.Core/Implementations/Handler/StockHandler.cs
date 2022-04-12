using CodeTest.Infrastructure.Models;
using CodeTest.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using PortfolioService.Core.Implementations.Calculator;
using PortfolioService.Core.Implementations.Helpers;
using PortfolioService.Core.Interfaces.Clients;
using PortfolioService.Core.Interfaces.DTOs;
using PortfolioService.Core.Interfaces.Services;
using System.Threading.Tasks;


namespace PortfolioService.Core.Implementations.Handler
{
    public class StockHandler : IStockHandler
    {
        private readonly ICurrencyRateConversionCacheHelper _currencyRateConversionCacheHelper;
        private readonly IStockQuotesCalculator _stockQuotesCalculator;

        public ICurrencyClient _currencyClient { get; }
        private IDataService _dataService { get; }
        private IStockService _stockService { get; }
        public IMemoryCache Cache { get; }

        public StockHandler(
          ICurrencyRateConversionCacheHelper currencyRateConversionCacheHelper,
            IDataService dataService,
            IStockQuotesCalculator stockQuotesCalculator,
             IStockService stockService
           )
        {
            _currencyRateConversionCacheHelper = currencyRateConversionCacheHelper;
            _dataService = dataService;
            _stockQuotesCalculator = stockQuotesCalculator;
            _stockService = stockService;
        }

        public async Task<double> GetTotalPortfolioValue(GetTotalPortfolioValueDto GetTotalPortfolioValueDto)
        {
            CurrencyConversionDTO currencyConversionData = await _currencyRateConversionCacheHelper.GetCurrencyConversionRates();

            PortfolioData portfolio = await _dataService.GetPortfolio(GetTotalPortfolioValueDto.portfolioId);

            return _stockQuotesCalculator.GetStockPrices(portfolio.Stocks, currencyConversionData);
        }

        public async Task<PortfolioData> GetPortfolio(string portfolioId)
            => await _dataService.GetPortfolio(portfolioId);

        public async Task DeletePortfolio(string id)
         => await _dataService.DeletePortfolio(id);

    }
}
