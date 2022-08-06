using System.Net.Http.Headers;
using System.Text;

namespace KrakenClient.Utilities;

public static class Extensions
{
    public static void AddHeaders(this HttpRequestHeaders httpRequestHeaders, Dictionary<string, string>? headers)
    {
        if (headers is null || headers.Count < 1) return;

        foreach (var item in headers)
        {
            httpRequestHeaders.Add(item.Key, item.Value);
        }
    }

    public static string? ConvertToString(this Dictionary<string, string>? requestBody)
    {
        if (requestBody is null || requestBody.Count < 1) return null;
        
        StringBuilder stringBuilder = new();

        var index = 0;
        var length = requestBody.Count;

        foreach (var item in requestBody)
        {
            stringBuilder.Append(item.Key + "=" + item.Value);

            if (index < length - 1)
            {
                stringBuilder.Append('&');
            }

            index++;
        }

        return stringBuilder.ToString();
    }
}