using KrakenRestClient.Core;
using KrakenRestClient.Endpoints.MarketData;
using KrakenRestClient.Endpoints.UserData;
using KrakenRestClient.Endpoints.UserTrading;

namespace KrakenRestClient;

internal sealed class KrakenClient : IKrakenClient
{
    private readonly Lazy<IMarketDataEndpoint> _marketDataEndpoint;
    private readonly Lazy<IUserDataEndpoint> _userDataEndpoint;
    private readonly Lazy<IUserTradingEndpoint> _userTradingEndpoint;

    public KrakenClient(IKrakenHttpClient httpClient)
    {
        _marketDataEndpoint = new Lazy<IMarketDataEndpoint>(() => new MarketDataEndpoint(httpClient));
        _userDataEndpoint = new Lazy<IUserDataEndpoint>(() => new UserDataEndpoint(httpClient));
        _userTradingEndpoint = new Lazy<IUserTradingEndpoint>(() => new UserTradingEndpoint(httpClient));
    }

    public IMarketDataEndpoint MarketData() => _marketDataEndpoint.Value;
    public IUserDataEndpoint UserData() => _userDataEndpoint.Value;
    public IUserTradingEndpoint UserTrading() => _userTradingEndpoint.Value;
}