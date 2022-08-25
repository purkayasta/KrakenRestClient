using KrakenClient.Contracts;
using KrakenClient.Models.UserData;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string UserDataUrl = "Balance";

    public Task<AccountBalance?> GetAccountBalance() => _httpClient.Post<AccountBalance>(BaseUrl + UserDataUrl);
}