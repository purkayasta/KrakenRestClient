using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryTradeHistoryUrl = "TradesHistory";

    public async Task<TradesHistoryResponse?> GetTradesHistory(string type = "all", bool trades = false, int? start = null,
        int? end = null, int? offset = null)
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Type, type);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        if (start.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.Start, start.Value.ToString());
        if (end.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.End, end.Value.ToString());
        if (offset.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.OffSet, offset.Value.ToString());

        TradesHistoryResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<TradesHistoryResponse>(KrakenConstants.PrivateBaseUrl + QueryTradeHistoryUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}