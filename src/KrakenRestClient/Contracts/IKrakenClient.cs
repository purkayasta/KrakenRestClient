namespace KrakenRestClient.Contracts;

public interface IKrakenClient
{
    public IMarketDataEndpoint MarketData();
    public IUserDataEndpoint UserData();
    public IUserTradingEndpoint UserTrading();
    public IUserFundingEndpoint UserFunding();
    public IUserStakingEndpoint UserStaking();
}