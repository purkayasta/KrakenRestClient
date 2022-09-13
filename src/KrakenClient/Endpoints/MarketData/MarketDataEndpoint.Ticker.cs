using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TickerUrl = "Ticker";

    public Task<TickerInformation?> GetTickerInformation(string pair)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);

        return _httpClient.Get<TickerInformation>(BaseUrl + TickerUrl);
    }
}