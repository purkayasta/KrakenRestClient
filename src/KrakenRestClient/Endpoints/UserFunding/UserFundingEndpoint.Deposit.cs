using KrakenRestClient.Models.UserFunding;
using KrakenRestClient.Utilities;

namespace KrakenRestClient.Endpoints.UserFunding;

internal partial class UserFundingEndpoint
{
    private const string DepositMethodUrl = "DepositMethods";
    private const string DepositAddressUrl = "DepositAddresses";

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

    public async Task<DepositAddressResponse?> GetDepositAddressAsync(string asset, string method,
        bool newAddress = false)
    {
        KrakenException.ThrowIfNullOrEmpty(asset, nameof(asset));
        KrakenException.ThrowIfNullOrEmpty(method, nameof(method));

        _httpClient.BodyParameters.Add(KrakenParameter.Asset, asset);
        _httpClient.BodyParameters.Add(KrakenParameter.Method, method);
        _httpClient.BodyParameters.Add(KrakenParameter.NewAddress, newAddress.ToValueStr());

        DepositAddressResponse? response = null;

        try
        {
            await CustomSemaphore.WaitAsync(KrakenConstants.ThreadTimeout);
            response = await _httpClient.Post<DepositAddressResponse>(
                KrakenConstants.PrivateBaseUrl + DepositAddressUrl);
        }
        finally
        {
            CustomSemaphore.Release();
        }

        return response;
    }
}