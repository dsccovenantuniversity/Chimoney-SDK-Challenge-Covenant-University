
namespace ChimoneyDotNet.Models.Payout;

public class GiftcardPayout
{
    public string Email { get; set; }
    public decimal ValueInUSD { get; set; }
    public GifcardRedeemData RedeemData { get; set; }
}

public class GifcardRedeemData
{
    public decimal ProductId { get; set; }
    public string CountryCode { get; set; }
    public decimal ValueInLocalCurrency { get; set; }
}

