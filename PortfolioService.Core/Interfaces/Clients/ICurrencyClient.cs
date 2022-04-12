using System.Threading.Tasks;

namespace PortfolioService.Core.Interfaces.Clients
{
    public interface ICurrencyClient
    {
        Task<T> GetUSDCurrencyCoversions<T>() where T : new();
    }
}