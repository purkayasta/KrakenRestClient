namespace KrakenClient.Models.UserData;

public class LedgerInfo : BaseResponse<LedgerInfoResult>
{
}

public sealed class LedgerInfoResult
{
    [JsonPropertyName("ledger")] public IDictionary<string, BaseLedgerInfo>? Ledger { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}