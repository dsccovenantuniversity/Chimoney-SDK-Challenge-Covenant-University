
namespace ChimoneyDotNet.Models.Payout;

public class PayoutsData
{
    public Dictionary<string, PaymentData>  Payouts { get; set; }
    public string IssueID { get; set; }
}
