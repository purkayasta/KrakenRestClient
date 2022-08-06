namespace KrakenClient.Core;

internal sealed class NonceGenerator
{
    internal long GetNonce() => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}