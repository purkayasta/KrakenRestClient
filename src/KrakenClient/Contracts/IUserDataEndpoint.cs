using KrakenClient.Models.UserData;

namespace KrakenClient.Contracts;

public interface IUserDataEndpoint
{
    Task<AccountBalance?> GetAccountBalance();
}