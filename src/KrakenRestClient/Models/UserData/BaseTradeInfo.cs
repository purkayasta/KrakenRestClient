namespace KrakenRestClient.Models.UserData;

public abstract class BaseTradeInfo
{
    /// <summary>
    /// Order responsible for execution of trade
    /// </summary>
    [JsonPropertyName("ordertxid")]
    public string? OrderTradeId { get; set; }

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
    /// Average price order was executed at (quote currency)
    /// </summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

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
    /// Initial margin (quote currency)
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin { get; set; }

    /// <summary>
    /// Comma delimited list of miscellaneous info.
    /// </summary>
    [JsonPropertyName("misc")]
    public string? MiscellaneousInfo { get; set; }

    /// <summary>
    /// Position status (open/closed)
    /// </summary>
    [JsonPropertyName("posstatus")]
    public string? PositionStatus { get; set; }

    /// <summary>
    /// Average price of closed portion of position (quote currency)
    /// </summary>
    [JsonPropertyName("cprice")]
    public string? ClosedAveragePrice { get; set; }

    /// <summary>
    /// Total cost of closed portion of position (quote currency)
    /// </summary>
    [JsonPropertyName("ccost")]
    public string? ClosedTotalCost { get; set; }

    /// <summary>
    /// Total fee of closed portion of position (quote currency)
    /// </summary>
    [JsonPropertyName("cfee")]
    public string? ClosedTotalFee { get; set; }


    [JsonPropertyName("cvol")] public string? ClosedTotalVolume { get; set; }

    /// <summary>
    /// Total margin freed in closed portion of position (quote currency)
    /// </summary>
    [JsonPropertyName("cmargin")]
    public string? ClosedTotalMargin { get; set; }

    /// <summary>
    /// Net profit/loss of closed portion of position (quote currency, quote currency scale)
    /// </summary>
    [JsonPropertyName("net")]
    public string? NetProfit { get; set; }

    /// <summary>
    /// List of closing trades for position (if available)
    /// </summary>
    [JsonPropertyName("trades")] public string[]? Trades { get; set; }
}