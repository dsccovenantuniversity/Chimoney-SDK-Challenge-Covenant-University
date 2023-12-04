
namespace ChimoneyDotNet.Models;

public class CryptoPayment
{
    public Dictionary<string, string> Xrpl { get; set; }
    public Dictionary<string, string> Eth { get; set; }
    public Dictionary<string, string> Bsc { get; set; }

}