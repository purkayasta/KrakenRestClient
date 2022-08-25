namespace KrakenClient.Contracts;

public interface IKrakenClient
{
    public IMarketDataEndpoint MarketData();
    public IUserDataEndpoint UserData();
}