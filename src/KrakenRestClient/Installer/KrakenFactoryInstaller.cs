using KrakenRestClient.Contracts;
using KrakenRestClient.Core;

namespace KrakenRestClient.Installer;

public static class KrakenFactoryInstaller
{
    public static IKrakenClient CreateClient(IHttpClientFactory httpClientFactory, string apiKey, string secretKey)
    {
        ArgumentNullException.ThrowIfNull(apiKey, "ApiKey");
        ArgumentNullException.ThrowIfNull(secretKey, "SecretKey");

        return CreateKrakenClient(httpClientFactory.CreateClient(), apiKey, secretKey);
    }

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