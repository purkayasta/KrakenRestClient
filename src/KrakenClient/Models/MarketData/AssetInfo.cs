namespace KrakenClient.Models.MarketData;

public abstract class AssetInfo : BaseResponse<IDictionary<string, AssetInfoResult>>
{
}

public abstract class AssetInfoResult
{
    [JsonPropertyName("aclass")] public string? AssetClass { get; set; }

    [JsonPropertyName("altname")] public string? AltName { get; set; }

    [JsonPropertyName("decimals")] public int Decimal { get; set; }

    [JsonPropertyName("display_decimals")] public int DisplayDecimal { get; set; }
}