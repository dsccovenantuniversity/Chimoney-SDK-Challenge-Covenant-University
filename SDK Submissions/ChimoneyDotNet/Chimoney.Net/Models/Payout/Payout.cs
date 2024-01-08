using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models;

public class Payout
{
    public string PayoutLink { get; set; }
    public string Error { get; set; }
    public decimal Id { get; set; }
    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; }
    [JsonPropertyName("bank_code")]
    public string BankCode { get; set; }
    [JsonPropertyName("full_name")]
    public string FullName { get; set; }
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
    public string Currency { get; set; }
    [JsonPropertyName("debit_currency")]
    public string DebitCurrency { get; set; }
    public decimal Amount { get; set; }
    public decimal Fee { get; set; }
    public string Status { get; set; }
    public string Reference { get; set; }
    public Dictionary<string, object> Meta { get; set; }
    public string Narration { get; set; }
    [JsonPropertyName("complete_message")]
    public string CompleteMessage { get; set; }
    [JsonPropertyName("requires_approval")]
    public int RequiresApproval { get; set; }
    [JsonPropertyName("is_approved")]
    public int IsApproved { get; set; }
    [JsonPropertyName("bank_name")]
    public string BankName { get; set; }
}
