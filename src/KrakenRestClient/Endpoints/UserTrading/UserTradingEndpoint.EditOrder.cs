using KrakenRestClient.Models.UserTrading;

namespace KrakenRestClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint
{
    private const string EditOrderUrl = "EditOrder";

    public async Task<EditOrderResponse?> EditOrderAsync(EditOrderRequest? request)
    {
        if (request is null) KrakenException.Throw(nameof(EditOrderRequest) + " is null");

        if (request!.UserReferenceId.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.UserReferenceId, request!.UserReferenceId.Value.ToString());

        if (!request!.TransactionId.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, request!.TransactionId);

        if (request.Volume.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.Volume, request!.Volume!.Value.ToString());

        if (!request!.DisplayVolume.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.DisplayVolume, request!.DisplayVolume!);

        if (!request!.Pair.IsEmpty()) _httpClient.BodyParameters.Add(KrakenParameter.Pair, request!.Pair);

        if (request!.Price.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.Price, request!.Price!.Value.ToString());

        if (request!.SecondaryPrice.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.Price2, request!.SecondaryPrice!.Value.ToString());

        if (!request!.OrderFlags.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.OrderFlags, request!.OrderFlags!);

        if (!request!.DeadLine.IsEmpty())
            _httpClient.BodyParameters.Add(KrakenParameter.DeadLine, request!.DeadLine!);

        if (request!.CancelResponse.HasValue)
            _httpClient.BodyParameters.Add(KrakenParameter.CancelResponse, request!.CancelResponse!.Value.ToString());

        _httpClient.BodyParameters.Add(KrakenParameter.Validate, request!.Validate.ToString());

        EditOrderResponse? response = null;
        
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<EditOrderResponse>(KrakenConstants.PrivateBaseUrl + EditOrderUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}