﻿namespace KrakenClient.Models.UserData;

public class RequestExportReportResponse : BaseResponse<RequestExportReport>
{
}

public abstract class RequestExportReport
{
    [JsonPropertyName("id")] public string? Id { get; set; }
}
