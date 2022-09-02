namespace KrakenClient.Models.UserData;

public abstract class OpenOrders : BaseResponse<OpenOrderResult>
{
}

public abstract class OpenOrderResult
{
    [JsonPropertyName("open")] public IDictionary<string, BaseOrder>? Open { get; set; }
}