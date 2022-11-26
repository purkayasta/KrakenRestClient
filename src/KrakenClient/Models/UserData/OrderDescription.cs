namespace KrakenClient.Models.UserData;

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
    [JsonPropertyName("leverage")] public string? Leverage { get; set; }

    /// <summary>
    /// Order description
    /// </summary>
    [JsonPropertyName("order")] public string? OrderDescriptionInText { get; set; }

    /// <summary>
    /// Conditional close order description (if conditional close set)
    /// </summary>
    [JsonPropertyName("close")] public string? Close { get; set; }
}