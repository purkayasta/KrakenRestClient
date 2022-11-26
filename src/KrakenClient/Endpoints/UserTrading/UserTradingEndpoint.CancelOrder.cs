using KrakenClient.Models.UserTrading;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint
{
    private const string CancelOrderUrl = "CancelOrder";
    private const string CancelAllOrderUrl = "CancelAll";
    private const string CancelAllOrderAfterUrl = "CancelAllOrdersAfter";
    private const string CancelOrderBatchUrl = "CancelOrderBatch";

    public async Task<CancelOrderResponse?> CancelOrderAsync(string transactionId)
    {
        KrakenException.ThrowIfNullOrEmpty(transactionId, nameof(transactionId));

        CancelOrderResponse? response = null;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<CancelOrderResponse>(KrakenConstants.PrivateBaseUrl + CancelOrderUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<CancelAllOrderResponse?> CancelAllOrderAsync()
    {
        CancelAllOrderResponse? response = null;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<CancelAllOrderResponse>(
                KrakenConstants.PrivateBaseUrl + CancelAllOrderUrl);
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<CancelAllOrderAfterXResponse?> CancelAllOrderAfterXAsync(int timeOut)
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Timeout, timeOut.ToString());

        CancelAllOrderAfterXResponse? response = null;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<CancelAllOrderAfterXResponse>(KrakenConstants.PrivateBaseUrl +
                                                                            CancelAllOrderAfterUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<CancelOrderBatchResponse?> CancelOrderBatchAsync(string[] transactionIds)
    {
        if (transactionIds.Length < 1) KrakenException.Throw(nameof(transactionIds) + " is empty");
        
        _httpClient.BodyParameters.Add(KrakenParameter.Orders, transactionIds.ToStr());
        
        CancelOrderBatchResponse? response = null;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<CancelOrderBatchResponse>(KrakenConstants.PrivateBaseUrl +
                                                                        CancelOrderBatchUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}