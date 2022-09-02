namespace KrakenClient.Models.MarketData;

public abstract class SystemStatus : BaseResponse<SystemStatusResult>
{
}

public abstract class SystemStatusResult
{
    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("timestamp")] public DateTime TimeStamp { get; set; }
}