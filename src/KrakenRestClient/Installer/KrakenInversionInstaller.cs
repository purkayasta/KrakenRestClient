using KrakenRestClient.Endpoints.MarketData;
using KrakenRestClient.Endpoints.UserData;
using KrakenRestClient.Endpoints.UserFunding;
using KrakenRestClient.Endpoints.UserStaking;
using KrakenRestClient.Endpoints.UserTrading;
using Microsoft.Extensions.DependencyInjection;

namespace KrakenRestClient.Installer;

public static class KrakenInversionInstaller
{
    /// <summary>
    /// Re commanded way to add kraken into the project 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="apiKey">Your Kraken API Key.</param>
    /// <param name="secretKey">Your Kraken API Secret</param>
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

    private static void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMarketDataEndpoint, MarketDataEndpoint>();
        serviceCollection.AddScoped<IUserDataEndpoint, UserDataEndpoint>();
        serviceCollection.AddScoped<IUserTradingEndpoint, UserTradingEndpoint>();
        serviceCollection.AddScoped<IUserFundingEndpoint, UserFundingEndpoint>();
        serviceCollection.AddScoped<IUserStakingEndpoint, UserStakingEndpoint>();
    }
}