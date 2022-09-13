using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string OpenOrderUrl = "OpenOrders";

    public Task<OpenOrders?> GetOpenOrders(bool trades = false, int? userReferenceId = null)
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());
        if (userReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, userReferenceId.Value.ToString());
        return _httpClient.Post<OpenOrders>(BaseUrl + OpenOrderUrl);
    }
}