

using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string RequestExportUrl = "AddExport";
    private const string ExportStatusUrl = "ExportStatus";
    private const string RetrieveReportStatusUrl = "RetrieveExport";
    private const string RemoveExportUrl = "RemoveExport";

    public async Task<RequestExportReportResponse?> RequestExportReportAsync(
        string report,
        string description,
        string format = "csv",
        string fields = "all",
        int? starttm = null,
        int? endtm = null)
    {
        KrakenException.ThrowIfNullOrEmpty(report, nameof(report));
        KrakenException.ThrowIfNullOrEmpty(description, nameof(description));
        KrakenException.ThrowIfNullOrEmpty(format, nameof(format));
        KrakenException.ThrowIfNullOrEmpty(fields, nameof(fields));

        _httpClient.BodyParameters.Add(KrakenParameter.Report, report);
        _httpClient.BodyParameters.Add(KrakenParameter.Description, description);
        _httpClient.BodyParameters.Add(KrakenParameter.Format, format);
        _httpClient.BodyParameters.Add(KrakenParameter.Fields, fields);

        if (starttm.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.Start, starttm.Value.ToString());
        if (endtm.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.End, endtm.Value.ToString());

        RequestExportReportResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient
                .Post<RequestExportReportResponse>(KrakenConstants.PrivateBaseUrl + RequestExportUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<ExportReportStatusResponse?> GetExportReportStatusAsync(string report)
    {
        KrakenException.ThrowIfNullOrEmpty(report, nameof(report));

        _httpClient.BodyParameters.Add(KrakenParameter.Report, report);

        ExportReportStatusResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient
                .Post<ExportReportStatusResponse>(KrakenConstants.PrivateBaseUrl + ExportStatusUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<Stream?> RetrieveDataExportAsync(string id)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);

        Stream? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<Stream>(KrakenConstants.PrivateBaseUrl + RetrieveReportStatusUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<DeleteExportReportResponse?> DeleteExportReportAsync(string id, string type)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));
        KrakenException.ThrowIfNullOrEmpty(type, nameof(type));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Type, type);

        DeleteExportReportResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient
                .Post<DeleteExportReportResponse>(KrakenConstants.PrivateBaseUrl + RemoveExportUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}