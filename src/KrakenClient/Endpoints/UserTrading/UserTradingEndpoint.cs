using KrakenClient.Contracts;
using KrakenClient.Core;

namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint : BaseEndpoint, IUserTradingEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserTradingEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
