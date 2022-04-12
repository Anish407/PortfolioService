using System.Threading.Tasks;
using CodeTest.Infrastructure.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CodeTest.Infrastructure.Persistence
{
    public class DataService : IDataService
    {
        private readonly IMongoCollection<PortfolioData> _portfolioCollection;

        public DataService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _portfolioCollection = client.GetDatabase("portfolioServiceDb").GetCollection<PortfolioData>("Portfolios");
        }

        public async Task<PortfolioData> GetPortfolio(string portfolioId)
        {
            var id = ObjectId.Parse(portfolioId);
            FilterDefinition<PortfolioData> idFilter = Builders<PortfolioData>.Filter.Eq(portfolio => portfolio.Id, id);

            return await _portfolioCollection.Find(filter=> filter.IsDeleted != true).FirstOrDefaultAsync(); 
        }

        public async Task DeletePortfolio(string portfolioId)
        {
            var id = ObjectId.Parse(portfolioId);
            PortfolioData portfolioData = await GetPortfolio(portfolioId);
            portfolioData.IsDeleted = true;

            await _portfolioCollection.ReplaceOneAsync(x => x.Id == id, portfolioData);
        }
    }
}