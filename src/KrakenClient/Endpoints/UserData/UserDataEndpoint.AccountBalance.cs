using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string UserDataUrl = "Balance";

    public Task<AccountBalance?> GetAccountBalance() => _httpClient.Post<AccountBalance>(KrakenConstants.PrivateBaseUrl + UserDataUrl);
}