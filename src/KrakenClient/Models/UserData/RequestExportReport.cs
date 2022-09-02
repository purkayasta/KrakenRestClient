namespace KrakenClient.Models.UserData;

public abstract class RequestExportReport : BaseResponse<RequestExportReportResult>
{
}

public abstract class RequestExportReportResult
{
    [JsonPropertyName("id")] public string? Id { get; set; }
}
