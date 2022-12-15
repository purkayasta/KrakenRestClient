namespace KrakenRestClient.Contracts;

public interface IKrakenClient
{
    public IMarketDataEndpoint MarketData();
    public IUserDataEndpoint UserData();
}