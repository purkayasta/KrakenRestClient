using KrakenClient.Models.MarketData;

namespace KrakenClient.Contracts;

public interface IMarketDataEndpoint
{
    Task<ServerTime?> GetServerTime();

    Task<SystemStatus?> GetSystemStatus();

    Task<AssetInfo?> GetAssetInfo();
    Task<AssetInfo?> GetAssetInfo(string asset, string aclass = "currency");

    Task<TradableAssetPair?> GetTradableAssetPair(string assetPair);

    Task<TickerInformation?> GetTickerInformation(string pair);

    Task<OHLCData?> GetOhlcData(string pair, int? since = null, int interval = 1);

    Task<OrderBook?> GetOrderbook(string pair, int count = 2);
    Task<RecentTrades?> GetRecentTrades(string pair, int? since = null);
}