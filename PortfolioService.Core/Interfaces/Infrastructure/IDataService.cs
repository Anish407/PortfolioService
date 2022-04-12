using CodeTest.Infrastructure.Models;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Persistence
{
    public interface IDataService
    {
        Task DeletePortfolio(string id);
        Task<PortfolioData> GetPortfolio(string id);
    }
}