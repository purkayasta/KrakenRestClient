using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string OrderBookUrl = "Depth";

    public Task<OrderBookResponse?> GetOrderBook(string pair, int count = 2)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);
        _httpClient.BodyParameters.Add("count", count.ToString());

        return _httpClient.Get<OrderBookResponse>(KrakenConstants.PublicBaseUrl + OrderBookUrl);
    }
}
