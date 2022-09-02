using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string QueryTradeInfoUrl = "QueryTrades";

    public Task<TradesInfo?> QueryTradesInfo(string transactionIds, bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        return _httpClient.Post<TradesInfo>(BaseUrl + QueryTradeInfoUrl);
    }
}