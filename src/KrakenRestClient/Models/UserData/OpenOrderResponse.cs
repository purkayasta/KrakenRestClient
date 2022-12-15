namespace KrakenRestClient.Models.UserData;

public class OpenOrderResponse : BaseResponse<OpenOrder>
{
}

public class OpenOrder
{
    [JsonPropertyName("open")] public IDictionary<string, BaseOrder>? Open { get; set; }
}