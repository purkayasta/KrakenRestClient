namespace KrakenRestClient.Models.UserTrading;

public class AddOrderResponse : BaseResponse<AddOrder>
{
}

public abstract class AddOrder
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

public abstract class AddOrderDescription
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