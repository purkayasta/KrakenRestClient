using KrakenClient.Contracts;
using KrakenClient.Core;
using KrakenClient.Endpoints.MarketData;
using KrakenClient.Endpoints.UserData;

namespace KrakenClient;

internal class KrakenClient : IKrakenClient
{
    private readonly Lazy<IMarketDataEndpoint> _marketDataEndpoint;
    private readonly Lazy<IUserDataEndpoint> _userDataEndpoint;

    public KrakenClient(IKrakenHttpClient httpClient)
    {
        _marketDataEndpoint = new Lazy<IMarketDataEndpoint>(() => new MarketDataEndpoint(httpClient));
        _userDataEndpoint = new Lazy<IUserDataEndpoint>(() => new UserDataEndpoint(httpClient));
    }

    public IMarketDataEndpoint MarketData() => _marketDataEndpoint.Value;
    public IUserDataEndpoint UserData() => _userDataEndpoint.Value;
}