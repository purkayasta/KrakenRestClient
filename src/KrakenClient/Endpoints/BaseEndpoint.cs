namespace KrakenClient.Endpoints;

internal abstract class BaseEndpoint
{
    internal static SemaphoreSlim CustomSemaphore = new SemaphoreSlim(1, 1);
}