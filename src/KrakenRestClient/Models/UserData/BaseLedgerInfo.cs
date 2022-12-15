namespace KrakenRestClient.Models.UserData;

public class BaseLedgerInfo
{
    [JsonPropertyName("refid")] public string? ReferralTransactionId { get; set; }

    [JsonPropertyName("time")] public int Time { get; set; }

    [JsonPropertyName("type")] public string? Type { get; set; }

    [JsonPropertyName("subtype")] public string? SubType { get; set; }

    [JsonPropertyName("aclass")] public string? AssetClass { get; set; }

    [JsonPropertyName("asset")] public string? Asset { get; set; }

    [JsonPropertyName("amount")] public string? Amount { get; set; }

    [JsonPropertyName("fee")] public string? Fee { get; set; }

    [JsonPropertyName("balance")] public string? Balance { get; set; }
}