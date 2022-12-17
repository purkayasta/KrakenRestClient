namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : BaseEndpoint, IUserDataEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserDataEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}