using System.Runtime.CompilerServices;
using KrakenClient.Utilities;

[assembly: InternalsVisibleTo("KrakenClientTest")]

namespace KrakenClient.Core.Proxy;

internal sealed class KrakenAuthProxy
{
    internal string GetSignKey(string? apiKey, string? url, string? endpoint, long? nonce, string? parameters) =>
        KrakenAuth.GetApiSignKey(apiKey, nonce, url, endpoint, parameters);

    internal string GetSignKey(byte[] hashTokenByteArr) => KrakenAuth.GetApiSignKey(hashTokenByteArr);

    internal byte[] GetHash(string apiKey, string apiPath, string hashData) =>
        KrakenAuth.GetHash(apiKey, apiPath, hashData);

    internal string GetHashData(long? nonce, string? parameters) => KrakenAuth.GetHashData(nonce, parameters);
}