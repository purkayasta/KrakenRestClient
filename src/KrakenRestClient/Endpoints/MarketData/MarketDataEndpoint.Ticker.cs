using KrakenRestClient.Contracts;
using KrakenRestClient.Models.MarketData;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TickerUrl = "Ticker";

    public Task<TickerInformationResponse?> GetTickerInformation(string pair)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);

        return _httpClient.Get<TickerInformationResponse>(KrakenConstants.PublicBaseUrl + TickerUrl);
    }
}