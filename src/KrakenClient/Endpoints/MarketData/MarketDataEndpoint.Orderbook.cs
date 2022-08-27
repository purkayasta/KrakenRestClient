using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string OrderBookUrl = "Depth";

    public Task<OrderBook?> GetOrderBook(string pair, int count = 2)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);
        _httpClient.BodyParameters.Add("count", count.ToString());

        return _httpClient.Get<OrderBook>(BaseUrl + OrderBookUrl);
    }
}
