using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string ServerTimeUrl = "Time";

    public Task<ServerTime?> GetServerTime() => _httpClient.Get<ServerTime>(KrakenConstants.PublicBaseUrl + ServerTimeUrl);
}