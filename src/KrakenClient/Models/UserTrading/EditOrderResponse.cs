namespace KrakenClient.Models.UserTrading;

public class EditOrderResponse : BaseResponse<EditOrder>
{
}

public abstract class EditOrder
{
    /// <summary>
    /// Order description info
    /// </summary>
    [JsonPropertyName("descr")]
    public OrderDescription? OrderDescription { get; set; }

    /// <summary>
    /// New Transaction ID
    /// (if order was added successfully)
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Original userref if passed with the request
    /// </summary>
    [JsonPropertyName("newuserref")]
    public string? NewUserReferenceId { get; set; }

    /// <summary>
    /// Original userref if passed with the request
    /// </summary>
    [JsonPropertyName("olduserref")]
    public string? OldUserReferenceId { get; set; }

    /// <summary>
    /// Number of orders cancelled (either 0 or 1)
    /// </summary>
    [JsonPropertyName("orders_cancelled")]
    public int OrderCancelledCount { get; set; }

    /// <summary>
    /// Original transaction ID
    /// </summary>
    [JsonPropertyName("originaltxid")]
    public string? OriginalTransactionId { get; set; }

    /// <summary>
    /// Status of the order: Ok or Err
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Updated volume
    /// </summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>
    /// Updated price
    /// </summary>
    public string? Price { get; set; }

    /// <summary>
    /// Updated price2
    /// </summary>
    public string? Price2 { get; set; }

    /// <summary>
    /// Error message if unsuccessful
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }
}

public abstract class OrderDescription
{
    /// <summary>
    /// Order description
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }
}