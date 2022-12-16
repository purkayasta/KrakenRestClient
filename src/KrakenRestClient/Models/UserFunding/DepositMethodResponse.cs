namespace KrakenRestClient.Models.UserFunding;

public class DepositMethodResponse : BaseResponse<IEnumerable<DepositMethod>>
{
}

public class DepositMethod
{
    /// <summary>
    /// Name of deposit method
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Maximum net amount that can be deposited right now, or false if no limit
    /// </summary>
    [JsonPropertyName("limit")]
    public string? Limit { get; set; }

    /// <summary>
    /// Amount of fees that will be paid
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// Whether or not method has an address setup fee
    /// </summary>
    [JsonPropertyName("address-setup-fee")]
    public string? AddressSetupFee { get; set; }

    /// <summary>
    /// Whether new addresses can be generated for this method.
    /// </summary>
    [JsonPropertyName("gen-address")]
    public bool? GenerateAddress { get; set; }
}