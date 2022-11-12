using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string OpenPositionsUrl = "OpenPositions";

    public async Task<OpenPositions?> GetOpenPositions(string transactionIds, bool docalcs = false,
        string consolidation = "market")
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Docalcs, docalcs.ToValueStr());
        _httpClient.BodyParameters.Add(KrakenParameter.Consolidation, consolidation);

        OpenPositions? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<OpenPositions>(KrakenConstants.PrivateBaseUrl + OpenPositionsUrl);
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