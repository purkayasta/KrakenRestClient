using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string AssetInfoUrl = "Assets";

    public Task<AssetInfo?> GetAssetInfo() => _httpClient.Get<AssetInfo>(BaseUrl + AssetInfoUrl);

    public Task<AssetInfo?> GetAssetInfo(string asset, string aclass = "currency")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));
        ArgumentNullException.ThrowIfNull(aclass, nameof(aclass));

        _httpClient.BodyParameters.Add("asset", asset);
        _httpClient.BodyParameters.Add("aclass", aclass);

        return _httpClient.Get<AssetInfo>(BaseUrl + AssetInfoUrl);
    }
}