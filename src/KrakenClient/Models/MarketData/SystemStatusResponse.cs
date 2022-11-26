namespace KrakenClient.Models.MarketData;

public class SystemStatusResponse : BaseResponse<SystemStatus>
{
}

public abstract class SystemStatus
{
    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("timestamp")] public DateTime TimeStamp { get; set; }
}