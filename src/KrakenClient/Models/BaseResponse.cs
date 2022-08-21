using System.Text.Json.Serialization;

namespace KrakenClient.Models;

public abstract class BaseResponse<T>
{
    [JsonPropertyName("result")] public T? Result { get; set; }

    [JsonPropertyName("error")] public string[]? Errors { get; set; }
}