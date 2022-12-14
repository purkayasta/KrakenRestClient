namespace KrakenRestClient.Models.MarketData;

public class TickerInformationResponse : BaseResponse<IDictionary<string, TickerInformation>>
{
}

public class TickerInformation
{
    [JsonPropertyName("a")] public string[]? Ask { get; set; }

    [JsonPropertyName("b")] public string[]? Bid { get; set; }

    [JsonPropertyName("c")] public string[]? LastTradeClosed { get; set; }

    [JsonPropertyName("v")] public string[]? Volume { get; set; }

    [JsonPropertyName("p")] public string[]? VolumeWeightedAvgPrice { get; set; }

    [JsonPropertyName("t")] public int[]? NumberOfTrades { get; set; }

    [JsonPropertyName("l")] public string[]? Low { get; set; }

    [JsonPropertyName("h")] public string[]? High { get; set; }

    [JsonPropertyName("o")] public string? TodayOpeningPrice { get; set; }
}