namespace ChimoneyDotNet.Models;

public class PaymentVerification
{
    public string PaymentLink { get; set; }
    public string Error { get; set; }
    /// <summary>
    /// An array of objects containing data
    /// </summary>
    public IEnumerable<Dictionary<string, string>> Data { get; set; }
    //TODO: Add CryptoPayment
    public CryptoPayment CryptoPayment { get; set; }

    /// <summary>
    /// Message from Chimoney. Should be null if no error
    /// Works in simulation
    /// </summary>
    public string? Message { get; set; } = null;
}
