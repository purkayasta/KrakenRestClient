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

    /// <summary>
    /// Retrieve information about specific orders.
    /// </summary>
    /// <param name="transactionIds">(required*)Comma delimited list of transaction IDs to query info about (50 maximum)</param>
    /// <param name="userReferenceId">Restrict results to given user reference id</param>
    /// <param name="trades">Whether or not to include trades related to position in output</param>
    /// <returns></returns>
    Task<OrdersInfo?> GetOrdersInfo(string transactionIds, int? userReferenceId = null, bool trades = false);

    /// <summary>
    /// Retrieve information about trades/fills. 50 results are returned at a time, the most recent by default.
    /// </summary>
    /// <param name="type">Enum: "all" "any position" "closed position" "closing position" "no position"</param>
    /// <param name="trades">Whether or not to include trades related to position in output</param>
    /// <param name="start">Starting unix timestamp or trade tx ID of results (exclusive)</param>
    /// <param name="end">Ending unix timestamp or trade tx ID of results (inclusive)</param>
    /// <param name="offset">Result offset for pagination</param>
    /// <returns></returns>
    Task<TradesHistory?> GetTradesHistory(string type = "all", bool trades = false, int? start = null,
        int? end = null, int? offset = null);

    /// <summary>
    /// Retrieve information about specific trades/fills.
    /// </summary>
    /// <param name="transactionIds">Comma delimited list of transaction IDs to query info about (20 maximum)</param>
    /// <param name="trades">Whether or not to include trades related to position in output</param>
    /// <returns></returns>
    Task<TradesInfo?> GetTradesInfo(string transactionIds, bool trades = false);
}