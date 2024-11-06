using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.Services;

public class CryptoAssetsService
{
    private readonly HttpClient _client;
    private const int Limit = 10;

    public CryptoAssetsService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Asset>?> GetAssets()
    {
        var response = await _client.GetFromJsonAsync<AssetsResponse>($"assets?limit={Limit}", new JsonSerializerOptions(JsonSerializerDefaults.Web));
        return response?.Data;
    }

}