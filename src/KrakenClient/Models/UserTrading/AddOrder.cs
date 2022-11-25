namespace KrakenClient.Models.UserTrading;

public class AddOrder : BaseResponse<IDictionary<string, string>>
{
}

public class AddOrderResult
{
    /// <summary>
    /// Order description info
    /// </summary>
    [JsonPropertyName("descr")]
    public AddOrderDescription? Description { get; set; }

    /// <summary>
    /// Transaction IDs for order
    /// </summary>
    [JsonPropertyName("txid")]
    public string[]? TransactionIds { get; set; }
}

public class AddOrderDescription
{
    /// <summary>
    /// Order description
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Conditional close order description, if applicable
    /// </summary>
    [JsonPropertyName("close")]
    public string? Close { get; set; }
}