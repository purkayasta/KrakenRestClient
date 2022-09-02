namespace KrakenClient.Models.UserData;

public abstract class LedgerInfo : BaseResponse<LedgerInfoResult>
{
}

public abstract class LedgerInfoResult
{
    [JsonPropertyName("ledger")] public IDictionary<string, BaseLedgerInfo>? Ledger { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}