using Newtonsoft.Json;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services;
using StockViewer.Domain.Services.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockViewer.StockApiService
{
    public class StockService : IStockService
    {
        private readonly StockServiceClient client;

        public StockService(StockServiceClient client)
        {
            this.client = client;
        }

        // Hardcoding to nyse for demo.
        private const string ExchangeName = "NASDAQ";

        public async Task<IEnumerable<Stock>> TickerSearchAsync(string searchText)
        {
            var uri = $"search?query={searchText}&limit=10&exchange={ExchangeName}&";
            return await client.GetAsync<IEnumerable<Stock>>(uri).ConfigureAwait(false);
        }

        public async Task<Stock> GetStockDataAsync(string symbol)
        {
                var uri = $"quote/{symbol}?";
                return (await client.GetAsync<List<Stock>>(uri).ConfigureAwait(false)).First();
            
        }

        public async Task<Stock> GetLivePriceAsync(string symbol)
        {
            var uri = $"quote-short/{symbol}?";
            return (await client.GetAsync<List<Stock>>(uri).ConfigureAwait(false)).First();
        }
    }
}
