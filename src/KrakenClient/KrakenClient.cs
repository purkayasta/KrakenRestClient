using KrakenClient.Contracts;
using KrakenClient.Core;
using KrakenClient.Endpoints.MarketData;

namespace KrakenClient;

internal class KrakenClient : IKrakenClient
{
    private readonly IKrakenHttpClient _httpClient;

    public KrakenClient(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IMarketDataEndpoint MarketData() => new MarketDataEndpoint(_httpClient);
}