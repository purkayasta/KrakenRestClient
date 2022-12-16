using KrakenRestClient.Models.UserFunding;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserFunding;

internal partial class UserFundingEndpoint
{
    private const string WithdrawalInfoUrl = "WithdrawInfo";
    private const string WithdrawFundUrl = "Withdraw";
    private const string WithdrawalStatusUrl = "WithdrawStatus";

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

    public async Task<WithdrawFundsResponse?> WithdrawFundsAsync(string asset, string key, string amount)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));
        KrakenException.ThrowIfNullOrEmpty(key, nameof(key));
        KrakenException.ThrowIfNullOrEmpty(amount, nameof(amount));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.Key, key);
        _httpClient.BodyParameters.Add(KrakenParameter.Amount, amount);

        WithdrawFundsResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<WithdrawFundsResponse>(KrakenConstants.PrivateBaseUrl + WithdrawFundUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }

    public async Task<RecentWithdrawalsStatusResponse?> GetRecentWithdrawalStatusAsync(string asset,
        string? method = null)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        if (method is not null) _httpClient.BodyParameters.Add(KrakenParameter.Method, method);

        RecentWithdrawalsStatusResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient
                .Post<RecentWithdrawalsStatusResponse>(KrakenConstants.PrivateBaseUrl + WithdrawalStatusUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}