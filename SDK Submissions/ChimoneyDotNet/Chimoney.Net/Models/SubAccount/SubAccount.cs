using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models;

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

