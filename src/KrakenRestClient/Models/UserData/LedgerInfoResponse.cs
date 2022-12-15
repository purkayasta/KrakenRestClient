namespace KrakenRestClient.Models.UserData;

public class LedgerInfoResponse : BaseResponse<LedgerInfo>
{
}

public abstract class LedgerInfo
{
    [JsonPropertyName("ledger")] public IDictionary<string, BaseLedgerInfo>? Ledger { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}