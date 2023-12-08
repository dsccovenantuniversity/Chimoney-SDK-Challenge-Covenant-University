using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models;

public class ChimoneyTransaction
{
    /// <summary>
    /// Subaccount (Wallet Account) to payout from, if any.
    /// </summary>
    public string? SubAccount { get; set; }

    /// <summary>
    /// url to redirect to after payment is confirmed
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string RedirectUrl { get; set; } = string.Empty;

    public IEnumerable<ChimoneyPayment> Chimoneys { get; set; }

    /// <summary>
    /// Generate a Xumm transaction sign link
    /// </summary>
    [JsonPropertyName("enableXUMMPayment")]
    public bool EnableXUMMPayment { get; set; }

    /// <summary>
    /// Generate an Open Payment payment request to pay with Interledger
    /// </summary>
    public bool EnableInterledgerPayment { get; set; }

    /// <summary>
    /// Crypto payload
    /// </summary>
    public IEnumerable<CryptoPayment> CryptoPayment { get; set; }
}
