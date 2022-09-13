namespace KrakenClient.Models.UserData;

public class DeleteExportReport : BaseResponse<DeleteExportReportResult>
{
}

public sealed class DeleteExportReportResult
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
