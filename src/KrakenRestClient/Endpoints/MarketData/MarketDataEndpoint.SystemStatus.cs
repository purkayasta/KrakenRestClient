using KrakenRestClient.Contracts;
using KrakenRestClient.Models.MarketData;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string SystemStatusUrl = "SystemStatus";

    public Task<SystemStatusResponse?> GetSystemStatusAsync() => _httpClient.Get<SystemStatusResponse>(KrakenConstants.PublicBaseUrl + SystemStatusUrl);
}