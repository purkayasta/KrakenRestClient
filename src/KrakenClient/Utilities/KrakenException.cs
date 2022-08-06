namespace KrakenClient.Utilities;

internal static class KrakenException
{
    internal static void Throw(string message) => throw new Exception(message);
    internal static void Throw(string param, string message) => throw new Exception(param + " " + message);

    internal static void ThrowIfNullOrEmpty(string paramName, string? paramValue)
    {
        if (string.IsNullOrEmpty(paramValue) || string.IsNullOrWhiteSpace(paramValue))
            Throw(paramName, " is invalid");
    }

    internal static void ThrowIfInvalidNumber(string paramName, long? paramValue)
    {
        if (paramValue is null or < 1) Throw(paramName, " is invalid");
    }
}