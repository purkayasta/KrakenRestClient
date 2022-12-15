namespace KrakenRestClient.Models.UserData;

public class TradesHistoryResponse : BaseResponse<TradesHistory>
{
}

public class TradesHistory
{
    [JsonPropertyName("trades")] public IDictionary<string, BaseTradeInfo>? Trades { get; set; }

    /// <summary>
    /// Amount of available trades matching criteria
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}