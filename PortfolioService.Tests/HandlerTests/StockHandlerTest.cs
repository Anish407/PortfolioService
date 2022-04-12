using CodeTest.Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PortfolioService.Core.Implementations.Calculator;
using PortfolioService.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioService.Tests.HandlerTests
{
    [TestFixture]
    public class StockHandlerTest : TestBase
    {
        private ICollection<StockData> stocks { get; set; }
        private CurrencyConversionDTO currencyConversionDTO { get; set; }
        private IStockQuotesCalculator stockQuotesCalculator { get; set; }
        private double totalStockPrice;

        public override void Act()
        {
            totalStockPrice= stockQuotesCalculator.GetStockPrices(stocks, currencyConversionDTO);
        }

        public override void Arrange()
        {
            stocks = new List<StockData>()
            {
                new StockData
                {
                    BaseCurrency="sek",
                   Ticker ="GME",
                   NumberOfShares=100
                },
                new StockData
                {
                    BaseCurrency="AED",
                   Ticker ="tesla",
                   NumberOfShares=50
                }
            };
            currencyConversionDTO = new CurrencyConversionDTO()
            {
                quotes = new Dictionary<string, double>
                {
                    {    "USDAED",3.672965 },
                    {   "USDSEK" ,9.448185 },
                    {    "USDAFN", 88.462742 } ,
                    {    "USDALL", 111.782144 } ,
                    {     "USDAMD", 479.414852 } 
                }
            };

            stockQuotesCalculator = ServiceProvider.GetRequiredService<IStockQuotesCalculator>();
        }

        [Test]
        public void GetTotalPortfolioValue_When_Currency_Exists()
        {
            Assert.True(totalStockPrice !=0);
        }
    }
}
