using KrakenRestClient.Contracts;
using KrakenRestClient.Models.MarketData;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TradeAssetUrl = "AssetPairs";

    public Task<TradeAbleAssetPairResponse?> GetTradableAssetPairAsync(string assetPair)
    {
        ArgumentNullException.ThrowIfNull(assetPair, nameof(assetPair));

        _httpClient.BodyParameters.Add("pair", assetPair);
        return _httpClient.Get<TradeAbleAssetPairResponse>(KrakenConstants.PublicBaseUrl + TradeAssetUrl);
    }
}