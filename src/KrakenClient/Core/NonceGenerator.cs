namespace KrakenClient.Core;

internal sealed class NonceGenerator
{
    internal static long GetNonce => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}