using KrakenRestClient.Contracts;
using KrakenRestClient.Models.UserData;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string TradeBalanceUrl = "TradeBalance";

    public async Task<TradeBalanceResponse?> GetTradeBalanceAsync(string asset = "ZUSD")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);

        TradeBalanceResponse? result;
        
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<TradeBalanceResponse>(KrakenConstants.PrivateBaseUrl + TradeBalanceUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}