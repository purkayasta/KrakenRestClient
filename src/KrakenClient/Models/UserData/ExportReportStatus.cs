namespace KrakenClient.Models.UserData;

public abstract class ExportReportStatus : BaseResponse<ExportReportStatusResult>
{

}

public abstract class ExportReportStatusResult
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("descr")] public string? Description { get; set; }
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("report")] public string? Report { get; set; }
    [JsonPropertyName("subtype")] public string? SubType { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [Obsolete] [JsonPropertyName("flags")] public string? Flags { get; set; }
    [JsonPropertyName("fields")] public string? Fields { get; set; }
    [JsonPropertyName("createdtm")] public string? CreatedTime { get; set; }
    [Obsolete] [JsonPropertyName("expiretm")] public string? ExpiredTime { get; set; }
    [JsonPropertyName("starttm")] public string? StartTime { get; set; }
    [JsonPropertyName("completedtm")] public string? CompletedTime { get; set; }
    [JsonPropertyName("datastarttm")] public string? DataStartTime { get; set; }
    [JsonPropertyName("dataendtm")] public string? DataEndTime { get; set; }
    [Obsolete] [JsonPropertyName("aclass")] public string? AssetClass { get; set; }
    [JsonPropertyName("asset")] public string? Asset { get; set; }
}