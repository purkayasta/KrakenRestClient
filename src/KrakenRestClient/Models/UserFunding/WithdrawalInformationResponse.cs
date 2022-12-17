namespace KrakenRestClient.Models.UserFunding;

public class WithdrawalInformationResponse : BaseResponse<WithdrawalInformation>
{
}

public class WithdrawalInformation
{
    /// <summary>
    /// Name of the withdrawal method that will be used
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Maximum net amount that can be withdrawn right now
    /// </summary>
    [JsonPropertyName("limit")]
    public string? Limit { get; set; }

    /// <summary>
    /// Net amount that will be sent, after fees
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Amount of fees that will be paid
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }
}