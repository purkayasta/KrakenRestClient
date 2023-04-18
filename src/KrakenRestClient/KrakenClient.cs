namespace KrakenRestClient;

internal sealed class KrakenClient : IKrakenClient
{
    private readonly IMarketDataEndpoint? _marketDataEndpoint;
    private readonly IUserDataEndpoint? _userDataEndpoint;
    private readonly IUserTradingEndpoint? _userTradingEndpoint;
    private readonly IUserFundingEndpoint? _userFundingEndpoint;
    private readonly IUserStakingEndpoint? _userStakingEndpoint;


    public KrakenClient(
        IMarketDataEndpoint? marketDataEndpoint = default,
        IUserDataEndpoint? userDataEndpoint = default,
        IUserTradingEndpoint? userTradingEndpoint = default,
        IUserFundingEndpoint? userFundingEndpoint = default,
        IUserStakingEndpoint? userStakingEndpoint = default)
    {
        _marketDataEndpoint = marketDataEndpoint;
        _userDataEndpoint = userDataEndpoint;
        _userTradingEndpoint = userTradingEndpoint;
        _userFundingEndpoint = userFundingEndpoint;
        _userStakingEndpoint = userStakingEndpoint;
    }

    public IMarketDataEndpoint MarketData
    {
        get
        {
            if (_marketDataEndpoint is null) throw new KrakenException(nameof(IMarketDataEndpoint) + " is null");
            return _marketDataEndpoint;
        }
    }

    public IUserDataEndpoint UserData
    {
        get
        {
            if (_userDataEndpoint is null) throw new KrakenException(nameof(IUserDataEndpoint) + " is null");
            return _userDataEndpoint;
        }
    }

    public IUserTradingEndpoint UserTrading
    {
        get
        {
            if (_userTradingEndpoint is null) throw new KrakenException(nameof(IUserTradingEndpoint) + " is null");
            return _userTradingEndpoint;
        }
    }

    public IUserFundingEndpoint UserFunding
    {
        get
        {
            if (_userFundingEndpoint is null) throw new KrakenException(nameof(IUserFundingEndpoint) + " is null");
            return _userFundingEndpoint;
        }
    }

    public IUserStakingEndpoint UserStaking
    {
        get
        {
            if (_userStakingEndpoint is null) throw new KrakenException(nameof(IUserStakingEndpoint) + " is null");
            return _userStakingEndpoint;
        }
    }
}