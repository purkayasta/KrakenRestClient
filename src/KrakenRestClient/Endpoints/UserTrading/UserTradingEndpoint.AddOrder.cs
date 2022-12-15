using KrakenRestClient.Models.UserTrading;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint
{
    private const string AddOrderUrl = "AddOrder";
    private const string AddBatchOrderUrl = "AddOrderBatch";

    public async Task<AddOrderResponse?> AddOrderAsync(AddOrderRequest? request)
    {
        if (request is null) KrakenException.Throw("Request Parameter is null");
        AddOrderResponse? result = null;

        if (request!.UserReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, request!.UserReferenceId.Value.ToString());

        _httpClient.BodyParameters.Add(KrakenParameter.OrderType, request!.OrderType);
        _httpClient.BodyParameters.Add(KrakenParameter.Type, request!.Type);
        _httpClient.BodyParameters.Add(KrakenParameter.Volume, request!.Volume.ToString());
        _httpClient.BodyParameters.Add(KrakenParameter.Pair, request!.Pair);

        if (!request!.DisplayVolume.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.DisplayVolume, request!.DisplayVolume!);
        if (request.Price.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.Price, request.Price.Value.ToString());
        if (request!.Price2.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.Price2, request!.Price2.Value.ToString());
        if (!request!.Trigger.IsEmpty()) _httpClient.BodyParameters.Add(KrakenParameter.Trigger, request!.Trigger!);
        if (!request!.Leverage.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.LeverageAmount, request!.Leverage!);
        if (!request!.SelfTradePreventionType.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.SelfTradePreventionType, request!.SelfTradePreventionType!);
        if (!request!.OrderFlags.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.OrderFlags, request!.OrderFlags!);
        if (!request!.TimeInForce.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.TimeInForce, request!.TimeInForce!);
        if (!request!.StartTime.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.StartTime, request!.StartTime!);
        if (!request!.ExpireTime.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.ExpireTime, request!.ExpireTime!);
        if (!request!.ConditionalCloseOrderType.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.ConditionalCloseOrderType,
                request!.ConditionalCloseOrderType!);
        if (request!.ConditionalCloseOrderPrice.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.ConditionalCloseOrderPrice,
                request!.ConditionalCloseOrderPrice.ToString()!);
        if (request!.ConditionalCloseOrderPrice2.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.ConditionalCloseOrderPrice2,
                request!.ConditionalCloseOrderPrice2.ToString()!);
        if (!request!.DeadLine.IsEmpty()) _httpClient.BodyParameters.Add(KrakenParameter.DeadLine, request!.DeadLine!);
        if (request!.Validate) _httpClient.BodyParameters.Add(KrakenParameter.Validate, request!.Validate.ToString());

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<AddOrderResponse>(KrakenConstants.PrivateBaseUrl + AddOrderUrl);
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

    public async Task<AddBatchOrderResponse?> AddOrderBatchAsync(AddBatchOrderRequest? requests)
    {
        if (requests is null) KrakenException.Throw(nameof(AddBatchOrderRequest) + " is null");

        _httpClient.BodyParameters.Add(KrakenParameter.Pair, requests!.Pair);
        if (requests!.DeadLine.IsEmpty()) _httpClient.BodyParameters.Add(KrakenParameter.DeadLine, requests!.DeadLine!);
        if (requests!.Validate) _httpClient.BodyParameters.Add(KrakenParameter.Validate, requests!.Validate.ToString());

        if (requests!.AddOrderRequest.Length >= 15) KrakenException.Throw("Cannot order more than 15 order request");

        _httpClient.BodyParameters.Add(KrakenParameter.Orders, requests!.AddOrderRequest!.ToStr());

        AddBatchOrderResponse? result = null;
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<AddBatchOrderResponse>(KrakenConstants.PrivateBaseUrl + AddBatchOrderUrl);
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