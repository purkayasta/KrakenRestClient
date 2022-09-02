namespace KrakenClient.Models;

public abstract class BaseResponse<T>
{
    [JsonPropertyName("result")] public T? Result { get; init; }

    [JsonPropertyName("error")] public string[]? Errors { get; init; }
}