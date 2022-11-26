using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string AssetInfoUrl = "Assets";

    public Task<AssetInfoResponse?> GetAssetInfo() => _httpClient.Get<AssetInfoResponse>(KrakenConstants.PublicBaseUrl + AssetInfoUrl);

    public Task<AssetInfoResponse?> GetAssetInfo(string asset, string aclass = "currency")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));
        ArgumentNullException.ThrowIfNull(aclass, nameof(aclass));

        _httpClient.BodyParameters.Add("asset", asset);
        _httpClient.BodyParameters.Add("aclass", aclass);

        return _httpClient.Get<AssetInfoResponse>(KrakenConstants.PublicBaseUrl + AssetInfoUrl);
    }
}