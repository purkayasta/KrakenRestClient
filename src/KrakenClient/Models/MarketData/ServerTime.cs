namespace KrakenClient.Models.MarketData;

public class ServerTime : BaseResponse<ServerTimeResult>
{
}

public sealed class ServerTimeResult
{
    [JsonPropertyName("unixtime")] public int UnixTime { get; set; }

    [JsonPropertyName("rfc1123")] public string? RfcTime { get; set; }
}