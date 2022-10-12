namespace KrakenClient.Contracts;

public interface IUserTradingEndpoint
{
    Task AddOrder();
    Task AddOrderBatch();
    Task CancelAllOrder();
    Task CancelAllOrderAfterX();
    Task CancelOrder();
    Task CancelOrderBatch();
    Task EditOrder();
}
