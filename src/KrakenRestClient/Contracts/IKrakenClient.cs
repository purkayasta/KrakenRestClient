namespace KrakenRestClient.Contracts;

public interface IKrakenClient
{
    /// <summary>
    /// Public Endpoint
    /// </summary>
    /// <returns></returns>
    public IMarketDataEndpoint MarketData { get; }

    /// <summary>
    /// Authenticated Endpoint
    /// </summary>
    /// <returns></returns>
    public IUserDataEndpoint UserData { get; }

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserTradingEndpoint UserTrading { get; }

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserFundingEndpoint UserFunding { get; }

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserStakingEndpoint UserStaking { get; }
}