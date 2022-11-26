using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string RecentTradeUrl = "Trades";

    public Task<RecentTradesResponse?> GetRecentTrades(string pair, int? since = null)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);
        if (since is not null) _httpClient.BodyParameters.Add("since", since.Value.ToString());

        return _httpClient.Get<RecentTradesResponse>(KrakenConstants.PublicBaseUrl + RecentTradeUrl);
    }
}
