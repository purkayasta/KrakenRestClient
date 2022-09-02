using KrakenClient.Contracts;
using KrakenClient.Core;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private readonly IKrakenHttpClient _httpClient;
    private const string BaseUrl = "private/";

    public UserDataEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}