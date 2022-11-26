using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    public async Task<RequestExportReportResponse?> RequestExportReport(string report, string description,
        string format = "csv", string fields = "all", int? starttm = null, int? endtm = null)
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
            result = await _httpClient.Post<RequestExportReportResponse>(KrakenConstants.PrivateBaseUrl + "AddExport");
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<ExportReportStatusResponse?> GetExportReportStatus(string report)
    {
        KrakenException.ThrowIfNullOrEmpty(report, nameof(report));

        _httpClient.BodyParameters.Add(KrakenParameter.Report, report);

        ExportReportStatusResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<ExportReportStatusResponse>(KrakenConstants.PrivateBaseUrl + "ExportStatus");
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<Stream?> RetrieveDataExport(string id)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);

        Stream? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<Stream>(KrakenConstants.PrivateBaseUrl + "RetrieveExport");
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }

    public async Task<DeleteExportReportResponse?> DeleteExportReport(string id, string type)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));
        KrakenException.ThrowIfNullOrEmpty(type, nameof(type));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Type, type);

        DeleteExportReportResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<DeleteExportReportResponse>(KrakenConstants.PrivateBaseUrl + "RemoveExport");
        }
        catch (Exception exception) when (exception is ArgumentNullException or KrakenException)
        {
            throw;
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}