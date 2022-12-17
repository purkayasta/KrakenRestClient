namespace KrakenRestClient.Contracts;

public interface IKrakenClient
{
    /// <summary>
    /// Public Endpoint
    /// </summary>
    /// <returns></returns>
    public IMarketDataEndpoint MarketData();

    /// <summary>
    /// Authenticated Endpoint
    /// </summary>
    /// <returns></returns>
    public IUserDataEndpoint UserData();

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserTradingEndpoint UserTrading();

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserFundingEndpoint UserFunding();

    /// <summary>
    /// Authenticated Endpoint.
    /// </summary>
    /// <returns></returns>
    public IUserStakingEndpoint UserStaking();
}