namespace KrakenClient.Models.UserData;

public class TradeVolume : BaseResponse<TradeVolumeResult>
{
}

public sealed class TradeVolumeResult
{
    /// <summary>
    /// Volume currency
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Current discount volume
    /// </summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    [JsonPropertyName("fees")] public IDictionary<string, FeeTierInfo>? Fees { get; set; }

    [JsonPropertyName("fees_maker")] public IDictionary<string, FeeTierInfo>? FeesMaker { get; set; }
}

public abstract class FeeTierInfo
{
    /// <summary>
    /// Current fee (in percent)
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// minimum fee for pair (if not fixed fee)
    /// </summary>
    [JsonPropertyName("min_fee")]
    public string? MinimumFee { get; set; }

    /// <summary>
    /// maximum fee for pair (if not fixed fee)
    /// </summary>
    [JsonPropertyName("max_fee")]
    public string? MaximumFee { get; set; }

    /// <summary>
    /// next tier's fee for pair (if not fixed fee, null if at lowest fee tier)
    /// </summary>
    [JsonPropertyName("next_fee")]
    public string? NextFee { get; set; }

    /// <summary>
    /// volume level of current tier (if not fixed fee. null if at lowest fee tier)
    /// </summary>
    [JsonPropertyName("tier_volume")]
    public string? TierVolume { get; set; }

    /// <summary>
    /// volume level of next tier (if not fixed fee. null if at lowest fee tier)
    /// </summary>
    [JsonPropertyName("next_volume")]
    public string? NextVolume { get; set; }
}