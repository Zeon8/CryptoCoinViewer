using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.Services;

public class CryptoAssetsService
{
    private readonly HttpClient _client;
    private JsonSerializerOptions _options = new(JsonSerializerDefaults.Web);
    private const int Limit = 10;

    public CryptoAssetsService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Asset>?> GetAssets()
    {
        var response = await _client.GetFromJsonAsync<AssetsResponse<Asset>>($"assets?limit={Limit}", _options);
        return response?.Data;
    }

    public async Task<IEnumerable<Market>?> GetMarkets(Asset asset)
    {
        var response = await _client.GetFromJsonAsync<AssetsResponse<Market>>($"assets/{asset.Id}/markets?limit={Limit}", _options);
        return response?.Data;
    }
}