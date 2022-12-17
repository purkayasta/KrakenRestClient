namespace KrakenRestClient.Models.UserStaking;

public class PendingStakingTransactionResponse : BaseResponse<IEnumerable<StakingTransaction>>
{
}

public class StakingTransaction
{
    /// <summary>
    /// Reference ID
    /// </summary>
    [JsonPropertyName("refid")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The type of transaction. Enum: "bonding" "reward" "unbonding"
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Asset code/name
    /// </summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>
    /// The transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Unix timestamp when the transaction was initiated.
    /// </summary>
    [JsonPropertyName("time")]
    public int Time { get; set; }

    /// <summary>
    /// Unix timestamp from the start of bond period (applicable only to bonding transactions). 
    /// </summary>
    [JsonPropertyName("bond_start")]
    public int BondStart { get; set; }

    /// <summary>
    /// Unix timestamp of the end of bond period (applicable only to bonding transactions).
    /// </summary>
    [JsonPropertyName("bond_end")]
    public int BondEnd { get; set; }

    /// <summary>
    /// Transaction status. Enum: "Initial" "Pending" "Settled" "Success" "Failure"
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}