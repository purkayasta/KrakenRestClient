namespace KrakenClient.Models.UserTrading;

public class AddBatchOrderResponse : BaseResponse<AddBatchOrder>
{
}

public abstract class AddBatchOrder
{
    [JsonPropertyName("orders")] public AddBatchOrders[]? Orders { get; set; }
}

public abstract class AddBatchOrders
{
    /// <summary>
    /// Order description info
    /// </summary>
    [JsonPropertyName("descr")]
    public string? Description { get; set; }

    /// <summary>
    /// Error description from individual order processing
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Transaction ID for order
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TransactionId { get; set; }
}