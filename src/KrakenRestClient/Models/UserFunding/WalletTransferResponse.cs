namespace KrakenRestClient.Models.UserFunding;

public class WalletTransferResponse : BaseResponse<WalletTransfer>
{
}

public class WalletTransfer
{
    /// <summary>
    /// Reference ID
    /// </summary>
    [JsonPropertyName("refid")]
    public string? ReferenceId { get; set; }
}