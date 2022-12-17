using KrakenRestClient.Models.MarketData;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string SystemStatusUrl = "SystemStatus";

    public Task<SystemStatusResponse?> GetSystemStatusAsync() =>
        _httpClient.Get<SystemStatusResponse>(KrakenConstants.PublicBaseUrl + SystemStatusUrl);
}