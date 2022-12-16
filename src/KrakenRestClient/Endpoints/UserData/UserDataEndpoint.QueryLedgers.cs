using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string QueryLedgersUrl = "QueryLedgers";

    public async Task<LedgerResponse?> QueryLedgersAsync(string id, bool trades = false)
    {
        KrakenException.ThrowIfNullOrEmpty(id, nameof(id));

        _httpClient.BodyParameters.Add(KrakenParameter.Id, id);
        _httpClient.BodyParameters.Add(KrakenParameter.Trade, trades.ToValueStr());

        LedgerResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<LedgerResponse>(KrakenConstants.PrivateBaseUrl + QueryLedgersUrl);
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