using KrakenRestClient.Models.UserFunding;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserFunding;

internal partial class UserFundingEndpoint
{
    private const string WithdrawalInfoUrl = "WithdrawInfo";

    public async Task<WithdrawalInformationResponse?> GetWithdrawalInformationAsync(string asset, string key,
        string amount)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));
        KrakenException.ThrowIfNullOrEmpty(key, nameof(key));
        KrakenException.ThrowIfNullOrEmpty(amount, nameof(amount));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.Key, key);
        _httpClient.BodyParameters.Add(KrakenParameter.Amount, amount);

        WithdrawalInformationResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient
                .Post<WithdrawalInformationResponse>(KrakenConstants.PrivateBaseUrl + WithdrawalInfoUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}