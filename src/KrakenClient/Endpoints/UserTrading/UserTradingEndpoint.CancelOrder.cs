namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint
{
    public Task CancelOrder()
    {
        return Task.CompletedTask;
    }

    public Task CancelAllOrder() => Task.CompletedTask;

    public Task CancelAllOrderAfterX() => Task.CompletedTask;

    public Task CancelOrderBatch() => Task.CompletedTask;
}
