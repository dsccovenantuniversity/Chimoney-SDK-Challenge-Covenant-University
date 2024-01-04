using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models;

/// <summary>
/// Bank account for verfication
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Country of Bank to verify
    /// </summary>

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    /// <summary>
    /// Bank Code
    /// </summary>
    [JsonPropertyName("account_bank")]
    public string Account_Bank { get; set; }

    /// <summary>
    /// Account Number
    /// </summary>
    [JsonPropertyName("account_number")]
    public string Account_Number { get; set; }
}
