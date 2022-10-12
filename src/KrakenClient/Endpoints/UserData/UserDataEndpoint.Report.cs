using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    public Task<RequestExportReport?> RequestExportReport(string report, string description, string format = "csv", string fields = "all", int? starttm = null, int? endtm = null)
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


        return _httpClient.Post<RequestExportReport>(KrakenConstants.PrivateBaseUrl + "AddExport");
    }

    public Task<ExportReportStatus?> GetExportReportStatus(string report)
    {
        KrakenException.ThrowIfNullOrEmpty(report, nameof(report));

        _httpClient.BodyParameters.Add(KrakenParameter.Report, report);

        return _httpClient.Post<ExportReportStatus>(KrakenConstants.PrivateBaseUrl + "ExportStatus");
    }

    public Task<Stream?> RetrieveDataExport(string id)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);

        return _httpClient.Post<Stream>(KrakenConstants.PrivateBaseUrl + "RetrieveExport");
    }

    public Task<DeleteExportReport?> DeleteExportReport(string id, string type)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));
        KrakenException.ThrowIfNullOrEmpty(type, nameof(type));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Type, type);

        return _httpClient.Post<DeleteExportReport>(KrakenConstants.PrivateBaseUrl + "RemoveExport");
    }
}
