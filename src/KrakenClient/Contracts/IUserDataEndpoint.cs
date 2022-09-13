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
    Task<OrdersInfo?> QueryOrdersInfo(string transactionIds, int? userReferenceId = null, bool trades = false);

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
    Task<TradesInfo?> QueryTradesInfo(string transactionIds, bool trades = false);

    /// <summary>
    /// Get information about open margin positions.
    /// </summary>
    /// <param name="transactionIds">Comma delimited list of txids to limit output to</param>
    /// <param name="docalcs">Whether to include P&L calculations</param>
    /// <param name="consolidation">Consolidate positions by market/pair</param>
    /// <returns></returns>
    Task<OpenPositions?> GetOpenPositions(string transactionIds, bool docalcs = false,
        string consolidation = "market");

    /// <summary>
    /// Retrieve information about ledger entries. 50 results are returned at a time, the most recent by default.
    /// </summary>
    /// <param name="asset">Comma delimited list of assets to restrict output to, Default => all</param>
    /// <param name="aclass">Asset, Default: "currency"</param>
    /// <param name="type">Type of ledger to retrieve, Enum: "all" "deposit" "withdrawal" "trade" "margin" "rollover" "credit" "transfer" "settled" "staking" "sale"</param>
    /// <param name="start">Starting unix timestamp or ledger ID of results (exclusive)</param>
    /// <param name="end">Ending unix timestamp or ledger ID of results (inclusive)</param>
    /// <param name="offset">Result offset for pagination</param>
    /// <returns></returns>
    Task<LedgerInfo?> GetLedgerInfo(string asset = "all", string aclass = "currency", string type = "all",
        int? start = null, int? end = null, int? offset = null);

    /// <summary>
    /// Retrieve information about specific ledger entries.
    /// </summary>
    /// <param name="id">Comma delimited list of ledger IDs to query info about (20 maximum)</param>
    /// <param name="trades">Whether or not to include trades related to position in output. Default = false</param>
    /// <returns></returns>
    Task<Ledgers?> QueryLedgers(string id, bool trades = false);

    /// <summary>
    /// If an asset pair is on a maker/taker fee schedule, the taker side is given in fees and maker side in fees_maker. For pairs not on maker/taker, they will only be given in fees.
    /// </summary>
    /// <param name="pair">Comma delimited list of asset pairs to get fee info on (optional)</param>
    /// <param name="feeInfo">Whether or not to include fee info in results (optional)</param>
    /// <returns></returns>
    Task<TradeVolume?> GetTradeVolume(string? pair = null, bool? feeInfo = null);

    /// <summary>
    /// Request export of trades or ledgers.
    /// </summary>
    /// <param name="report">Type of data to export, Enum: "trades" "ledgers"</param>
    /// <param name="description">Description for the export</param>
    /// <param name="format">File format to export. Enum: "CSV" "TSV"</param>
    /// <param name="fields">Comma-delimited list of fields to include
    /// <list type="bullet"><code>trades:</code> ordertxid, time, ordertype, price, cost, fee, vol, margin, misc, ledgers</list>
    /// <list type="bullet"><code>ledgers:</code>  refid, time, type, aclass, asset, amount, fee, balance</list>
    /// </param>
    /// <param name="starttm">UNIX timestamp for report start time (default 1st of the current month)</param>
    /// <param name="endtm">UNIX timestamp for report end time (default now)</param>
    /// <returns></returns>
    Task<RequestExportReport?> RequestExportReport(string report, string description, string format = "csv", string fields = "all", int? starttm = null, int? endtm = null);

    /// <summary>
    /// Get status of requested data exports.
    /// </summary>
    /// <param name="report">Type of reports to inquire about. Enum: "trades" "ledgers"</param>
    /// <returns></returns>
    Task<ExportReportStatus?> GetExportReportStatus(string report);

    /// <summary>
    /// Retrieve a processed data export
    /// </summary>
    /// <param name="id">Report ID to retrieve</param>
    /// <returns></returns>
    Task<Stream?> RetrieveDataExport(string id);

    /// <summary>
    /// Delete exported trades/ledgers report
    /// </summary>
    /// <param name="id">ID of report to delete or cancel</param>
    /// <param name="type">Enum: "cancel" "delete". delete can only be used for reports that have already been processed. Use cancel for queued or processing reports.</param>
    /// <returns></returns>
    Task<DeleteExportReport?> DeleteExportReport(string id, string type);
}