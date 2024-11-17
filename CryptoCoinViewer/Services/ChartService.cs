using CryptoCoinViewer.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace CryptoCoinViewer.Services
{
    public class ChartService
    {
        private readonly HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
        };

        public async Task<IEnumerable<CandleStick>?> GetCandleSticks(string id, int days)
        {
            var response = await _client.GetAsync($"coins/{id}/ohlc?vs_currency=usd&days={days}&precision=full");
            if (!response.IsSuccessStatusCode)
                return null;

            var arrays = await response.Content.ReadFromJsonAsync<double[][]>();
            if (arrays is null)
                return null;

            var candleSticks = new List<CandleStick>(arrays.Length);
            foreach (var array in arrays)
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds((long)array[0]);
                candleSticks.Add(new CandleStick
                {
                    DateTime = dateTimeOffset.DateTime,
                    Open = array[1],
                    High = array[2],
                    Low = array[3],
                    Close = array[4]
                });
            }
            return candleSticks;
        }
    }
}
