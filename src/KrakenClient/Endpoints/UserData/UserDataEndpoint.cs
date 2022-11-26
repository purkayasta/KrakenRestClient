using KrakenClient.Contracts;
using KrakenClient.Core;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : BaseEndpoint, IUserDataEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserDataEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}