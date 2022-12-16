using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryOrderInfoUrl = "QueryOrders";

    public async Task<OrdersInfoResponse?> QueryOrdersInfoAsync(string transactionIds, int? userReferenceId = null,
        bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        if (userReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, userReferenceId.Value.ToString());

        OrdersInfoResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<OrdersInfoResponse>(KrakenConstants.PrivateBaseUrl + QueryOrderInfoUrl);
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