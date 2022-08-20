using System.Net.Http.Json;
using System.Text.Json;
using KrakenClient.Utilities;

namespace KrakenClient.Core;

internal class KrakenHttpClient : IKrakenHttpClient
{
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? BodyParameters { get; set; }

    private string BaseUrl { get; } = "api.kraken.com";
    private int Version { get; } = 0;
    private string Protocol { get; } = "https://";


    private readonly IHttpClientFactory _httpClientFactory;

    public KrakenHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Headers?.TryAdd("User-Agent", "Krakenarp");
    }

    public Task<T?> Get<T>(string url) where T : class
    {
        var stockHttpClient = _httpClientFactory.CreateClient();
        stockHttpClient.DefaultRequestHeaders.AddHeaders(Headers);
        return stockHttpClient.GetFromJsonAsync<T>($"{Protocol}{BaseUrl}/{Version}/{url}");
    }

    public async Task<T?> Post<T>(string url) where T : class
    {
        ArgumentNullException.ThrowIfNull(KrakenAuth.ApiKey, nameof(KrakenAuth.ApiKey));
        ArgumentNullException.ThrowIfNull(Headers, "Invalid Headers found");

        Headers.TryAdd("API-Key", KrakenAuth.ApiKey);

        var nonce = NonceGenerator.GetNonce();
        BodyParameters?.TryAdd("nonce", nonce);

        var body = BodyParameters.ConvertToString();
        var signKey = KrakenAuth.GetSignKey(nonce, url, body);
        ArgumentNullException.ThrowIfNull(signKey, "Invalid Sign Key Generated!!");
        Headers.TryAdd("API-Sign", signKey);

        StringContent? httpStrContent = null;
        if (body is not null) httpStrContent = new StringContent(body);

        var stockHttpClient = _httpClientFactory.CreateClient();
        stockHttpClient.DefaultRequestHeaders.AddHeaders(Headers);

        var result = await stockHttpClient
            .PostAsync($"{Protocol}{BaseUrl}/{Version}/{url}", httpStrContent ?? null);

        if (result?.Content is null) return null;

        return await JsonSerializer.DeserializeAsync<T>(await result.Content.ReadAsStreamAsync());
    }
}