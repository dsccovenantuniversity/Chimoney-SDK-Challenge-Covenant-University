using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models.Payout;

/// <summary>
/// Represents a bank payout
/// </summary>
public class BankPayout
{
    /// <summary>
    /// Payout country
    /// </summary>
    public string CountryToSend { get; set; }

    /// <summary>
    /// Bank code
    /// </summary>
    [JsonPropertyName("account_bank")]
    public string AccountBank { get; set; }

    /// <summary>
    /// Recipient account number
    /// </summary>
    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// Payout value in USD
    /// </summary>
    public decimal ValueInUSD { get; set; }

    /// <summary>
    /// Transaction reference
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// Full name of beneficiary. Required for all countries except Nigeria
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Branch_code from <seealso cref="IChimoneyBase.GetBankBranches(string)"/> 
    /// Required for all countries except Nigeria
    /// </summary>
    [JsonPropertyName("branch_code")]
    public string BranchCode { get; set; }

}
