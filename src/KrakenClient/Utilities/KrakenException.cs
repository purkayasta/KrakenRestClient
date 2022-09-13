namespace KrakenClient.Utilities;

internal sealed class KrakenException : Exception
{
    private KrakenException(string message) : base(message)
    {
    }

    internal static void ThrowIfNullOrEmpty(string paramValue, string paramName)
    {
        if (string.IsNullOrEmpty(paramValue) || string.IsNullOrWhiteSpace(paramValue) || paramValue.Length < 1)
        {
            throw new KrakenException($"{paramName} cannot be null or empty");
        }
    }
}