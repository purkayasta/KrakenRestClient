using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string ClosedOrderUrl = "ClosedOrders";

    public async Task<ClosedOrderResponse?> GetClosedOrdersAsync(
        bool trades = false,
        int? userReferenceId = null,
        int? startTime = null,
        int? endTime = null,
        int? offset = null,
        string closedTime = "both")
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        if (userReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, userReferenceId.Value.ToString());
        if (startTime.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.Start, startTime.Value.ToString());
        if (endTime.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.End, endTime.Value.ToString());
        if (offset.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.OffSet, offset.Value.ToString());

        _httpClient.BodyParameters.Add(KrakenParameter.CloseTime, closedTime);

        ClosedOrderResponse? result;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<ClosedOrderResponse>(KrakenConstants.PrivateBaseUrl + ClosedOrderUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}