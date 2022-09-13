namespace KrakenClient.Models.UserData;

public class TradesHistory : BaseResponse<TradesHistoryResult>
{
}

public sealed class TradesHistoryResult
{
    [JsonPropertyName("trades")] public IDictionary<string, BaseTradeInfo>? Trades { get; set; }
    
    /// <summary>
    /// Amount of available trades matching criteria
    /// </summary>
    [JsonPropertyName("count")] public int Count { get; set; }
}