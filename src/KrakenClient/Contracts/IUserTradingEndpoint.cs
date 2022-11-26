using KrakenClient.Models.UserTrading;

namespace KrakenClient.Contracts;

public interface IUserTradingEndpoint
{
    Task<AddOrder?> AddOrderAsync(AddOrderRequest? request);
    Task<AddBatchOrder?> AddOrderBatchAsync(AddBatchOrderRequest? requests);
}