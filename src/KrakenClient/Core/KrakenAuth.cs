using System.Security.Cryptography;
using System.Text;
using KrakenClient.Utilities;

namespace KrakenClient.Core;

internal static class KrakenAuth
{
    internal static string? ApiKey { get; set; }
    internal static string? SecretKey { get; set; }
    internal static bool IsHttps { get; set; } = false;

    internal static string GetApiSignKey(string? apiKey, long? nonce, string? url, string? parameters)
    {
        KrakenException.ThrowIfNullOrEmpty(nameof(apiKey), apiKey);
        KrakenException.ThrowIfNullOrEmpty(nameof(url), url);
        KrakenException.ThrowIfInvalidNumber(nameof(nonce), nonce);
        
        var hashTokenArr = GetHash(apiKey, url, GetHashData(nonce, parameters));

        return GetApiSignKey(hashTokenArr);
    }

    internal static string GetApiSignKey(byte[] hashTokenByteArr)
    {
        return Convert.ToBase64String(hashTokenByteArr);
    }

    internal static string GetHashData(long? nonce, string? parameters)
    {
        if (nonce is null) KrakenException.Throw("Invalid Nonce");

        if (string.IsNullOrEmpty(parameters) || parameters.Length < 1)
            return nonce + "nonce=" + nonce;
        return nonce + "nonce=" + nonce + parameters;
    }

    internal static byte[] GetHash(string apiKey, string url, string hashData)
    {
        using var sha256 = SHA256.Create();
        var sha256Hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashData));
        var apiEndpointPathBytes = Encoding.UTF8.GetBytes(url);
        var sha512HashData = apiEndpointPathBytes.Concat(sha256Hash).ToArray();
        var encryptor = new HMACSHA512(Convert.FromBase64String(apiKey));
        return encryptor.ComputeHash(sha512HashData);
    }
}