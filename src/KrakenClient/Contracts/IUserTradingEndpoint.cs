using KrakenClient.Models.UserTrading;

namespace KrakenClient.Contracts;

public interface IUserTradingEndpoint
{
    /// <summary>
    /// Place a new order.
    /// Note: See the AssetPairs endpoint for details on the available trading pairs, their price
    /// and quantity precisions, order minimums, available leverage, etc
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AddOrderResponse?> AddOrderAsync(AddOrderRequest? request);

    /// <summary>
    /// Send an array of orders (max: 15). Any orders rejected due to order validations, will be
    /// dropped and the rest of the batch is processed. All orders in batch should be limited to a single pair.
    /// The order of returned txid's in the response array is the same as the order of the order list sent in request.
    /// </summary>
    /// <param name="requests">AddBatchOrderRequest</param>
    /// <returns></returns>
    Task<AddBatchOrderResponse?> AddOrderBatchAsync(AddBatchOrderRequest? requests);

    /// <summary>
    /// Edit volume and price on open orders. Uneditable orders include margin orders, triggered
    /// stop/profit orders, orders with conditional close terms attached, those already cancelled or
    /// filled, and those where the executed volume is greater than the newly supplied volume. post-only
    /// flag is not retained from original order after successful edit. post-only needs to be explicitly set on
    /// edit request.
    /// </summary>
    /// <param name="request">EditOrderRequest</param>
    /// <returns></returns>
    Task<EditOrderResponse?> EditOrderAsync(EditOrderRequest? request);

    /// <summary>
    /// Cancel a particular open order (or set of open orders) by txid or userref
    /// </summary>
    /// <param name="transactionId">Open order transaction ID (txid) or user reference (userref)</param>
    /// <returns></returns>
    Task<CancelOrderResponse?> CancelOrderAsync(string transactionId);

    /// <summary>
    /// Cancel all open orders
    /// </summary>
    /// <returns></returns>
    Task<CancelAllOrderResponse?> CancelAllOrderAsync();

    /// <summary>
    /// CancelAllOrdersAfter provides a "Dead Man's Switch" mechanism to protect the client from network malfunction,
    /// extreme latency or unexpected matching engine downtime. The client can send a request with a timeout (in seconds),
    /// that will start a countdown timer which will cancel all client orders when the timer expires. The client has to
    /// keep sending new requests to push back the trigger time, or deactivate the mechanism by specifying a timeout of 0.
    /// If the timer expires, all orders are cancelled and then the timer remains disabled until the client provides a new (non-zero)
    /// timeout.The recommended use is to make a call every 15 to 30 seconds, providing a timeout of 60 seconds. This
    /// allows the client to keep the orders in place in case of a brief disconnection or transient delay, while keeping
    /// them safe in case of a network breakdown. It is also recommended to disable the timer ahead of regularly scheduled
    /// trading engine maintenance (if the timer is enabled, all orders will be cancelled when the trading engine comes back
    /// from downtime - planned or otherwise).
    /// </summary>
    /// <param name="timeOut">Duration (in seconds) to set/extend the timer by</param>
    /// <returns></returns>
    Task<CancelAllOrderAfterXResponse?> CancelAllOrderAfterXAsync(int timeOut);

    /// <summary>
    /// Cancel multiple open orders by txid or userref
    /// </summary>
    /// <param name="transactionIds">Open orders transaction ID (txid) or user reference (userref)</param>
    /// <returns></returns>
    Task<CancelOrderBatchResponse?> CancelOrderBatchAsync(string[] transactionIds);
}