namespace KrakenRestClient.Models.UserData;

public class ClosedOrderResponse : BaseResponse<CloseOrder>
{
}

public abstract class CloseOrder
{
    [JsonPropertyName("closed")] public IDictionary<string, ClosedOrders>? Closed { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}

public abstract class ClosedOrders : BaseOrder
{
    /// <summary>
    /// Unix timestamp of when order was closed
    /// </summary>
    [JsonPropertyName("closetm")]
    public int ClosedTime { get; set; }

    /// <summary>
    /// Additional info on status (if any)
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}