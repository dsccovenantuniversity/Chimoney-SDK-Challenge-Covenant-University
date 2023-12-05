namespace ChimoneyDotNet.Models.Payout;

/// <summary>
/// Represents response to a payout request
/// </summary>
public class PayoutResult
{
    public string PayoutLink { get; set; }
    public IEnumerable<PaymentData> Data { get; set; }
    public IEnumerable<PaymentData> Chimoneys { get; set; }
    public string Error { get; set; }
    //public Dictionary<int, PaymentData> Payouts { get; set; }
    public PayoutsData Payouts { get; set; }
}
