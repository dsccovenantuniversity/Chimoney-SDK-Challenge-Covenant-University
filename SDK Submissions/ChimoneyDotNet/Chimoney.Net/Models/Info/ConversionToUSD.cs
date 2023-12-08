namespace ChimoneyDotNet.Models;

public class ConversionToUSD
{
    public string AmountInOriginCurrency { get; set; }
    public string OriginCurrency { get; set; }
    public decimal AmountInUSD { get; set; }
    public string ValidUntil { get; set; }
}
