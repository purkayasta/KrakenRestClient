using KrakenRestClient.Models.UserFunding;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserFunding;

internal partial class UserFundingEndpoint
{
    private const string DepositMethodUrl = "DepositMethods";

    public async Task<DepositMethodResponse?> GetDepositMethodsAsync(string asset)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);

        DepositMethodResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<DepositMethodResponse>(KrakenConstants.PrivateBaseUrl + DepositMethodUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}