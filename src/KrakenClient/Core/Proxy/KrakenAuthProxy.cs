using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("KrakenClientTest")]

namespace KrakenClient.Core.Proxy;

internal sealed class KrakenAuthProxy
{
    internal string GetSignKey(string apiKey, string url, string endpoint, long nonce, string parameters)
    {
        return KrakenAuth.GetSignKey(apiKey, nonce, url, endpoint, parameters);
    }
}