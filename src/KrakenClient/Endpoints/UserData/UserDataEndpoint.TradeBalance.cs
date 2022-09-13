using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string TradeBalanceUrl = "TradeBalance";

    public Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        return _httpClient.Post<TradeBalance>(BaseUrl + TradeBalanceUrl);
    }
}