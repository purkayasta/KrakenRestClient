using KrakenRestClient.Models.UserStaking;

namespace KrakenRestClient.Endpoints.UserStaking;

internal partial class UserStakingEndpoint : IUserStakingEndpoint
{
    private const string StakeAssetUrl = "Stake";

    public async Task<StakeAssetResponse?> StakeAssetAsync(string asset, string amount, string method)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));
        KrakenException.ThrowIfNullOrEmpty(amount, nameof(amount));
        KrakenException.ThrowIfNullOrEmpty(method, nameof(method));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.Amount, amount);
        _httpClient.BodyParameters.Add(KrakenParameter.Method, method);

        StakeAssetResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<StakeAssetResponse>(KrakenConstants.PrivateBaseUrl + StakeAssetUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}