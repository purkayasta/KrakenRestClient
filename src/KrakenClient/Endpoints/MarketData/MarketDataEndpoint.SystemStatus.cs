using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string SystemStatusUrl = "SystemStatus";

    public Task<SystemStatus?> GetSystemStatus() => _httpClient.Get<SystemStatus>(KrakenConstants.PublicBaseUrl + SystemStatusUrl);
}