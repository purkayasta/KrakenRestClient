using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TradeAssetUrl = "AssetPairs";

    public Task<TradableAssetPair?> GetTradableAssetPair(string assetPair)
    {
        ArgumentNullException.ThrowIfNull(assetPair, nameof(assetPair));

        _httpClient.BodyParameters.Add("pair", assetPair);
        return _httpClient.Get<TradableAssetPair>(BaseUrl + TradeAssetUrl);
    }
}