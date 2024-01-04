
namespace ChimoneyDotNet.Models;

public abstract class RedeemRequest
{
    public string? SubAccount { get; set; }

    public string ChiRef { get; set; }

    public Dictionary<string, object> Meta { get; set; }

  
}
