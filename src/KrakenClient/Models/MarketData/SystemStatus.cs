namespace KrakenClient.Models.MarketData;

public class SystemStatus : BaseResponse<SystemStatusResult>
{
}

public sealed class SystemStatusResult
{
    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("timestamp")] public DateTime TimeStamp { get; set; }
}