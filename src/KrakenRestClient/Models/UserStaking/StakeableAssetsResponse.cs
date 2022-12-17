namespace KrakenRestClient.Models.UserStaking;

public class StakeableAssetsResponse : BaseResponse<IEnumerable<StakeableAssets>>
{
}

public class StakeableAssets
{
    /// <summary>
    /// Asset code/name
    /// </summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>
    /// Staking asset code/name
    /// </summary>
    [JsonPropertyName("staking_asset")]
    public string? StakingAssetName { get; set; }

    /// <summary>
    /// Unique ID of the staking option (used in Stake/Unstake operations)
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Whether the staking operation is on-chain or not. Default: true
    /// </summary>
    [JsonPropertyName("on_chain")]
    public bool OnChain { get; set; }

    /// <summary>
    /// Whether the user will be able to stake this asset. Default: true
    /// </summary>
    [JsonPropertyName("can_stake")]
    public bool CanStake { get; set; }

    /// <summary>
    /// Whether the user will be able to unstake this asset. Default: true
    /// </summary>
    [JsonPropertyName("can_unstake")]
    public bool CanUnstake { get; set; }

    /// <summary>
    /// Minimum amounts for staking/unstaking.
    /// </summary>
    [JsonPropertyName("minimum_amount")]
    public MinimumAmount? MinimumAmount { get; set; }

    /// <summary>
    /// Describes the locking periods and percentages for staking/unstaking operations.
    /// </summary>
    [JsonPropertyName("lock")]
    public Lock? Lock { get; set; }

    /// <summary>
    /// Default: true
    /// </summary>
    [JsonPropertyName("enabled_for_user")]
    public bool EnabledForUser { get; set; }

    [JsonPropertyName("disabled")] public bool Disabled { get; set; }

    /// <summary>
    /// Describes the rewards earned while staking.
    /// </summary>
    [JsonPropertyName("rewards")]
    public Rewards? Rewards { get; set; }
}

public class Rewards
{
    /// <summary>
    /// Reward earned while staking
    /// </summary>
    [JsonPropertyName("reward")]
    public string? Reward { get; set; }

    /// <summary>
    /// Reward type. Value: "percentage"
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public class Lock
{
    [JsonPropertyName("unstaking")] public IEnumerable<LockingObject?>? Unstaking { get; set; }

    [JsonPropertyName("staking")] public IEnumerable<LockingObject?>? Staking { get; set; }

    [JsonPropertyName("lockup")] public IEnumerable<LockingObject?>? LockUp { get; set; }
}

public class LockingObject
{
    /// <summary>
    /// Days the funds are locked.
    /// </summary>
    [JsonPropertyName("days")]
    public int Days { get; set; }

    /// <summary>
    /// Percentage of the funds that are locked (0 - 100). number [ 0 .. 100 ]
    /// </summary>
    [JsonPropertyName("percentage")]
    public int Percentage { get; set; }
}

public class MinimumAmount
{
    /// <summary>
    /// Default: "0"
    /// </summary>
    [JsonPropertyName("unstaking")]
    public string? Unstaking { get; set; }

    /// <summary>
    /// Default: "0"
    /// </summary>
    [JsonPropertyName("staking")]
    public string? Staking { get; set; }
}