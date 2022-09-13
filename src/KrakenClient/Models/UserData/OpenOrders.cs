namespace KrakenClient.Models.UserData;

public class OpenOrders : BaseResponse<OpenOrderResult>
{
}

public sealed class OpenOrderResult
{
    [JsonPropertyName("open")] public IDictionary<string, BaseOrder>? Open { get; set; }
}