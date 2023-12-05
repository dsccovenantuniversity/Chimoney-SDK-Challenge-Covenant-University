
namespace ChimoneyDotNet.Models.Payout;

/// <summary>
/// Represents a json object with payouts and an issueId field
/// </summary>
public class PayoutsDict
{
    public string IssueID { get; set; }
    public Dictionary<string,Payout> PayoutList { get; set; }
}
