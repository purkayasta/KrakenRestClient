using System.Net.Http.Json;
using System.Text.Json;
using KrakenClient.Utilities;

namespace KrakenClient.Core;

internal class KrakenHttpClient : IKrakenHttpClient
{
    public Dictionary<string, string> Headers { get; set; } = new();
    public Dictionary<string, string> BodyParameters { get; set; } = new();

    private string BaseUrl { get; } = "api.kraken.com";
    private int Version { get; } = 0;
    private string Protocol { get; } = "https://";


    private readonly HttpClient _httpClient;

    public KrakenHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Headers?.TryAdd("User-Agent", "Krakenarp");
    }

    public Task<T?> Get<T>(string url) where T : class
    {
        _httpClient.DefaultRequestHeaders.AddHeaders(Headers);

        if (BodyParameters.Count <= 0) 
            return _httpClient.GetFromJsonAsync<T>($"{Protocol}{BaseUrl}/{Version}/{url}");

        var stringContent = BodyParameters.ConvertToString();
        return _httpClient.GetFromJsonAsync<T>($"{Protocol}{BaseUrl}/{Version}/{url}?{stringContent}");
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

        _httpClient.DefaultRequestHeaders.AddHeaders(Headers);

        var result = await _httpClient
            .PostAsync($"{Protocol}{BaseUrl}/{Version}/{url}", httpStrContent ?? null);

        if (result?.Content is null) return null;

        return await JsonSerializer.DeserializeAsync<T>(await result.Content.ReadAsStreamAsync());
    }
}