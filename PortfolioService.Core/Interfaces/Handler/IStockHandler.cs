using CodeTest.Infrastructure.Models;
using PortfolioService.Core.Interfaces.DTOs;
using System.Threading.Tasks;

namespace PortfolioService.Core.Implementations.Handler
{
    public interface IStockHandler
    {
        Task<double> GetTotalPortfolioValue(GetTotalPortfolioValueDto getTotalPortfolioValueDto);

        Task DeletePortfolio(string id);

        Task<PortfolioData> GetPortfolio(string portfolioId);
    }
}