namespace KrakenClient.Models.UserData;

public class ClosedOrders : BaseResponse<CloseOrderResult>
{

}

public sealed class CloseOrderResult
{
    [JsonPropertyName("closed")] public IDictionary<string, ClosedOrderResultDetail>? Closed { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}

public sealed class ClosedOrderResultDetail : BaseOrder
{
    /// <summary>
    /// Unix timestamp of when order was closed
    /// </summary>
    [JsonPropertyName("closetm")] public int ClosedTime { get; set; }

    /// <summary>
    /// Additional info on status (if any)
    /// </summary>
    [JsonPropertyName("reason")] public string? Reason { get; set; }
}