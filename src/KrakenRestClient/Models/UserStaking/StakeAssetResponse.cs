namespace KrakenRestClient.Models.UserStaking;

public class StakeAssetResponse : BaseResponse<Asset>
{
}

public class Asset
{
    /// <summary>
    /// Reference ID
    /// </summary>
    [JsonPropertyName("refid")]
    public string? ReferenceId { get; set; }
}