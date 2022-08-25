using System.Text.Json.Serialization;

namespace KrakenClient.Models.UserData;

public class TradeBalance : BaseResponse<TradeBalanceResult>
{
}

public abstract class TradeBalanceResult
{
    /// <summary>
    /// Equivalent balance (combined balance of all currencies)
    /// </summary>
    [JsonPropertyName("eb")]
    public string? EquivalentBalance { get; set; }

    /// <summary>
    /// Trade balance (combined balance of all equity currencies)
    /// </summary>
    [JsonPropertyName("tb")]
    public string? TradeBalance { get; set; }

    /// <summary>
    /// Margin amount of open positions
    /// </summary>
    [JsonPropertyName("m")]
    public string? MarginAmountOfOpenPosition { get; set; }

    /// <summary>
    /// Unrealized net profit/loss of open positions
    /// </summary>
    [JsonPropertyName("n")]
    public string? NetProfitLossOfOpenPosition { get; set; }

    /// <summary>
    /// Cost basis of open positions
    /// </summary>
    [JsonPropertyName("c")]
    public string? CostBasisOfOpenPosition { get; set; }

    /// <summary>
    /// Current floating valuation of open positions
    /// </summary>
    [JsonPropertyName("v")]
    public string? CurrentlyFloatingValuation { get; set; }

    /// <summary>
    /// Equity: trade balance + unrealized net profit/loss
    /// </summary>
    [JsonPropertyName("e")]
    public string? Equity { get; set; }

    /// <summary>
    /// Free margin: Equity - initial margin (maximum margin available to open new positions)
    /// </summary>
    [JsonPropertyName("mf")]
    public string? FeeMargin { get; set; }

    /// <summary>
    /// Margin level: (equity / initial margin) * 100
    /// </summary>
    [JsonPropertyName("ml")]
    public string? MarginLevel { get; set; }
}