namespace KrakenRestClient.Models.UserData;

public class DeleteExportReportResponse : BaseResponse<DeleteExportReport>
{
}

public class DeleteExportReport
{
    /// <summary>
    /// Whether deletion was successful
    /// </summary>
    /// <value></value>
    [JsonPropertyName("delete")]
    public bool IsDeleted { get; set; }


    /// <summary>
    /// Whether cancellation was successful
    /// </summary>
    /// <value></value>
    [JsonPropertyName("cancel")]
    public bool IsCanceled { get; set; }
}