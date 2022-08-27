using KrakenClient.Models.UserData;

namespace KrakenClient.Contracts;

public interface IUserDataEndpoint
{
    Task<AccountBalance?> GetAccountBalance();
    Task<OpenOrders?> GetOpenOrders(bool trades = false, int? userReferenceId = null);
    Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD");
}