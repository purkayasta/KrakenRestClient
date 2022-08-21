using KrakenClient.Models.MarketData;

namespace KrakenClient.Contracts;

public interface IMarketDataEndpoint
{
    Task<ServerTime?> GetServerTime();
}