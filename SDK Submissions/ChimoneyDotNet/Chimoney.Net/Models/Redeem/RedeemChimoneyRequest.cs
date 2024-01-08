
namespace ChimoneyDotNet.Models;

public class RedeemChimoneyRequest : RedeemRequest
{
    public bool TurnOffNotification { get; set; }
    public List<Dictionary<string, object>> Chimoneys { get; set; }
}
