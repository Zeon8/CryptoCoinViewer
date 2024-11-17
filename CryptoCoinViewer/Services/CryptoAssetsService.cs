using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.Services;

public class CryptoAssetsService
{
    private readonly HttpClient _client = new HttpClient()
    {
        BaseAddress = new Uri("https://api.coincap.io/v2/")
    };

    private readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web);
    
    private const int Limit = 10;

    public Task<IEnumerable<Asset>> SearchAssets(string name) 
        => GetAssets($"limit={Limit}&search={name}");

    public Task<IEnumerable<Asset>> GetAssets() => GetAssets($"limit={Limit}");

    private async Task<IEnumerable<Asset>> GetAssets(string parameters)
    {
        var response = await _client.GetFromJsonAsync<AssetsResponse<Asset>>($"assets?{parameters}", _options);
        return response?.Data ?? [];
    }

    public async Task<IEnumerable<Market>> GetMarkets(Asset asset)
    {
        var response = await _client.GetFromJsonAsync<AssetsResponse<Market>>($"assets/{asset.Id}/markets?limit={Limit}", _options);
        return response?.Data ?? [];
    }
}