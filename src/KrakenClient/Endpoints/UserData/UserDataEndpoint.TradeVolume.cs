using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string TradeVolumeUrl = "TradeVolume";

    public Task<TradeVolume?> GetTradeVolume(string? pair = null, bool? feeInfo = null)
    {
        if (!string.IsNullOrEmpty(pair) || !string.IsNullOrWhiteSpace(pair))
            _httpClient.BodyParameters.Add(KrakenParameter.Pair, pair);

        if (feeInfo.HasValue) _httpClient.BodyParameters.Add(KrakenParameter.FeeInfo, feeInfo.Value.ToValueStr());

        return _httpClient.Post<TradeVolume>(KrakenConstants.PrivateBaseUrl + TradeVolumeUrl);
    }
}