namespace KrakenClient.Endpoints;

internal abstract class BaseEndpoint
{
    internal static readonly SemaphoreSlim CustomSemaphore = new SemaphoreSlim(1, 1);
}