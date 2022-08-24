namespace KrakenClient.Contracts;

public interface IKrakenClient
{
    public IMarketDataEndpoint MarketData();
}