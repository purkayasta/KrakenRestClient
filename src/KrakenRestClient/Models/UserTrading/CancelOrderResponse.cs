namespace KrakenRestClient.Models.UserTrading;

public class CancelOrderResponse : BaseResponse<CancelOrder>
{
}

public class CancelAllOrderResponse : BaseResponse<BaseCancelOrder>
{
}

public class CancelAllOrderAfterXResponse : BaseResponse<CancelAllOrderAfterX>
{
}

public class CancelOrderBatchResponse : BaseResponse<BaseCancelOrder>
{
}

public class CancelAllOrderAfterX
{
    /// <summary>
    /// Timestamp (RFC3339 format) at which the request was received
    /// </summary>
    [JsonPropertyName("currentTime")]
    public string? CurrentTime { get; set; }

    /// <summary>
    /// Timestamp (RFC3339 format) after which all orders will be cancelled, unless the timer is extended or disabled
    /// </summary>
    [JsonPropertyName("triggerTime")]
    public string? TriggerTime { get; set; }
}

public class BaseCancelOrder
{
    /// <summary>
    /// Number of orders cancelled.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class CancelOrder : BaseCancelOrder
{
    /// <summary>
    /// if set, order(s) is/are pending cancellation
    /// </summary>
    [JsonPropertyName("pending")]
    public bool Pending { get; set; }
}