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
    public static IServiceCollection AddKraken(this IServiceCollection? serviceCollection, string apiKey, string secretKey)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);
        ArgumentNullException.ThrowIfNull(apiKey, "ApiKey");
        ArgumentNullException.ThrowIfNull(secretKey, "SecretKey");

        KrakenAuth.ApiKey = apiKey;
        KrakenAuth.SecretKey = secretKey;

        return RegisterServices(serviceCollection);
    }


    /// <summary>
    /// For Public Methods Only
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static IServiceCollection AddKraken(this IServiceCollection serviceCollection)
        => RegisterServices(serviceCollection);

    private static IServiceCollection RegisterServices(IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddHttpClient()
            .AddScoped<IKrakenHttpClient, KrakenHttpClient>()
            .AddScoped<IKrakenClient, KrakenClient>()
            .AddScoped<IMarketDataEndpoint, MarketDataEndpoint>()
            .AddScoped<IUserDataEndpoint, UserDataEndpoint>()
            .AddScoped<IUserTradingEndpoint, UserTradingEndpoint>()
            .AddScoped<IUserFundingEndpoint, UserFundingEndpoint>()
            .AddScoped<IUserStakingEndpoint, UserStakingEndpoint>();
    }
}