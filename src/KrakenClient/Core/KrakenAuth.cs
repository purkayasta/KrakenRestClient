using System.Security.Cryptography;
using System.Text;
using KrakenClient.Utilities;

namespace KrakenClient.Core;

internal sealed class KrakenAuth
{
    internal static string GetSignKey(string apiKey, long nonce, string url, string endpoint, string parameters)
    {
        KrakenException.ThrowIfNullOrEmpty(nameof(apiKey), apiKey);
        KrakenException.ThrowIfNullOrEmpty(nameof(url), url);
        KrakenException.ThrowIfNullOrEmpty(nameof(endpoint), endpoint);
        KrakenException.ThrowIfInvalidNumber(nameof(nonce), nonce);

        var apiEndpointPath = url + endpoint;

        return Convert.ToBase64String(GetHash(apiEndpointPath, GetHashData(nonce, parameters), apiKey));
    }

    private static string GetHashData(long nonce, string parameters)
    {
        if (string.IsNullOrEmpty(parameters) | parameters.Length < 1)
            return nonce + "nonce=" + nonce;
        return nonce + "nonce=" + nonce + parameters;
    }

    private static byte[] GetHash(string apiEndpointPath, string hashData, string apiKey)
    {
        using var sha256 = SHA256.Create();
        var sha256Hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashData));
        var apiEndpointPathBytes = Encoding.UTF8.GetBytes(apiEndpointPath);
        var sha512HashData = apiEndpointPathBytes.Concat(sha256Hash).ToArray();
        var encryptor = new HMACSHA512(Convert.FromBase64String(apiKey));
        return encryptor.ComputeHash(sha512HashData);
    }
}