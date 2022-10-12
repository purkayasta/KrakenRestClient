using KrakenClient.Contracts;

namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint : IUserTradingEndpoint
{
    public Task AddOrder()
    {
        return Task.CompletedTask;
    }

    public Task AddOrderBatch()
    {
        return Task.CompletedTask;
    }
}
