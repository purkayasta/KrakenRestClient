namespace KrakenRestClient.Endpoints.UserStaking;

internal partial class UserStakingEndpoint : BaseEndpoint, IUserStakingEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserStakingEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}