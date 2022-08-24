using System.Text.Json.Serialization;

namespace KrakenClient.Models.MarketData;

public class AssetInfo : BaseResponse<IDictionary<string, AssetInfoResult>>
{
}

public class AssetInfoResult
{
    [JsonPropertyName("aclass")] public string? AssetClass { get; set; }

    [JsonPropertyName("altname")] public string? AltName { get; set; }

    [JsonPropertyName("decimals")] public int Decimal { get; set; }

    [JsonPropertyName("display_decimals")] public int DisplayDecimal { get; set; }
}