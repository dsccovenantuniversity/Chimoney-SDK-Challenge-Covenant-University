
namespace ChimoneyDotNet.Models;

public class RedeemGiftcardRequest : RedeemRequest
{
    public Dictionary<string, object> RedeemOptions { get; set; }
}
