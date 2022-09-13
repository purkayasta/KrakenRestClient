using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string RecentTradeUrl = "Trades";

    public Task<RecentTrades?> GetRecentTrades(string pair, int? since = null)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);
        if (since is not null) _httpClient.BodyParameters.Add("since", since.Value.ToString());

        return _httpClient.Get<RecentTrades>(BaseUrl + RecentTradeUrl);
    }
}
