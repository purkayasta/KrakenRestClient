namespace KrakenRestClient.Models.UserData;

public class RequestExportReportResponse : BaseResponse<RequestExportReport>
{
}

public class RequestExportReport
{
    [JsonPropertyName("id")] public string? Id { get; set; }
}
