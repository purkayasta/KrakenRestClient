using KrakenClient.Models.UserData;

namespace KrakenClient.Contracts;

public interface IUserDataEndpoint
{
    /// <summary>
    /// Retrieve all cash balances, net of pending withdrawals.
    /// </summary>
    /// <returns></returns>
    Task<AccountBalance?> GetAccountBalance();

    /// <summary>
    /// Retrieve information about currently open orders.
    /// </summary>
    Task<OpenOrders?> GetOpenOrders(bool trades = false, int? userReferenceId = null);

    /// <summary>
    /// Retrieve a summary of collateral balances, margin position valuations, equity and margin level.
    /// </summary>
    /// <param name="asset">ZUSD</param>
    /// <returns></returns>
    Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD");

    /// <summary>
    /// Retrieve information about orders that have been closed (filled or cancelled). 50 results are returned at a time, the most recent by default.
    /// Note: If an order's tx ID is given for start or end time, the order's opening time (opentm) is used
    /// </summary>
    /// <param name="trades">false</param>
    /// <param name="userReferenceId"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="offset"></param>
    /// <param name="closedTime">both</param>
    /// <returns></returns>
    Task<ClosedOrders?> GetClosedOrders(bool trades = false, int? userReferenceId = null, int? startTime = null,
        int? endTime = null, int? offset = null, string closedTime = "both");
}