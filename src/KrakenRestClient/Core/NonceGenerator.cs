namespace KrakenRestClient.Core;

internal static class NonceGenerator
{
    internal static string GetNonce() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
}