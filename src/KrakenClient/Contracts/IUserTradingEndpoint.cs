using KrakenClient.Models.UserTrading;

namespace KrakenClient.Contracts;

public interface IUserTradingEndpoint
{
    Task<AddOrderResponse?> AddOrderAsync(AddOrderRequest? request);
    Task<AddBatchOrderResponse?> AddOrderBatchAsync(AddBatchOrderRequest? requests);
    Task<EditOrderResponse?> EditOrderAsync(EditOrderRequest? request);
    Task<CancelOrderResponse?> CancelOrderAsync(string transactionId);
    Task<CancelAllOrderResponse?> CancelAllOrderAsync();
    Task<CancelAllOrderAfterXResponse?> CancelAllOrderAfterXAsync(int timeOut);
    Task<CancelOrderBatchResponse?> CancelOrderBatchAsync(string[] transactionIds);
}