using KrakenRestClient.Models.MarketData;

namespace KrakenRestClient.Contracts;

public interface IMarketDataEndpoint
{
    /// <summary>
    /// Get the server's time.
    /// </summary>
    /// <returns></returns>
    Task<ServerTimeResponse?> GetServerTimeAsync();

    /// <summary>
    /// Get the current system status or trading mode.
    /// </summary>
    /// <returns></returns>
    Task<SystemStatusResponse?> GetSystemStatusAsync();

    /// <summary>
    /// Get information about the assets that are available for deposit, withdrawal, trading and staking.
    /// </summary>
    /// <returns></returns>
    Task<AssetInfoResponse?> GetAssetInfoAsync();

    /// <summary>
    /// Get information about the assets that are available for deposit, withdrawal, trading and staking.
    /// </summary>
    /// <param name="asset">Example: asset=XBT,ETH. Comma delimited list of assets to get info on</param>
    /// <param name="aclass">Example: aclass=currency. Asset class (optional, default: currency)</param>
    /// <returns></returns>
    Task<AssetInfoResponse?> GetAssetInfoAsync(string asset, string aclass = "currency");

    /// <summary>
    /// Get tradable asset pairs
    /// </summary>
    /// <param name="assetPair">Example: pair=XXBTCZUSD,XETHXXBT. Asset pairs to get data for</param>
    /// <returns></returns>
    Task<TradeAbleAssetPairResponse?> GetTradableAssetPairAsync(string assetPair);

    /// <summary>
    /// Note: Today's prices start at midnight UTC. Leaving the pair parameter blank will return tickers for all
    /// tradeable assets on Kraken.
    /// </summary>
    /// <param name="pair">Example: pair=XBTUSD. Asset pair to get data for (optional, default: all
    /// tradeable exchange pairs)</param>
    /// <returns></returns>
    Task<TickerInformationResponse?> GetTickerInformationAsync(string pair);

    /// <summary>
    /// Note: the last entry in the OHLC array is for the current, not-yet-committed frame and will always be present,
    /// regardless of the value of since.
    /// </summary>
    /// <param name="pair">Example: pair=XBTUSD. Asset pair to get data for</param>
    /// <param name="since">Time frame interval in minutes. Enum: 1 5 15 30 60 240 1440 10080 21600</param>
    /// <param name="interval">Return up to 720 OHLC data points since given timestamp. Example: since=1548111600.</param>
    /// <returns></returns>
    Task<OHLCDataResponse?> GetOhlcDataAsync(string pair, int? since = null, int interval = 1);

    /// <summary>
    /// Retrieve Order Book Information
    /// </summary>
    /// <param name="pair">Asset pair to get data for. Example: pair=XBTUSD</param>
    /// <param name="count">Maximum number of asks/bids. Example: count=2</param>
    /// <returns></returns>
    Task<OrderBookResponse?> GetOrderBookAsync(string pair, int count = 2);

    /// <summary>
    /// Returns the last 1000 trades by default
    /// </summary>
    /// <param name="pair">Asset pair to get data for Example: pair=XBTUSD</param>
    /// <param name="since">Return trade data since given timestamp. Example: since=1616663618</param>
    /// <returns></returns>
    Task<RecentTradesResponse?> GetRecentTradesAsync(string pair, int? since = null);

    /// <summary>
    /// Retrieve the Recent spreads
    /// </summary>
    /// <param name="pair">Asset pair to get data for. Example: pair=XBTUSD</param>
    /// <param name="since">Return spread data since given timestamp. Example: since=1548122302</param>
    /// <returns></returns>
    Task<RecentSpreadsResponse?> GetRecentSpreadsAsync(string pair, int? since = null);
}