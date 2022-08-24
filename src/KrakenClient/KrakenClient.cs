using KrakenClient.Contracts;
using KrakenClient.Core;
using KrakenClient.Endpoints.MarketData;

namespace KrakenClient;

internal class KrakenClient : IKrakenClient
{
    private readonly Lazy<IMarketDataEndpoint> _marketDataEndpoint;
    
    public KrakenClient(IKrakenHttpClient httpClient)
    {
        _marketDataEndpoint = new Lazy<IMarketDataEndpoint>(() => new MarketDataEndpoint(httpClient));
    }

    public IMarketDataEndpoint MarketData() => _marketDataEndpoint.Value;
}