using KrakenClient.Utilities;

namespace KrakenClient.Core;

public class KrakenHttpClient : IKrakenHttpClient
{
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    private static string BaseUrl { get; } = "api.kraken.com";
    private static int Version { get; } = 0;

    private readonly IHttpClientFactory _httpClientFactory;

    public KrakenHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        Headers?.TryAdd("User-Agent", "Krakenarp");
    }

    public void Get(string url)
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.AddHeaders(Headers);
        client.GetAsync(BaseUrl + "/" + Version + url).GetAwaiter().GetResult();
    }
    
    // Add Api-Sign Property
    // Add Nonce Property

    public void Post(string url)
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.AddHeaders(Headers);
        var body = Parameters.ConvertToString();

        StringContent? s = null;
        if (body is not null) s = new StringContent(body);
        
        client.PostAsync(BaseUrl + "/" + Version + url, s ?? null);
    }
}

public interface IKrakenHttpClient
{
    public Dictionary<string, string>? Headers { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    void Get(string url);
    void Post(string url);
}