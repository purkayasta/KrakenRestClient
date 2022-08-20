using System.Security.Cryptography;
using System.Text;

namespace KrakenClient.Core;

internal static class KrakenAuth
{
    internal static string? ApiKey { get; set; }
    internal static string? SecretKey { get; set; }

    internal static string GetSignKey(string nonce, string url, string? parameters)
    {
        ArgumentNullException.ThrowIfNull(nonce, nameof(nonce));
        ArgumentNullException.ThrowIfNull(url, nameof(url));

        var hashTokenArr = GetHash(url, GetHashData(nonce, parameters));

        return GetSignKey(hashTokenArr);
    }

    internal static string GetSignKey(byte[] hashTokenByteArr)
    {
        return Convert.ToBase64String(hashTokenByteArr);
    }

    internal static string GetHashData(string nonce, string? parameters)
    {
        if (string.IsNullOrEmpty(parameters) || parameters.Length < 1)
            return nonce + "nonce=" + nonce;
        return nonce + "nonce=" + nonce + parameters;
    }

    internal static byte[] GetHash(string url, string hashData)
    {
        ArgumentNullException.ThrowIfNull(SecretKey, nameof(SecretKey));

        using var sha256 = SHA256.Create();
        var sha256Hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashData));
        var apiEndpointPathBytes = Encoding.UTF8.GetBytes(url);
        var sha512HashData = apiEndpointPathBytes.Concat(sha256Hash).ToArray();
        var encryptor = new HMACSHA512(Convert.FromBase64String(SecretKey));
        return encryptor.ComputeHash(sha512HashData);
    }
}