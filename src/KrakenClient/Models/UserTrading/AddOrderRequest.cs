﻿namespace KrakenClient.Models.UserTrading;

public class AddOrderRequest
{
    /// <summary>
    /// integer (int32)
    /// userref is an optional user-specified integer id that can be associated with any number of orders.
    /// Many clients choose a userref corresponding to a unique integer id generated by their systems
    /// (e.g. a timestamp). However, because we don't enforce uniqueness on our side, it can also be used to easily
    /// group orders by pair, side, strategy, etc. This allows clients to more readily cancel or query information
    /// about orders in a particular group, with fewer API calls by using userref instead of our txid, where supported.
    /// </summary>
    public int? UserReferenceId { get; set; }

    /// <summary>
    /// string (ordertype)
    /// Enum: "market" "limit" "stop-loss" "take-profit" "stop-loss-limit" "take-profit-limit" "settle-position"
    /// </summary>
    public required string OrderType { get; set; }

    /// <summary>
    /// Enum: "buy" "sell"
    /// Order direction (buy/sell)
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// Order quantity in terms of the base asset
    /// </summary>
    public required decimal Volume { get; set; }

    /// <summary>
    /// Order quantity in terms of the base asset. This is used to create an iceberg order, with display_volume as
    /// visible quantity, hiding rest of the order. This can only be used with limit order type.
    /// </summary>
    public string? DisplayVolume { get; set; }

    /// <summary>
    /// Asset pair id or altname
    /// </summary>
    public required string Pair { get; set; }

    /// <summary>
    /// Limit price for limit orders
    /// Trigger price for stop-loss, stop-loss-limit, take-profit and take-profit-limit orders
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Limit price for stop-loss-limit and take-profit-limit orders
    /// Note: Either price or price2 can be preceded by +, -, or # to specify the order price as an offset relative
    /// to the last traded price. + adds the amount to, and - subtracts the amount from the last traded price. # will
    /// either add or subtract the amount to the last traded price, depending on the direction and order type used.
    /// Relative prices can be suffixed with a % to signify the relative amount as a percentage
    /// </summary>
    public decimal? Price2 { get; set; }

    /// <summary>
    /// Default: "last"
    /// Enum: "index" "last"
    /// Price signal used to trigger stop-loss, stop-loss-limit, take-profit and take-profit-limit orders
    /// </summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// "Amount of leverage desired (default: none)"
    /// </summary>
    public string? Leverage { get; set; }

    /// <summary>
    /// (string) stptype
    /// Default: "cancel-newest"
    /// Enum: "cancel-newest" "cancel-oldest" "cancel-both"
    /// Self trade prevention behavior definition:
    /// </summary>
    public string? SelfTradePreventionType { get; set; }

    /// <summary>
    /// string (oflags)
    /// Comma delimited list of order flags.
    /// - post post-only order (available when ordertype = limit)
    /// - fcib prefer fee in base currency (default if selling)
    /// - fciq prefer fee in quote currency (default if buying, mutually exclusive with fcib)
    /// - nompp disable market price protection for market orders
    /// - viqc order volume expressed in quote currency. This is supported only for market orders.
    /// </summary>
    public string? OrderFlags { get; set; }

    /// <summary>
    /// Default: "GTC"
    /// Enum: "GTC" "IOC" "GTD"
    /// Time-in-force of the order to specify how long it should remain in the order book before being cancelled.
    /// GTC (Good-'til-cancelled) is default if the parameter is omitted. IOC (immediate-or-cancel) will immediately
    /// execute the amount possible and cancel any remaining balance rather than resting in the book.
    /// GTD (good-'til-date), if specified, must coincide with a desired expiretm.
    /// </summary>
    public string? TimeInForce { get; set; }

    /// <summary>
    /// (string) starttm
    /// Scheduled start time, can be specified as an absolute timestamp or as a number of seconds in the future:
    /// - 0 now (default)
    /// - +n schedule start time seconds from now
    /// - n = unix timestamp of start time
    /// </summary>
    public string? StartTime { get; set; }

    /// <summary>
    /// (string) expiretm
    /// Expiration time
    /// - 0 no expiration (default)
    /// - +n = expire seconds from now, minimum 5 seconds
    /// - n = unix timestamp of expiration time
    /// </summary>
    public string? ExpireTime { get; set; }

    /// <summary>
    /// Enum: "limit" "stop-loss" "take-profit" "stop-loss-limit" "take-profit-limit"
    /// close[ordertype]
    /// </summary>
    public string? ConditionalCloseOrderType { get; set; }

    /// <summary>
    /// Conditional close order price
    /// </summary>
    public decimal? ConditionalCloseOrderPrice { get; set; }

    /// <summary>
    /// Conditional close order price2
    /// </summary>
    public decimal? ConditionalCloseOrderPrice2 { get; set; }

    /// <summary>
    /// RFC3339 timestamp (e.g. 2021-04-01T00:18:45Z) after which the matching engine should reject the new order
    /// request, in presence of latency or order queueing: min now() + 2 seconds, max now() + 60 seconds.
    /// </summary>
    public string? DeadLine { get; set; }

    /// <summary>
    /// Validate inputs only. Do not submit order.
    /// </summary>
    public bool Validate { get; set; } = false;
}