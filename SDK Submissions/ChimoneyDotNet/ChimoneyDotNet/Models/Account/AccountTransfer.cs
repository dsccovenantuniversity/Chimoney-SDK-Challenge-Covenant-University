namespace ChimoneyDotNet.Models.Account;

/// <summary>
/// An account transfer
/// </summary>
public class AccountTransfer
{
    public string? ChiRef { get; set; } = null;
    public string ReceiverId { get; set; }
    public decimal ValueInUSD { get; set; }
    public string WalletType { get; set; }
    public string? SubAccount { get; set; } = null;
}
