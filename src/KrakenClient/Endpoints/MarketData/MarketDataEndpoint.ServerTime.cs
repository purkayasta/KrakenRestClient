using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string ServerTimeUrl = "Time";

    public Task<ServerTime?> GetServerTime() => _httpClient.Get<ServerTime>(BaseUrl + ServerTimeUrl);
}