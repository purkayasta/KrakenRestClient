namespace KrakenRestClient.Models.UserData;

public class OpenPositionsResponse : BaseResponse<IDictionary<string, OpenPosition>>
{
}

public class OpenPosition
{
    /// <summary>
    /// Order ID responsible for the position
    /// </summary>
    [JsonPropertyName("ordertxid")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Position status (open/closed)
    /// </summary>
    [JsonPropertyName("posstatus")]
    public string? PositionStatus { get; set; }

    /// <summary>
    /// Asset pair
    /// </summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>
    /// Unix timestamp of trade
    /// </summary>
    [JsonPropertyName("time")]
    public int Time { get; set; }

    /// <summary>
    /// Type of order (buy/sell)
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("ordertype")] public string? OrderType { get; set; }

    /// <summary>
    /// Total cost of order (quote currency)
    /// </summary>
    [JsonPropertyName("cost")]
    public string? Cost { get; set; }

    /// <summary>
    /// Total fee (quote currency)
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// Volume (base currency)
    /// </summary>
    [JsonPropertyName("vol")]
    public string? Volume { get; set; }

    /// <summary>
    /// Quantity closed (in base currency)
    /// </summary>
    [JsonPropertyName("vol_closed")]
    public string? VolumeClosed { get; set; }

    /// <summary>
    /// Initial margin consumed (quote currency)
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin { get; set; }

    /// <summary>
    /// Current value of remaining position (if docalcs requested)
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// Unrealised P&L of remaining position (if docalcs requested)
    /// </summary>
    [JsonPropertyName("net")]
    public string? NetProfit { get; set; }

    /// <summary>
    /// Funding cost and term of position
    /// </summary>
    [JsonPropertyName("terms")]
    public string? Terms { get; set; }

    /// <summary>
    /// Timestamp of next margin rollover fee
    /// </summary>
    [JsonPropertyName("rollovertm")]
    public string? RollOverFeeTime { get; set; }

    /// <summary>
    /// comma delimited list of add'l info
    /// </summary>
    [JsonPropertyName("misc")]
    public string? Misc { get; set; }

    /// <summary>
    /// Comma delimited list of opening order flags
    /// </summary>
    [JsonPropertyName("oflags")]
    public string? OFlags { get; set; }
}