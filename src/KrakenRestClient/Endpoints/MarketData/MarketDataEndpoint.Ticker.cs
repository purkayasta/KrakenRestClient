using KrakenRestClient.Models.MarketData;

namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private const string TickerUrl = "Ticker";

    public Task<TickerInformationResponse?> GetTickerInformationAsync(string pair)
    {
        ArgumentNullException.ThrowIfNull(pair, nameof(pair));

        _httpClient.BodyParameters.Add("pair", pair);

        return _httpClient.Get<TickerInformationResponse>(KrakenConstants.PublicBaseUrl + TickerUrl);
    }
}