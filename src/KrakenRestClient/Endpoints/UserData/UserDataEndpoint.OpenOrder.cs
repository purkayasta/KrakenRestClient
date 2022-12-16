using KrakenRestClient.Models.UserData;
using KrakenRestClient.Utilities;

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