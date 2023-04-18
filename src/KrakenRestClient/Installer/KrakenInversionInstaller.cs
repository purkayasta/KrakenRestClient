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
    public static IServiceCollection AddKraken(this IServiceCollection? serviceCollection, string? apiKey, string? secretKey)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentException($"{nameof(apiKey)} is invalid");
        if (string.IsNullOrEmpty(secretKey) || string.IsNullOrWhiteSpace(secretKey))
            throw new ArgumentException($"{nameof(secretKey)} is invalid");

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

    /* Option Pattern
    public static IServiceCollection AddKraken(
        this IServiceCollection serviceCollection,
        Action<KrakenOption>? krakenConfiguration)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);
        ArgumentNullException.ThrowIfNull(krakenConfiguration);

        serviceCollection
            .AddOptions<KrakenOption>()
            .Configure(krakenConfiguration)
            .Validate(option =>
            {
                if (string.IsNullOrEmpty(option.ApiKey) || string.IsNullOrWhiteSpace(option.ApiKey))
                    return false;

                if (string.IsNullOrEmpty(option.SecretKey) || string.IsNullOrWhiteSpace(option.SecretKey))
                    return false;

                return true;
            }, $"{nameof(KrakenOption.ApiKey)} Or {nameof(KrakenOption.SecretKey)} is invalid");

        return RegisterServices(serviceCollection);
    }
    */

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
