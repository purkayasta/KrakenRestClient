using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryLedgersUrl = "QueryLedgers";

    public async Task<Ledgers?> QueryLedgers(string id, bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        Ledgers? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<Ledgers>(KrakenConstants.PrivateBaseUrl + QueryLedgersUrl);
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