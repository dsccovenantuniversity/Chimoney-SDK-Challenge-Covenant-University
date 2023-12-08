
namespace ChimoneyDotNet.Models;

/// <summary>
/// Data field in payment responses
/// </summary>
public class PaymentData
{
    public string Id { get; set; }
    public decimal ValueInUSD { get; set; }
    public decimal Chimoney { get; set; }
    public string IssueID { get; set; }
    public decimal Fee { get; set; }
    public string Type { get; set; }
    public string InitiatorKey { get; set; }
    public string Phone { get; set; }
    public string ChiRef { get; set; }
    public Dictionary<string, string> Integration { get; set; }
    public string IssueDate { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> RedeemData { get; set; }
    public string InitiatedBy { get; set; }
    public string Issuer { get; set; }
    public Dictionary<string, string> Meta { get; set; }
    public string UpdatedDate { get; set; }
    public string PaymentDate { get; set; }
    public string[] EnabledToRedeem { get; set; }
    public string Twitter { get; set; }
    public string RedeemLink { get; set; }
    public Dictionary<string, string> Message { get; set; }
}
