namespace ChimoneyDotNet.Models;

public class RedeemMobileMoneyRequest : RedeemRequest
{
    public Dictionary<string, object> RedeemOptions { get; set; }
}
