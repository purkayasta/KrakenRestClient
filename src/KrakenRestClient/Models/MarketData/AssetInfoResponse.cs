namespace KrakenRestClient.Models.MarketData;

public class AssetInfoResponse : BaseResponse<IDictionary<string, AssetInfo>>
{
}

public class AssetInfo
{
    [JsonPropertyName("aclass")] public string? AssetClass { get; set; }

    [JsonPropertyName("altname")] public string? AltName { get; set; }

    [JsonPropertyName("decimals")] public int Decimal { get; set; }

    [JsonPropertyName("display_decimals")] public int DisplayDecimal { get; set; }
}