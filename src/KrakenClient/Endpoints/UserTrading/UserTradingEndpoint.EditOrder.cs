using KrakenClient.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrakenClient.Endpoints.UserTrading;

internal sealed partial class UserTradingEndpoint : IUserTradingEndpoint
{
    public Task EditOrder()
    {
        return Task.CompletedTask;
    }
}
