using System.Security.Cryptography;

namespace KrakenRestClient.Core;

internal static class KrakenAuth
{
    internal static string? ApiKey { get; set; }
    internal static string? SecretKey { get; set; }

    internal static string CreateAuthSignature(string nonce, string url, string? parameters)
    {
        ArgumentNullException.ThrowIfNull(nonce, nameof(nonce));
        ArgumentNullException.ThrowIfNull(url, nameof(url));

        string payload = nonce + parameters;
        byte[] signatureArray = GetHash(url, payload);

        return Convert.ToBase64String(signatureArray);
    }

    internal static byte[] GetHash(string url, string payload)
    {
        ArgumentNullException.ThrowIfNull(SecretKey, nameof(SecretKey));
        using HMACSHA512 hmacSha512 = new HMACSHA512(Convert.FromBase64String(SecretKey));
        byte[] payloadHash = SHA256.HashData(Encoding.UTF8.GetBytes(payload));
        byte[] uriByteArr = Encoding.UTF8.GetBytes(url);
        byte[] payloadArray = uriByteArr.Concat(payloadHash).ToArray();
        return hmacSha512.ComputeHash(payloadArray);
    }
}