
namespace ChimoneyDotNet.Models;
/// <summary>
/// Transfer Detail Model
/// </summary>
public class TransferDetail
{
    public string Sender { get; set; }
    public string Wallet { get; set; }
    public decimal ValueInUSD { get; set; }
    public string TnxID { get; set; }
    public string Receiver { get; set; }
    //TODO ensure to handle this specially
    public string Error { get; set; }
}
