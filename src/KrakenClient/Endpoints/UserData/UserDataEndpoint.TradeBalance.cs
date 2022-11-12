using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string TradeBalanceUrl = "TradeBalance";

    public async Task<TradeBalance?> GetTradeBalance(string asset = "ZUSD")
    {
        ArgumentNullException.ThrowIfNull(asset, nameof(asset));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);

        TradeBalance? result;
        
        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<TradeBalance>(KrakenConstants.PrivateBaseUrl + TradeBalanceUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}