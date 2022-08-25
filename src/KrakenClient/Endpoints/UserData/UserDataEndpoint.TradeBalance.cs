using KrakenClient.Contracts;
using KrakenClient.Models.UserData;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string TradeBalanceUrl = "";

    public Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));

        _httpClient.BodyParameters.Add("asset", asset);
        return _httpClient.Post<TradeBalance>(BaseUrl + TradeBalanceUrl);
    }
}