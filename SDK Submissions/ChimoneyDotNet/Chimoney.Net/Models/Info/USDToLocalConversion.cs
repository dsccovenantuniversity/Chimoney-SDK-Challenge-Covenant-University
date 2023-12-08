namespace ChimoneyDotNet.Models.Info;

public class USDToLocalConversion
{
    public string AmountInUSD { get; set; }
    public string DestinationCurrency { get; set; }
    public decimal AmountInDestinationCurrency { get; set; }
    public string ValidUntil { get; set; }
}
