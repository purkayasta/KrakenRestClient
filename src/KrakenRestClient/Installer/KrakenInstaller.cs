namespace KrakenRestClient.Installer;

public static class KrakenInstaller
{
    /// <summary>
    /// Create a Kraken Rest Client
    /// </summary>
    /// <param name="httpClientFactory">HttpClientFactory Instance</param>
    /// <param name="apiKey">Your Kraken API Key.</param>
    /// <param name="secretKey">Your Kraken API Secret</param>
    /// <returns>IKrakenClient</returns>
    public static IKrakenClient CreateClient(IHttpClientFactory httpClientFactory, string apiKey, string secretKey)
    {
        ArgumentNullException.ThrowIfNull(apiKey, "ApiKey");
        ArgumentNullException.ThrowIfNull(secretKey, "SecretKey");

        return CreateKrakenClient(httpClientFactory.CreateClient(), apiKey, secretKey);
    }

    /// <summary>
    /// Create a Kraken Rest Client
    /// </summary>
    /// <param name="httpClient">HttpClient Instance</param>
    /// <param name="apiKey">Your Kraken API Key.</param>
    /// <param name="secretKey">Your Kraken API Secret</param>
    /// <returns>IKrakenClient</returns>
    public static IKrakenClient CreateClient(HttpClient httpClient, string apiKey, string secretKey)
    {
        ArgumentNullException.ThrowIfNull(apiKey, "ApiKey");
        ArgumentNullException.ThrowIfNull(secretKey, "SecretKey");

        return CreateKrakenClient(httpClient, apiKey, secretKey);
    }

    private static IKrakenClient CreateKrakenClient(HttpClient httpClient, string apiKey, string secretKey)
    {
        KrakenAuth.ApiKey = apiKey;
        KrakenAuth.SecretKey = secretKey;

        var krakenClient = new KrakenHttpClient(httpClient);
        return new KrakenClient(krakenClient);
    }
}