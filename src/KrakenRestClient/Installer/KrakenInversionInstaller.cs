using KrakenRestClient.Contracts;
using KrakenRestClient.Core;
using Microsoft.Extensions.DependencyInjection;

namespace KrakenRestClient.Installer;

public static class KrakenInversionInstaller
{
    /// <summary>
    /// Re commanded way to add kraken into the project 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="apiKey">Kraken API Key</param>
    /// <param name="secretKey">Kraken Secret Key</param>
    public static void AddKraken(this IServiceCollection serviceCollection, string apiKey, string secretKey)
    {
        ArgumentNullException.ThrowIfNull(apiKey, "ApiKey");
        ArgumentNullException.ThrowIfNull(secretKey, "SecretKey");

        serviceCollection.AddHttpClient();
        serviceCollection.AddScoped<IKrakenHttpClient, KrakenHttpClient>();
        serviceCollection.AddScoped<IKrakenClient, KrakenClient>();

        KrakenAuth.ApiKey = apiKey;
        KrakenAuth.SecretKey = secretKey;
    }

    /// <summary>
    /// For Public Methods Only
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddKraken(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();
        serviceCollection.AddScoped<IKrakenHttpClient, KrakenHttpClient>();
        serviceCollection.AddScoped<IKrakenClient, KrakenClient>();
    }
}