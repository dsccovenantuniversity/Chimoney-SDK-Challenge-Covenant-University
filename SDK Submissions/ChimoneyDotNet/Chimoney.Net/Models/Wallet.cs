
namespace ChimoneyDotNet.Models;

public class Wallet
{
    public string Id { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }
    public string Type { get; set; }
    public IEnumerable<WalletTransaction> Transactions { get; set; }

}

public class WalletTransaction
{
    public decimal Amount { get; set; }
    public decimal BalanceBefore { get; set; }
    public Dictionary<string, object> Meta { get; set; }
    public decimal NewBalance { get; set; }
    public string Description { get; set; }
}