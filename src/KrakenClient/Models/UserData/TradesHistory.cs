namespace KrakenClient.Models.UserData;

public abstract class TradesHistory : BaseResponse<TradesHistoryResult>
{
}

public abstract class TradesHistoryResult
{
    [JsonPropertyName("trades")] public IDictionary<string, BaseTradeInfo>? Trades { get; set; }
    
    /// <summary>
    /// Amount of available trades matching criteria
    /// </summary>
    [JsonPropertyName("count")] public int Count { get; set; }
}