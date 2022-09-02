using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string QueryLedgersUrl = "QueryLedgers";

    public Task<Ledgers?> QueryLedgers(string id, bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        return _httpClient.Post<Ledgers>(BaseUrl + QueryLedgersUrl);
    }
}