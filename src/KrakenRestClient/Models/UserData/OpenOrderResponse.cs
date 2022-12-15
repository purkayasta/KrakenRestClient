namespace KrakenRestClient.Models.UserData;

public class OpenOrderResponse : BaseResponse<OpenOrder>
{
}

public abstract class OpenOrder
{
    [JsonPropertyName("open")] public IDictionary<string, BaseOrder>? Open { get; set; }
}