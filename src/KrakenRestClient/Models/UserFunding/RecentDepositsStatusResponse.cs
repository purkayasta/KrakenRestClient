namespace KrakenRestClient.Models.UserFunding;

public class RecentDepositsStatusResponse : BaseResponse<IEnumerable<RecentDepositsStatus>>
{
}

public class RecentDepositsStatus
{
    /// <summary>
    /// Name of deposit method
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Asset class
    /// </summary>
    [JsonPropertyName("aclass")]
    public string? AssetClass { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>
    /// Reference ID
    /// </summary>
    [JsonPropertyName("refid")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Method transaction ID
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Method transaction information
    /// </summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>
    /// Amount deposited
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Fees paid
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// Unix timestamp when request was made
    /// </summary>
    [JsonPropertyName("time")]
    public int Time { get; set; }

    /// <summary>
    /// Status of deposit
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Addition status properties (if available). Example: Enum: "return" "onhold"
    /// </summary>
    [JsonPropertyName("status-prop")]
    public string? AdditionalStatus { get; set; }
}