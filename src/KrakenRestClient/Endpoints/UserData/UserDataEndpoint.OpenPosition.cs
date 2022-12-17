using KrakenRestClient.Models.UserData;

namespace KrakenRestClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint
{
    private const string OpenPositionsUrl = "OpenPositions";

    public async Task<OpenPositionsResponse?> GetOpenPositionsAsync(
        string transactionIds, 
        bool docalcs = false,
        string consolidation = "market")
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Docalcs, docalcs.ToValueStr());
        _httpClient.BodyParameters.Add(KrakenParameter.Consolidation, consolidation);

        OpenPositionsResponse? result;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            result = await _httpClient.Post<OpenPositionsResponse>(KrakenConstants.PrivateBaseUrl + OpenPositionsUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return result;
    }
}