using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string LedgerInfoUrl = "Ledgers";

    public Task<LedgerInfo?> GetLedgerInfo(string asset = "all", string aclass = "currency", string type = "all",
        int? start = null, int? end = null, int? offset = null)
    {
        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.AssetClass, aclass);
        _httpClient.BodyParameters.Add(KrakenParameter.Type, type);

        if (start.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.Start, start.Value.ToString());
        if (end.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.End, end.Value.ToString());
        if (offset.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.OffSet, offset.Value.ToString());

        return _httpClient.Post<LedgerInfo>(BaseUrl + LedgerInfoUrl);
    }
}