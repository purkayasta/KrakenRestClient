namespace KrakenRestClient.Endpoints.UserFunding;

internal sealed partial class UserFundingEndpoint : BaseEndpoint, IUserFundingEndpoint
{
    private readonly IKrakenHttpClient _httpClient;

    public UserFundingEndpoint(IKrakenHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}