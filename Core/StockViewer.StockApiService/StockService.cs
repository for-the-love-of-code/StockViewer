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
        private const string ApiServer = "https://financialmodelingprep.com/api/v3";
        private readonly string apiKey = "a4f9f2e874d0e33bb8a437561cc00215";

        // Hardcoding to NASDAQ for demo.
        private const string ExchangeName = "NASDAQ";

        public async Task<IEnumerable<Stock>> TickerSearchAsync(string searchText)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{ApiServer}/search?query={searchText}&limit=10&exchange={ExchangeName}&apikey={apiKey}";
                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<IEnumerable<Stock>>(jsonResponse);
            }
        }

        public async Task<Stock> GetStockQuoteAsync(string symbol)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{ApiServer}/quote/{symbol}?apikey={apiKey}";
                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<Stock>>(jsonResponse).First();
            }
        }
    }
}
