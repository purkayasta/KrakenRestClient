namespace KrakenClient.Models.UserData;

public abstract class OpenOrders : BaseResponse<OpenOrderResult>
{
}

public abstract class OpenOrderResult
{
    [JsonPropertyName("open")] public IDictionary<string, OpenOrderTransactionResult>? Open { get; set; }
}

public abstract class OpenOrderTransactionResult
{
    /// <summary>
    /// Referral order transaction ID that created this order
    /// </summary>
    [JsonPropertyName("refid")] public string? ReferalTransactionId { get; set; }

    /// <summary>
    /// User reference id
    /// </summary>
    [JsonPropertyName("userref")] public string? UserReferenceId { get; set; }

    /// <summary>
    /// Status of order
    /// Enum: "pending" "open" "closed" "canceled" "expired"
    /// </summary>
    [JsonPropertyName("status")] public string? Status { get; set; }

    /// <summary>
    /// Unix timestamp of when order was placed
    /// </summary>
    [JsonPropertyName("opentm")] public int OpenAtTime { get; set; }

    /// <summary>
    /// Unix timestamp of order start time (or 0 if not set)
    /// </summary>
    [JsonPropertyName("starttm")] public int StartAtTime { get; set; }

    /// <summary>
    /// Unix timestamp of order end time (or 0 if not set)
    /// </summary>
    [JsonPropertyName("expiretm")] public int ExpireAtTime { get; set; }

    /// <summary>
    /// Order description info
    /// </summary>
    [JsonPropertyName("descr")] public OrderDescription? OrderDescription { get; set; }

    /// <summary>
    /// Volume of order (base currency)
    /// </summary>
    [JsonPropertyName("vol")] public string? Volume { get; set; }

    /// <summary>
    /// Volume executed (base currency)
    /// </summary>
    [JsonPropertyName("vol_exec")] public string? VolumeExecuted { get; set; }

    /// <summary>
    /// Total cost (quote currency unless)
    /// </summary>
    [JsonPropertyName("cost")] public string? Cost { get; set; }

    /// <summary>
    /// Total fee (quote currency)
    /// </summary>
    [JsonPropertyName("fee")] public string? Fee { get; set; }

    /// <summary>
    /// Average price (quote currency)
    /// </summary>
    [JsonPropertyName("price")] public string? Price { get; set; }

    /// <summary>
    /// Stop price (quote currency)
    /// </summary>
    [JsonPropertyName("stopprice")] public string? StopPrice { get; set; }

    /// <summary>
    /// Triggered limit price (quote currency, when limit based order type triggered)
    /// </summary>
    [JsonPropertyName("limitprice")] public string? LimitPrice { get; set; }

    /// <summary>
    /// Price signal used to trigger "stop-loss" "take-profit" "stop-loss-limit" "take-profit-limit" orders.
    /// </summary>
    [JsonPropertyName("trigger")] public string? Trigger { get; set; } = "last";

    /// <summary>
    /// Comma delimited list of miscellaneous info
    /// </summary>
    [JsonPropertyName("misc")] public string? Misc { get; set; }

    /// <summary>
    /// Comma delimited list of order flags
    /// </summary>
    [JsonPropertyName("oflags")] public string? Oflags { get; set; }

    /// <summary>
    /// List of trade IDs related to order (if trades info requested and data available)
    /// </summary>
    [JsonPropertyName("trades")] public string[]? Trades { get; set; }
}

public abstract class OrderDescription
{
    /// <summary>
    /// Asset pair
    /// </summary>
    [JsonPropertyName("pair")] public string? Pair { get; set; }

    /// <summary>
    /// Type of order (buy/sell)
    /// </summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>
    /// Enum: "market" "limit" "stop-loss" "take-profit" "stop-loss-limit" "take-profit-limit" "settle-position" 
    /// Order type
    /// </summary>
    [JsonPropertyName("ordertype")] public string? OrderType { get; set; }

    /// <summary>
    /// primary price
    /// </summary>
    [JsonPropertyName("price")] public string? Price { get; set; }

    /// <summary>
    /// Secondary price
    /// </summary>
    [JsonPropertyName("price2")] public string? Price2 { get; set; }

    /// <summary>
    /// Amount of leverage
    /// </summary>
    [JsonPropertyName("leverage")] public string? Keverage { get; set; }

    /// <summary>
    /// Order description
    /// </summary>
    [JsonPropertyName("order")] public string? OrderDescriptionInText { get; set; }

    /// <summary>
    /// Conditional close order description (if conditional close set)
    /// </summary>
    [JsonPropertyName("close")] public string? Close { get; set; }
}