namespace KrakenRestClient.Models.UserData;

public class LedgerInfoResponse : BaseResponse<LedgerInfo>
{
}

public class LedgerInfo
{
    [JsonPropertyName("ledger")] public IDictionary<string, BaseLedgerInfo>? Ledger { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}