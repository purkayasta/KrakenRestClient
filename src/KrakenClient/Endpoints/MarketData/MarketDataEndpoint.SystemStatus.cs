using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string SystemStatusUrl = "SystemStatus";

    public Task<SystemStatus?> GetSystemStatus() => _httpClient.Get<SystemStatus>(BaseUrl + SystemStatusUrl);
}