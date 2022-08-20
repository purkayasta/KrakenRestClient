using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("KrakenClientTest")]

namespace KrakenClient.Core.Proxy;

internal sealed class KrakenAuthProxy
{
    internal void SetSecretKey(string key) => KrakenAuth.SecretKey = key;
    internal void SetApiKey(string key) => KrakenAuth.ApiKey = key;

    internal string GetSignKey(string url, string nonce, string? parameters) =>
        KrakenAuth.GetSignKey(nonce, url, parameters);

    internal string GetSignKey(byte[] hashTokenByteArr) => KrakenAuth.GetSignKey(hashTokenByteArr);

    internal byte[] GetHash(string apiPath, string hashData) =>
        KrakenAuth.GetHash(apiPath, hashData);

    internal string GetHashData(string nonce, string? parameters) => KrakenAuth.GetHashData(nonce, parameters);
}