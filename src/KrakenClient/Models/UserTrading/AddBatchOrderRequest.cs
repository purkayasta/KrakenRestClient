namespace KrakenClient.Models.UserTrading;

public class AddBatchOrderRequest
{
    /// <summary>
    /// Array of objects
    /// </summary>
    public required BaseAddOrderRequest[] AddOrderRequest { get; set; }

    /// <summary>
    /// Asset pair id or altname
    /// </summary>
    public required string Pair { get; set; }

    /// <summary>
    /// RFC3339 timestamp (e.g. 2021-04-01T00:18:45Z) after which the matching engine should reject the new order
    /// request, in presence of latency or order queueing: min now() + 2 seconds, max now() + 60 seconds.
    /// </summary>
    public string? DeadLine { get; set; }

    /// <summary>
    /// Validate inputs only. Do not submit order.
    /// </summary>
    public bool Validate { get; set; } = false;
}