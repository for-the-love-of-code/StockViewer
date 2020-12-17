using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.StockApiService
{
    public class StockServiceClient
    {
        private readonly HttpClient client;
        private readonly string apiKey;

        public StockServiceClient(HttpClient client)
        {
            this.client = client;
            this.apiKey = "651bb0f13c04dadd20465b0915cb4937";
            // this.apiKey = "a4f9f2e874d0e33bb8a437561cc00215";
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}apikey={apiKey}");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
