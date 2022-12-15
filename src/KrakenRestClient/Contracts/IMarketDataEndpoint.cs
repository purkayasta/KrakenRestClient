using KrakenRestClient.Models.MarketData;

namespace KrakenRestClient.Contracts;

public interface IMarketDataEndpoint
{
    Task<ServerTimeResponse?> GetServerTime();
    Task<SystemStatusResponse?> GetSystemStatus();
    Task<AssetInfoResponse?> GetAssetInfo();
    Task<AssetInfoResponse?> GetAssetInfo(string asset, string aclass = "currency");
    Task<TradeAbleAssetPairResponse?> GetTradableAssetPair(string assetPair);
    Task<TickerInformationResponse?> GetTickerInformation(string pair);
    Task<OHLCDataResponse?> GetOhlcData(string pair, int? since = null, int interval = 1);
    Task<OrderBookResponse?> GetOrderBook(string pair, int count = 2);
    Task<RecentTradesResponse?> GetRecentTrades(string pair, int? since = null);
    Task<RecentSpreadsResponse?> GetRecentSpreads(string pair, int? since = null);
}