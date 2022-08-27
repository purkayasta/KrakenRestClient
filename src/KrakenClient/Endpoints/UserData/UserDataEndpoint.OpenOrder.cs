using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string OpenOrderUrl = "OpenOrders";

    public Task<OpenOrders?> GetOpenOrders(bool trades = false, int? userReferenceId = null)
    {
        _httpClient.BodyParameters.Add("trades", trades.ToValueStr());
        if (userReferenceId.HasValue) _httpClient.BodyParameters.Add("userref", userReferenceId.Value.ToString());
        return _httpClient.Post<OpenOrders>(BaseUrl + OpenOrderUrl);
    }
}
