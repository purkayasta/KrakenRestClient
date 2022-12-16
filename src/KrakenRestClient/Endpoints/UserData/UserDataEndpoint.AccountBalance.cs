using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string UserDataUrl = "Balance";

    public async Task<AccountBalanceResponse?> GetAccountBalanceAsync()
    {
        AccountBalanceResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<AccountBalanceResponse>(KrakenConstants.PrivateBaseUrl + UserDataUrl);
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