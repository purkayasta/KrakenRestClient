using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string OpenOrderUrl = "OpenOrders";

    public async Task<OpenOrderResponse?> GetOpenOrdersAsync(bool trades = false, int? userReferenceId = null)
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        if (userReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, userReferenceId.Value.ToString());

        OpenOrderResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<OpenOrderResponse>(KrakenConstants.PrivateBaseUrl + OpenOrderUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}