using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models.SubAccount;

public class SubAccount
{
    public string? Id { get; set; }
    public string Parent { get; set; }
    public string Uid { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("subAccount")]
    public bool IsSubAccount { get; set; } 
    /// <summary>
    /// Dictionary to store any extra data
    /// </summary>
    public Dictionary<string,object> Meta { get; set; }
    public IEnumerable<Wallet> Wallets { get; set; }
}

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
    public Dictionary<string,object> Meta { get; set; }
    public decimal NewBalance { get; set; }
    public string Description { get; set; }
}