using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models.Payout;

/// <summary>
/// Represents a Chimoney payout
/// </summary>
public class ChimoneyPayout
{
    /// <summary>
    /// Recipient email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Recipient Phone Number with country Code
    /// </summary>
    [JsonPropertyName("phone")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Value in USD
    /// </summary>
    public decimal ValueInUSD { get; set; }

    /// <summary>
    /// Redeem data 
    /// </summary>
    public ChimoneyRedeemData RedeemData { get; set; }

}

public class ChimoneyRedeemData
{
    /// <summary>
    /// Chimoney Wallet ID to deposit the value to
    /// </summary>
    [JsonPropertyName("walletID")]
    public string WalletID { get; set; }

    /// <summary>
    /// Interledger Wallet Address (Payment Pointer) to settle the Payment in. 
    /// Must be issued by a Chimoney Interledger pair
    /// </summary>
    public string InterledgerWalletAddress { get; set; }
}