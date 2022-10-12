using KrakenClient.Contracts;
using KrakenClient.Models.UserData;
using KrakenClient.Utilities;

namespace KrakenClient.Endpoints.UserData;

internal sealed partial class UserDataEndpoint : IUserDataEndpoint
{
    private const string OpenPositionsUrl = "OpenPositions";

    public Task<OpenPositions?> GetOpenPositions(string transactionIds, bool docalcs = false,
        string consolidation = "market")
    {
        KrakenException.ThrowIfNullOrEmpty(transactionIds, nameof(transactionIds));

        _httpClient.BodyParameters.Add(KrakenParameter.TransactionId, transactionIds);
        _httpClient.BodyParameters.Add(KrakenParameter.Docalcs, docalcs.ToValueStr());
        _httpClient.BodyParameters.Add(KrakenParameter.Consolidation, consolidation);

        return _httpClient.Post<OpenPositions>(KrakenConstants.PrivateBaseUrl + OpenPositionsUrl);
    }
}