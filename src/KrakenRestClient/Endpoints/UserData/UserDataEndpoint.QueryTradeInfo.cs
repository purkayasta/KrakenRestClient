using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryTradeInfoUrl = "QueryTrades";

    public async Task<TradesInfoResponse?> QueryTradesInfoAsync(string transactionIds, bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        TradesInfoResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<TradesInfoResponse>(KrakenConstants.PrivateBaseUrl + QueryTradeInfoUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}