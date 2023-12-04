
namespace ChimoneyDotNet.Models;

public class PaymentRequest
{
    /// <summary>
    /// Amount in USD to collect
    /// </summary>
    public decimal ValueInUSD { get; set; }

    /// <summary>
    /// Email of the one making the payment
    /// </summary>
    public string PayerEmail { get; set; }

    /// <summary>
    /// Url to redirect to after payment in confirmed
    /// </summary>
    public string Redirect_Url { get; set; }

    /// <summary>
    /// Subaccount if any
    /// </summary>
    public string? SubAccount {  get; set; } = null;

    /// <summary>
    /// <see cref="Dictionary{string, string}"/> containing metadata you want to pass to the request to use later
    /// </summary>
    public Dictionary<string, string> Meta { get; set; }
}
