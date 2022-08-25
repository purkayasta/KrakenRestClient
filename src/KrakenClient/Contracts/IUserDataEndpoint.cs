using KrakenClient.Models.UserData;

namespace KrakenClient.Contracts;

public interface IUserDataEndpoint
{
    Task<AccountBalance?> GetAccountBalance();
    Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD");
}