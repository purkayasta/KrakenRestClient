using KrakenRestClient.Models.UserStaking;

namespace KrakenRestClient.Endpoints.UserStaking;

internal partial class UserStakingEndpoint : IUserStakingEndpoint
{
    private const string StakeableAssetsUrl = "Staking/Assets";
    private const string PendingStakeTransactionUrl = "Staking/Pending";
    private const string ListOfStackingTransactionUrl = "Staking/Transactions";

    public async Task<StakeableAssetsResponse?> GetListOfStakeableAssetsAsync()
    {
        StakeableAssetsResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient
                .Post<StakeableAssetsResponse>(KrakenConstants.PrivateBaseUrl + StakeableAssetsUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<PendingStakingTransactionResponse?> GetPendingStackingTransactionAsync()
    {
        PendingStakingTransactionResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient
                .Post<PendingStakingTransactionResponse>(KrakenConstants.PrivateBaseUrl + PendingStakeTransactionUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<StakingTransactionResponse?> GetListOfStakingTransactionAsync()
    {
        StakingTransactionResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient
                .Post<StakingTransactionResponse>(KrakenConstants.PrivateBaseUrl + ListOfStackingTransactionUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}