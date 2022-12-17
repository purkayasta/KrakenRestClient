using KrakenRestClient.Endpoints.MarketData;
using KrakenRestClient.Endpoints.UserData;
using KrakenRestClient.Endpoints.UserFunding;
using KrakenRestClient.Endpoints.UserStaking;
using KrakenRestClient.Endpoints.UserTrading;

namespace KrakenRestClient;

internal sealed class KrakenClient : IKrakenClient
{
    private readonly Lazy<IMarketDataEndpoint> _marketDataEndpoint;
    private readonly Lazy<IUserDataEndpoint> _userDataEndpoint;
    private readonly Lazy<IUserTradingEndpoint> _userTradingEndpoint;
    private readonly Lazy<IUserFundingEndpoint> _userFundingEndpoint;
    private readonly Lazy<IUserStakingEndpoint> _userStakingEndpoint;

    public KrakenClient(IKrakenHttpClient httpClient)
    {
        _marketDataEndpoint = new Lazy<IMarketDataEndpoint>(() => new MarketDataEndpoint(httpClient));
        _userDataEndpoint = new Lazy<IUserDataEndpoint>(() => new UserDataEndpoint(httpClient));
        _userTradingEndpoint = new Lazy<IUserTradingEndpoint>(() => new UserTradingEndpoint(httpClient));
        _userFundingEndpoint = new Lazy<IUserFundingEndpoint>(() => new UserFundingEndpoint(httpClient));
        _userStakingEndpoint = new Lazy<IUserStakingEndpoint>(() => new UserStakingEndpoint(httpClient));
    }

    public IMarketDataEndpoint MarketData() => _marketDataEndpoint.Value;
    public IUserDataEndpoint UserData() => _userDataEndpoint.Value;
    public IUserTradingEndpoint UserTrading() => _userTradingEndpoint.Value;
    public IUserFundingEndpoint UserFunding() => _userFundingEndpoint.Value;
    public IUserStakingEndpoint UserStaking() => _userStakingEndpoint.Value;
}