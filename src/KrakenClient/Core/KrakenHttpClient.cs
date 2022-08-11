using System.Net.Http.Json;
using System.Text.Json;
using KrakenClient.Utilities;

namespace KrakenClient.Core;

public sealed class KrakenHttpClient : IKrakenHttpClient
{
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    private static string BaseUrl { get; } = "api.kraken.com";
    private static int Version { get; } = 0;
    private static string Protocol => KrakenAuth.IsHttps ? "https://" : "http://";


    private readonly IHttpClientFactory _httpClientFactory;

    public KrakenHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Headers?.TryAdd("User-Agent", "Krakenarp");
    }

    public Task<T?> Get<T>(string url) where T : class
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.AddHeaders(Headers);
        return client.GetFromJsonAsync<T>(Protocol + BaseUrl + "/" + Version + "/" + url);
    }

    public async Task<T?> Post<T>(string url) where T : class
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.AddHeaders(Headers);
        var body = Parameters.ConvertToString();

        StringContent? s = null;
        if (body is not null) s = new StringContent(body);

        var nonce = NonceGenerator.GetNonce;
        var apiSignKey = KrakenAuth.GetApiSignKey(KrakenAuth.ApiKey, nonce, url, body);

        // Add Api-Sign Property
        // Add Nonce Property

        var result = await client.PostAsync(Protocol + BaseUrl + "/" + Version + "/" + url, s ?? null);
        if (result?.Content is null) return null;

        return await JsonSerializer.DeserializeAsync<T>(await result.Content.ReadAsStreamAsync());
    }
}