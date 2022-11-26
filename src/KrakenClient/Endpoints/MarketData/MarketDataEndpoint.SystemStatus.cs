using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string SystemStatusUrl = "SystemStatus";

    public Task<SystemStatusResponse?> GetSystemStatus() => _httpClient.Get<SystemStatusResponse>(KrakenConstants.PublicBaseUrl + SystemStatusUrl);
}