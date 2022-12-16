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
}