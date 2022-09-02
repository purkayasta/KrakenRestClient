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
    private readonly SemaphoreSlim _semaphore;

    public KrakenHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Clear();
        Headers.TryAdd("User-Agent", "KrakenArp-V2");
        _semaphore = new SemaphoreSlim(1);
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
        await _semaphore.WaitAsync();
        try
        {
            ArgumentNullException.ThrowIfNull(KrakenAuth.ApiKey, nameof(KrakenAuth.ApiKey));
            ArgumentNullException.ThrowIfNull(Headers, "Invalid Headers found");

            var nonce = NonceGenerator.GetNonce();
            BodyParameters.TryAdd("nonce", nonce);

            var body = BodyParameters.ConvertToString();
            var absoluteUri = $"/{Version}/{url}";
            var signKey = KrakenAuth.CreateAuthSignature(nonce, absoluteUri, body);

            ArgumentNullException.ThrowIfNull(signKey, "Invalid Sign Key Generated!!");

            StringContent? httpStrContent = null;
            if (body is not null)
                httpStrContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            Headers.TryAdd("API-Key", KrakenAuth.ApiKey);
            Headers.TryAdd("API-Sign", signKey);
            _httpClient.DefaultRequestHeaders.AddHeaders(Headers);

            var result = await _httpClient
                .PostAsync($"{Protocol}{BaseUrl}/{absoluteUri}", httpStrContent ?? null);

            if (result?.Content is null) return null;

            return await JsonSerializer.DeserializeAsync<T>(await result.Content.ReadAsStreamAsync());
        }
        finally
        {
            _semaphore.Release();
        }
    }
}