using ChimoneyDotNet.Models.Payout;
using ChimoneyDotNet.Models;

namespace ChimonyDotNet.Test;

public class PayoutTest
{
    private readonly IChimoneyBase chimoney = new Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? 
        "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");
    private readonly string success = "success";
    private readonly string error = "error";

    public PayoutTest()
    {
        Chimoney.BaseUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";
    }

    [Fact]
    public async Task PayoutAirtime_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<AirtimePayout>()
        {
            TurnOffNotification = false,
            Data = new List<AirtimePayout>()
        {
            new()
            {
                CountryToSend = "Nigeria",
                PhoneNumber = "+2348123456789",
                ValueInUSD = 10
            }
        }
        };

        var result = await chimoney.PayoutAirtime(payoutRequest);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
    }

    [Fact]
    public async Task PayoutToBank_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<BankPayout>()
        {
            TurnOffNotification = false,
            Data = new List<BankPayout>()
            {
                new()
                {
                    CountryToSend = "Nigeria",
                    AccountBank = "044",
                    AccountNumber = "0690000032",
                    ValueInUSD = 10,
                    FullName = "John Doe",
                    Reference = "12345567",
                    BranchCode = "GH190101"
                }
            }
        };

        var result = await chimoney.PayoutToBank(payoutRequest);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
        Assert.Equal("Insufficient balance in your chi wallet", result.Error);

    }

    [Fact]
    public async Task PayoutToChimoney_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<ChimoneyPayout>()
        {
            Data = new List<ChimoneyPayout>()
            {
                new()
                {
                    Email = "test@gmail.com",
                    PhoneNumber = "+16471112222",
                    ValueInUSD = 10
                }
            }
        };

        var result = await chimoney.PayoutChimoney(payoutRequest);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
        Assert.Equal("Insufficient balance in your chi wallet", result.Error);
    }

    [Fact]
    public async Task PayoutToChimoneyWallet_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<ChimoneyWalletPayout>()
        {
            Data = new List<ChimoneyWalletPayout>()
        {
            new()
            {
                Receiver = "dimfofofofoof",
                ValueInUSD = 10
            }
        }
        };

        var result = await chimoney.PayoutToChimoneyWallet(payoutRequest);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
        Assert.Equal("Could not find a wallet for receiver dimfofofofoof", result.Error);
    }

    [Fact]
    public async Task PayoutToInterledgerWallet_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<InterledgerWalletPayout>()
        {
            Data = new List<InterledgerWalletPayout>()
        {
            new()
            {
                InterledgerWalletAddress = "https://ilp.chimoney.io/uchi",
                ValueInUSD = 10
            }
        }
        };

        var result = await chimoney.PayoutToInterledgerWallet(payoutRequest);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
        Assert.Equal("The interledgerWalletAddressURL Wallet Address (Payment Pointer) is invalid", result.Error);
    }

    [Fact]
    public async Task PayoutGiftcard_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<GiftcardPayout>()
        {
            Data = new List<GiftcardPayout>()
        {
            new()
            {
                Email = "test@gmail.com",
                ValueInUSD = 10,
                RedeemData = new()
                {
                    ProductId = 5,
                    CountryCode = "US",
                    ValueInLocalCurrency = 5000
                }
            }

        }
        };

        var result = await chimoney.PayoutGiftcards(payoutRequest);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.NotNull(result.Error);
        // HACK problem on source side ¯\_(ツ)_/¯
        Assert.Equal("1002[object Object] must a a number", result.Error);
    }

    //[Fact]
    //TODO problem on source side ¯\_(ツ)_/¯
    public async Task PayoutMobileMoney_Returns_ValidResponse()
    {
        var payoutRequest = new PayoutRequest<MobileMoneyPayout>()
        {
            Data = new List<MobileMoneyPayout>()
        {
            new ()
            {
                CountryToSend = "Kenya",
                PhoneNumber = "254710102720",
                ValueInUSD = 10,
                Reference = "1234567890",
                MomoCode = "MPS"
            }
        }
        };

        var result = await chimoney.PayoutMobileMoney(payoutRequest);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<PaymentData>>(result.Data.Chimoneys);
    }

    [Fact]
    public async Task CheckPayoutStatus_Returns_Success()
    {
        var result = await chimoney.CheckPayoutStatus("841aa5df-df90-4269-83ac-65bf457a9a5f");
        Assert.Equal(success, result.Status);
        Assert.IsType<ChimoneyResult>(result.Data);
    }

    [Fact]
    public async Task InitiateChimoneyTransaction_Returns_Success()
    {
        var result = await chimoney.InitiateChimoneyTransaction(new ChimoneyTransaction()
        {
            RedirectUrl = "https://test.com",
            Chimoneys = new List<ChimoneyPayment>()
      {
          new()
          {
              Email = "test@gmail.com",
              Phone = "+16471112222",
              ValueInUSD = 10,
              Twitter = "@test"
          }
      },
            EnableXUMMPayment = false,
            EnableInterledgerPayment = false,
            CryptoPayment = new List<CryptoPayment>()
      {
          new()
          {
              Address = "0x1234567890",
              Issuer = "issuer",
              Currency = "Currency",
          }
      }
        });

        Assert.Equal(success, result.Status);
    }
}
