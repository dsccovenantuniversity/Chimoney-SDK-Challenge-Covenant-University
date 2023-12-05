namespace ChimoneyDotNet.Models;

public class CryptoPayment
{
    /// <summary>
    /// Wallet address
    /// </summary>
    public string Address { get; set; }
    public string Issuer { get; set; }
    public string Currency { get; set; }
}