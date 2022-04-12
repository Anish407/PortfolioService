using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PortfolioService.Core.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace PortfolioService.Core.Interfaces.Clients
{
    public class CurrencyClient : ICurrencyClient
    {
        public CurrencyClient(HttpClient httpclient, IOptions<CurrencyConfiguration> options)
        {
            _currencyConfiguration = options.Value;
            _client = httpclient;
            _client.BaseAddress = new Uri(_currencyConfiguration.BaseAddress);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private HttpClient _client { get; }
        private CurrencyConfiguration _currencyConfiguration { get; }

        public async Task<T> GetUSDCurrencyCoversions<T>() where T : new()
        {
            var request = new HttpRequestMessage(
               HttpMethod.Get,
              $"/live?access_key={_currencyConfiguration.ApiKey}");

            using (var response = await _client.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead
              ))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var reader = new StreamReader(stream);
                return JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());
            }
        }
    }
}
