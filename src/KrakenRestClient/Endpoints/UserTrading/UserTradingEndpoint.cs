namespace KrakenRestClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint : BaseEndpoint, IUserTradingEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserTradingEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
