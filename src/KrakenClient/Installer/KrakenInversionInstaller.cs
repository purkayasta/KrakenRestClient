using KrakenClient.Contracts;
using KrakenClient.Core;
using Microsoft.Extensions.DependencyInjection;

namespace KrakenClient.Installer;

public static class KrakenInversionInstaller
{
    /// <summary>
    /// For private methods
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="apiKey">Kraken Api Key</param>
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