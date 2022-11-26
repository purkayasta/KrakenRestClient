namespace KrakenClient.Models.UserTrading;

public class AddBatchOrder : BaseResponse<AddBatchOrderResponse>
{
}

public abstract class AddBatchOrderResponse
{
    [JsonPropertyName("orders")] public AddBatchOrderResult[]? Orders { get; set; }
}

public abstract class AddBatchOrderResult
{
    /// <summary>
    /// Order description info
    /// </summary>
    [JsonPropertyName("descr")] public string? Description { get; set; }

    /// <summary>
    /// Error description from individual order processing
    /// </summary>
    [JsonPropertyName("error")] public string? Error { get; set; }

    /// <summary>
    /// Transaction ID for order
    /// </summary>
    [JsonPropertyName("txid")] public string? TransactionId { get; set; }
}