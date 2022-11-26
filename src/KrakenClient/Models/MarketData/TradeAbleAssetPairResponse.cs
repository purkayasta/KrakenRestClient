namespace KrakenClient.Models.MarketData;

public class TradeAbleAssetPairResponse : BaseResponse<IDictionary<string, TradeAbleAssetPair>>
{
}

public abstract class TradeAbleAssetPair
{
    /// <summary>
    /// Alternate pair name
    /// </summary>
    [JsonPropertyName("altname")]
    public string? AlternatePairName { get; set; }

    /// <summary>
    /// WebSocket pair name (if available)
    /// </summary>
    [JsonPropertyName("wsname")]
    public string? WebSocketPairName { get; set; }

    /// <summary>
    /// Asset class of base component
    /// </summary>
    [JsonPropertyName("aclass_base")]
    public string? AssetClassBase { get; set; }

    /// <summary>
    /// Asset ID of base component
    /// </summary>
    [JsonPropertyName("base")]
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Asset class of quote component
    /// </summary>
    [JsonPropertyName("aclass_quote")]
    public string? AssetClassForQuoteComponent { get; set; }

    /// <summary>
    /// Volume lot size
    /// </summary>
    [JsonPropertyName("pair_decimals")]
    public int PairDecimals { get; set; }

    /// <summary>
    /// Scaling decimal places for pair
    /// </summary>
    [JsonPropertyName("lot_decimals")]
    public int LotDecimals { get; set; }

    /// <summary>
    /// Scaling decimal places for volume
    /// </summary>
    [JsonPropertyName("lot_multiplier")]
    public int LotMultiplier { get; set; }

    /// <summary>
    /// Array of leverage amounts available when buying
    /// </summary>
    [JsonPropertyName("leverage_buy")]
    public int[]? LeverageBuy { get; set; }

    /// <summary>
    /// Array of leverage amounts available when buying
    /// </summary>
    [JsonPropertyName("leverage_sell")]
    public int[]? LeverageSell { get; set; }

    /// <summary>
    /// Fee schedule array in [volume, percent fee] tuples
    /// </summary>
    [JsonPropertyName("fees")]
    public List<double[]>? Fees { get; set; }

    /// <summary>
    /// Maker fee schedule array in [volume, percent fee] tuples (if on maker/taker)
    /// </summary>
    [JsonPropertyName("fees_maker")]
    public List<double[]>? FeesMaker { get; set; }

    /// <summary>
    /// Volume discount currency
    /// </summary>
    [JsonPropertyName("fee_volume_currency")]
    public string? FeeVolumeCurrency { get; set; }

    /// <summary>
    /// Margin call level
    /// </summary>
    [JsonPropertyName("margin_call")]
    public int MarginCall { get; set; }

    /// <summary>
    /// Stop-out/liquidation margin level
    /// </summary>
    [JsonPropertyName("margin_stop")]
    public int MarginStop { get; set; }

    /// <summary>
    /// Minimum order size (in terms of base currency)
    /// </summary>
    [JsonPropertyName("ordermin")]
    public string? OrderMin { get; set; }
}