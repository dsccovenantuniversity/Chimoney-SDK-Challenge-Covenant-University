
namespace ChimoneyDotNet.Models;

public class ChimoneyPayment
{
    /// <summary>
    /// Recipient Email Address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Recipient Phone Number with country code.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Value in USD
    /// </summary>
    public decimal ValueInUSD { get; set; }

    /// <summary>
    /// Twitter handle
    /// </summary>
    public string Twitter { get; set; }
}
