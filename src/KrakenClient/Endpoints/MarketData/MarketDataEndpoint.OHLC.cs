using KrakenClient.Contracts;
using KrakenClient.Models.MarketData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string OhlcUrl = "OHLC";

    public Task<OHLCDataResponse?> GetOhlcData(string pair, int? since = null, int interval = 1)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);
        _httpClient.BodyParameters.Add("interval", interval.ToString());
        if (since is not null) _httpClient.BodyParameters.Add("since", since.Value.ToString());

        return _httpClient.Get<OHLCDataResponse>(KrakenConstants.PublicBaseUrl + OhlcUrl);
    }
}