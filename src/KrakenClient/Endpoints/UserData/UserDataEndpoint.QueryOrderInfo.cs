using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryOrderInfoUrl = "QueryOrders";

    public async Task<OrdersInfo?> QueryOrdersInfo(string transactionIds, int? userReferenceId = null,
        bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        if (userReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, userReferenceId.Value.ToString());

        OrdersInfo? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<OrdersInfo>(KrakenConstants.PrivateBaseUrl + QueryOrderInfoUrl);
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}