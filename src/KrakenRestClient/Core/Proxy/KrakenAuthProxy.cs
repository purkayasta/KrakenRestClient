using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("KrakenClientTest")]

namespace KrakenRestClient.Core.Proxy;

internal sealed class KrakenAuthProxy
{
    internal void SetSecretKey(string key) => KrakenAuth.SecretKey = key;
    internal void SetApiKey(string key) => KrakenAuth.ApiKey = key;

    internal string GetSignKey(string url, string nonce, string? parameters) =>
        KrakenAuth.CreateAuthSignature(nonce, url, parameters);

    internal byte[] GetHash(string apiPath, string hashData) =>
        KrakenAuth.GetHash(apiPath, hashData);
}