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

        var payload = nonce + parameters;
        var signatureArray = GetHash(url, payload);

        return Convert.ToBase64String(signatureArray);
    }

    internal static byte[] GetHash(string url, string payload)
    {
        ArgumentNullException.ThrowIfNull(SecretKey, nameof(SecretKey));

        using var sha256 = SHA256.Create();
        using var hmacSha512 = new HMACSHA512(Convert.FromBase64String(SecretKey));
        var payloadHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(payload));
        var uriByteArr = Encoding.UTF8.GetBytes(url);
        var payloadArray = uriByteArr.Concat(payloadHash).ToArray();
        return hmacSha512.ComputeHash(payloadArray);
    }
}