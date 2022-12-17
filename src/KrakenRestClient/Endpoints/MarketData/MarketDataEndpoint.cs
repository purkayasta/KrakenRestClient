namespace KrakenRestClient.Endpoints.MarketData;

internal sealed partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public MarketDataEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}