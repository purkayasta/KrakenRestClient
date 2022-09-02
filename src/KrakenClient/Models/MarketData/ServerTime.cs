namespace KrakenClient.Models.MarketData;

public abstract class ServerTime : BaseResponse<ServerTimeResult>
{
}

public abstract class ServerTimeResult
{
    [JsonPropertyName("unixtime")] public int UnixTime { get; set; }

    [JsonPropertyName("rfc1123")] public string? RfcTime { get; set; }
}