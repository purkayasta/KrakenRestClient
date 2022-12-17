using KrakenRestClient.Models.UserStaking;

namespace KrakenRestClient.Contracts;

public interface IUserStakingEndpoint
{
    /// <summary>
    /// Stake an asset from your spot wallet. This operation requires an API key with Withdraw funds permission.
    /// </summary>
    /// <param name="asset">Asset to stake (asset ID or altname)</param>
    /// <param name="amount">Amount of the asset to stake</param>
    /// <param name="method">Name of the staking option to use (refer to the Staking Assets endpoint for the correct
    /// method names for each asset)</param>
    /// <returns></returns>
    Task<StakeAssetResponse?> StakeAssetAsync(string asset, string amount, string method);

    /// <summary>
    /// Unstake an asset from your staking wallet. This operation requires an API key with Withdraw funds permission.
    /// </summary>
    /// <param name="asset">Asset to unstake (asset ID or altname). Must be a valid staking asset (e.g. XBT.M, XTZ.S, ADA.S)</param>
    /// <param name="amount">Amount of the asset to stake</param>
    /// <returns></returns>
    Task<UnStakeAssetResponse?> UnStakeAssetAsync(string asset, string amount);
}