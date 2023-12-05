
namespace ChimoneyDotNet.Models.Payout;

public class MobileMoneyPayout
{
    /// <summary>
    /// Payout country
    /// </summary>
    public string CountryToSend { get; set; }

    /// <summary>
    /// Recipient phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Payout value in USD
    /// </summary>
    public decimal ValueInUSD { get; set; }

    /// <summary>
    /// Transaction reference
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// Mobile Money Code
    /// </summary>
    public string MomoCode { get; set;}
}

