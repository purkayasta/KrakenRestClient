using KrakenClient.Contracts;

namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint : IUserTradingEndpoint
{
    public Task CancelOrder()
    {
        return Task.CompletedTask;
    }

    public Task CancelAllOrder() => Task.CompletedTask;

    public Task CancelAllOrderAfterX() => Task.CompletedTask;

    public Task CancelOrderBatch() => Task.CompletedTask;
}
