namespace KrakenClient.Models.UserData;

public class RequestExportReport : BaseResponse<RequestExportReportResult>
{
}

public sealed class RequestExportReportResult
{
    [JsonPropertyName("id")] public string? Id { get; set; }
}
