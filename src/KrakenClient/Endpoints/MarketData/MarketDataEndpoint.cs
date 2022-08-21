using KrakenClient.Contracts;
using KrakenClient.Core;
using KrakenClient.Models.MarketData;

namespace KrakenClient.Endpoints.MarketData;

internal partial class MarketDataEndpoint : IMarketDataEndpoint
{
    private readonly IKrakenHttpClient _httpClient;
    private const string BaseUrl = "/public";

    public MarketDataEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
}