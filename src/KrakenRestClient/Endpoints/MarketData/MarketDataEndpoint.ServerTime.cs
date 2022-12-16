using KrakenRestClient.Models.MarketData;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string ServerTimeUrl = "Time";

    public Task<ServerTimeResponse?> GetServerTimeAsync() => _httpClient.Get<ServerTimeResponse>(KrakenConstants.PublicBaseUrl + ServerTimeUrl);
}