namespace KrakenRestClient.Models.UserFunding;

public class DepositAddressResponse : BaseResponse<DepositAddresses>
{
}

public class DepositAddresses
{
    /// <summary>
    /// Deposit Address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Expiration time in unix timestamp, or 0 if not expiring
    /// </summary>
    [JsonPropertyName("expiretm")]
    public string? ExpireTime { get; set; }

    /// <summary>
    /// Whether or not address has ever been used
    /// </summary>
    [JsonPropertyName("new")]
    public bool? New { get; set; }
}