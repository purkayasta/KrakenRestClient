using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TradeAssetUrl = "AssetPairs";

    public Task<TradeAbleAssetPair?> GetTradableAssetPair(string assetPair)
    {
        ArgumentNullException.ThrowIfNull(assetPair, nameof(assetPair));

        _httpClient.BodyParameters.Add("pair", assetPair);
        return _httpClient.Get<TradeAbleAssetPair>(BaseUrl + TradeAssetUrl);
    }
}