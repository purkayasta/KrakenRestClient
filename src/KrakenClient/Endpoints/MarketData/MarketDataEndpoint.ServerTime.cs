using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string ServerTimeUrl = "Time";

    public Task<ServerTimeResponse?> GetServerTime() => _httpClient.Get<ServerTimeResponse>(KrakenConstants.PublicBaseUrl + ServerTimeUrl);
}