namespace KrakenRestClient.Models.UserFunding;

public class WithdrawFundsResponse : BaseResponse<WithdrawFund>
{
}

public class WithdrawFund
{
    /// <summary>
    /// Reference ID
    /// </summary>
    [JsonPropertyName("refid")]
    public string? ReferenceId { get; set; }
}