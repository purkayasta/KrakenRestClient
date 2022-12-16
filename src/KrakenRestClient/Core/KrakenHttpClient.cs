using KrakenRestClient.Utilities;

namespace KrakenRestClient.Core;

internal sealed class KrakenHttpClient : IKrakenHttpClient
{
    #region Property

    public Dictionary<string, string> Headers { get; set; } = new();
    public Dictionary<string, string> BodyParameters { get; set; } = new();
    private string BaseUrl { get; } = "api.kraken.com";
    private int Version { get; } = 0;
    private string Protocol { get; } = "https://";

    #endregion

    #region Fields

    private readonly IHttpClientFactory? _httpClientFactory = null;
    private readonly HttpClient? _httpClient = null;

    #endregion

    public KrakenHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Headers.TryAdd("User-Agent", "KrakenRestClient-V1");
    }

    internal KrakenHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Headers.TryAdd("User-Agent", "KrakenRestClient-V1");
    }

    public Task<T?> Get<T>(string url) where T : class
    {
        var httpClient = GetHttpClient();
        httpClient!.DefaultRequestHeaders.AddHeaders(Headers);

        if (BodyParameters.Count <= 0)
            return httpClient.GetFromJsonAsync<T>($"{Protocol}{BaseUrl}/{Version}/{url}");

        var stringContent = BodyParameters.ConvertToString();
        return httpClient.GetFromJsonAsync<T>($"{Protocol}{BaseUrl}/{Version}/{url}?{stringContent}");
    }

    public async Task<T?> Post<T>(string url) where T : class
    {
        ArgumentNullException.ThrowIfNull(KrakenAuth.ApiKey, nameof(KrakenAuth.ApiKey));
        ArgumentNullException.ThrowIfNull(Headers, "Invalid Headers found");

        var nonce = NonceGenerator.GetNonce();
        BodyParameters.TryAdd("nonce", nonce);

        var body = BodyParameters.ConvertToString();
        var absoluteUri = $"{Version}/{url}";
        var signKey = KrakenAuth.CreateAuthSignature(nonce, absoluteUri, body);

        ArgumentNullException.ThrowIfNull(signKey, "Invalid Sign Key Generated!!");

        StringContent? httpStrContent = null;
        if (body is not null)
            httpStrContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

        Headers.TryAdd("API-Key", KrakenAuth.ApiKey);
        Headers.TryAdd("API-Sign", signKey);

        var httpClient = GetHttpClient();
        httpClient!.DefaultRequestHeaders.AddHeaders(Headers);

        var result = await httpClient
            .PostAsync($"{Protocol}{BaseUrl}/{absoluteUri}", httpStrContent ?? null);

        if (result?.Content is null) return null;

        return await JsonSerializer
            .DeserializeAsync<T>(await result.Content.ReadAsStreamAsync().ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    private HttpClient? GetHttpClient()
    {
        if (_httpClientFactory is not null) return _httpClientFactory.CreateClient();
        if (_httpClient is not null) return _httpClient;
        
        KrakenException.Throw("HttpClient is invalid");
        
        return null;
    }
}