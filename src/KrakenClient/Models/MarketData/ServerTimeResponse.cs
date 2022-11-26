namespace KrakenClient.Models.MarketData;

public class ServerTimeResponse : BaseResponse<ServerTime>
{
}

public abstract class ServerTime
{
    [JsonPropertyName("unixtime")] public int UnixTime { get; set; }

    [JsonPropertyName("rfc1123")] public string? RfcTime { get; set; }
}