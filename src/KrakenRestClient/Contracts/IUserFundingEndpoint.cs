using KrakenRestClient.Models.UserFunding;

namespace KrakenRestClient.Contracts;

public interface IUserFundingEndpoint
{
    /// <summary>
    /// Retrieve methods available for depositing a particular asset.
    /// </summary>
    /// <param name="asset">Asset being deposited</param>
    /// <returns></returns>
    Task<DepositMethodResponse?> GetDepositMethodsAsync(string asset);

    /// <summary>
    /// Retrieve (or generate a new) deposit addresses for a particular asset and method.
    /// </summary>
    /// <param name="asset">Asset being deposited</param>
    /// <param name="method">Name of the deposit method</param>
    /// <param name="newAddress">Whether or not to generate a new address. Default: false</param>
    /// <returns></returns>
    Task<DepositAddressResponse?> GetDepositAddressAsync(string asset, string method, bool newAddress = false);

    /// <summary>
    /// Retrieve information about recent deposits made.
    /// </summary>
    /// <param name="asset">Asset being deposited</param>
    /// <param name="method">Name of the deposit method</param>
    /// <returns></returns>
    Task<RecentDepositsStatusResponse?> GetRecentDepositsStatusAsync(string asset, string? method = null);
}