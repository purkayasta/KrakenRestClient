using KrakenRestClient.Models.UserFunding;

namespace KrakenRestClient.Endpoints.UserFunding;

internal partial class UserFundingEndpoint : BaseEndpoint, IUserFundingEndpoint
{
    private const string WalletTransferUrl = "WalletTransfer";

    public async Task<WalletTransferResponse?> RequestWalletTransferAsync(string asset, string from, string to,
        string amount)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));
        KrakenException.ThrowIfNullOrEmpty(from, nameof(from));
        KrakenException.ThrowIfNullOrEmpty(to, nameof(to));
        KrakenException.ThrowIfNullOrEmpty(amount, nameof(amount));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.From, from);
        _httpClient.BodyParameters.Add(KrakenParameter.To, to);
        _httpClient.BodyParameters.Add(KrakenParameter.Amount, amount);

        WalletTransferResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<WalletTransferResponse>(
                KrakenConstants.PrivateBaseUrl + WalletTransferUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}