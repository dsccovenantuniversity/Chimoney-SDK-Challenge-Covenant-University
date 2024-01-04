namespace ChimoneyDotNet.Models;

/// <summary>
/// Transaction Detail
/// </summary>
public class TransactionDetail : Transaction
{
    public string InitiatedBy { get; set; }
    public string Email { get; set; }
    public decimal Chimoney { get; set; }
    public decimal ValueInUSD { get; set; }
    public string[] EnabledToRedeem { get; set; }
    //HACK another way to do this?
    public string? Error { get; set; }
}
