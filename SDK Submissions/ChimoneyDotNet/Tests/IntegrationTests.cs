using ChimoneyDotNet.Models;
using ChimoneyDotNet.Models.Account;
using ChimoneyDotNet.Models.Info;
using ChimoneyDotNet.Models.Payment;
using ChimoneyDotNet.Models.Payout;

namespace ChimoneyTests;
public class IntegrationTests
{
    private readonly IChimoneyBase chimoney = new
        Chimoney("88cd4465f56b3132c385303ca1fd4950c6896eee96304f4dd46513aebff5bcde");
    //TODO : Replace with your API key from ENV or config file
    private readonly string success = "success";
    private readonly string error = "error";

    #region Account

    [Fact]
    public async Task Get_Transactions_By_Account_Returns_Success()
    {
        var result = await chimoney.GetAllTransactionsByAccount();
        Assert.Equal(success, result.Status);
    }

    [Fact]
    public async Task Get_Single_Transaction_Detail_Returns_Success_And_Error()
    {
        var resultOnlyId = await chimoney.GetSingleTransactionDetail("random_id");
        Assert.NotNull(resultOnlyId);
        Assert.Equal(success, resultOnlyId.Status);
        Assert.Equal("not found for that id", resultOnlyId.Error);

        var resultWithSubAccount = await chimoney.GetSingleTransactionDetail("random_id", "subaccount_id");
        Assert.NotNull(resultWithSubAccount);
        Assert.Equal(error, resultWithSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultWithSubAccount.Error);
    }

    [Fact]
    public async Task Get_Transaction_Detail_By_IssueId_Returns_Error()
    {
        var resultOnlyId = await chimoney.GetTransactionDetailByIssueId("random_id");
        Assert.NotNull(resultOnlyId);
        Assert.Equal(success, resultOnlyId.Status);

        var resultWithSubAccount = await chimoney.GetTransactionDetailByIssueId("random_id", "1234567");
        Assert.NotNull(resultWithSubAccount);
        Assert.Equal(error, resultWithSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultWithSubAccount.Error);
    }

    [Fact]
    public async Task Account_Transfer_Returns_Error()
    {
        var accountTransfer = new AccountTransfer()
        {
            ReceiverId = "random_id",
            ValueInUSD = 3000,
            WalletType = "chi"
        };

        var result = await chimoney.AccountTransfer(accountTransfer);
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.Contains("Could not find", result.Error);

        var accountTransferSubaccount = new AccountTransfer()
        {
            ReceiverId = "random_id",
            ValueInUSD = 3000,
            WalletType = "chi",
            SubAccount = "random_id"
        };
        var resultSubAccount = await chimoney.AccountTransfer(accountTransferSubaccount);
        Assert.NotNull(resultSubAccount);
        Assert.Equal(error, resultSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Error);
    }

    [Fact]
    public async Task Delete_Transfer_Returns_Error()
    {
        var result = await chimoney.DeleteTransfer("9ae90e01-6689-453c-b4af-8ae230fafc5a");
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.Equal("Cannot delete as you're not the owner", result.Error);

        var resultSubAccount = await chimoney
            .DeleteTransfer("9ae90e01-6689-453c-b4af-8ae230fafc5a", "123456789");
        Assert.NotNull(resultSubAccount);
        Assert.Equal(error, resultSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Error);
    }

    #endregion

    #region Info

    [Fact]
    public async Task Get_Supported_Airtime_Countries_Returns_Success()
    {
        var result = await chimoney.GetSupportedAirtimeCountries();
        Assert.NotNull(result);
        Assert.Null(result.Error);
        Assert.Equal(success, result.Status);
        Assert.IsType<string[]>(result.Data);
    }

    [Fact]
    public async Task Get_All_Assets_Returns_Success()
    {
        var result = await chimoney.GetAllAssets();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<BenefitsData>(result.Data);

        var resultCountryCode = await chimoney.GetAllAssets("NG");
        Assert.NotNull(resultCountryCode);
        Assert.Equal(success, resultCountryCode.Status);
        Assert.IsType<BenefitsData>(resultCountryCode.Data);
    }

    [Fact]
    public async Task Convert_Local_To_USD_Returns_Sucess()
    {
        var result = await chimoney.ConvertLocalCurrencyToUSD("NGN", 300m);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<ConversionToUSD>(result.Data);
        Assert.IsType<decimal>(result.Data.AmountInUSD);
        Assert.NotEqual(decimal.Zero, result.Data.AmountInUSD);
    }

    [Fact]
    public async Task Get_Bank_Branches_Returns_Success()
    {
        var result = await chimoney.GetBankBranches("280");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<BankBranch>>(result.Data);
    }

    [Fact]
    public async Task Get_Supported_Bank_Returns_Success()
    {
        var result = await chimoney.GetSupportedBanks("NG");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<Bank>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_Exchange_Rates_Returns_Success()
    {
        var result = await chimoney.GetExchangeRates();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<Dictionary<string, decimal>>(result.Data);
    }

    [Fact]
    public async Task Get_MobileMoneyCodes_Returns_Success()
    {
        var result = await chimoney.GetSupportedMobileMoneyCodes();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<MobileMoneyCode>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_USD_To_Local_Returns_Success()
    {
        var result = await chimoney.GetUSDAmountInLocal("NGN", 300m);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<USDToLocalConversion>(result.Data);
        Assert.NotEqual(decimal.Zero, result.Data.AmountInDestinationCurrency);
    }

    [Fact]
    public async Task Verify_BankAccounts_Returns_Success()
    {
        var accounts = new List<BankAccount>()
        {
            new()
            {
                CountryCode = "NG",
                Account_Bank = "044",
                Account_Number = "0690000032"
            }
        };


        var result = await chimoney.VerifyBankAccounts(accounts);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<BankAccount>>(result.Data);
    }

    #endregion

    #region Payment

    [Fact]
    public async Task Make_Payment_Returns_Success()
    {
        PaymentRequest paymentRequest = new()
        {
            PayerEmail = "devs@chimoney.io",
            Redirect_Url = "https://test.com",
            ValueInUSD = 10,
            Meta = new()
            {
                { "key", "value" }
            }
        };

        var result = await chimoney.InitiatePaymentRequest(paymentRequest);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);

        PaymentRequest paymentRequestSubAccount = new()
        {
            PayerEmail = "devs@chimoney.io",
            Redirect_Url = "https://test.com",
            ValueInUSD = 10,
            SubAccount = "jnirjmt0405jmd",
            Meta = new()
            {
                { "key", "value" }
            }
        };

        var resultSubAccount = await chimoney.InitiatePaymentRequest(paymentRequestSubAccount);
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }


    [Fact]
    public async Task Verify_Payment_Returns_Success()
    {
        var result = await chimoney.VerifyPayment("random_id");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);

        var resultSubAccount = await chimoney.VerifyPayment("random_id", "random_id");
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }

    [Fact]
    public async Task Simulate_Payment_Returns_Messsage()
    {
        var result = await chimoney.Simulate("random_id", Status.Failed);
        Assert.NotNull(result);
        Assert.Equal("Cannot change status to failed", result.Message);

        var resultSubAccount = await chimoney.Simulate("random_id", Status.Failed, "random_id");
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }
    #endregion

    #region Payout

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
        Assert.Equal(success, result.Status);
        Assert.Null(result.Error);
        //Assert.Equal("Bank details could not be verified try another account",result.Error);
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
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.Null(result.Error);
        Assert.IsAssignableFrom<IEnumerable<PaymentData>>(result.Data.Data);
        Assert.IsType<PayoutsDict>(result.Data.Payouts);
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

    [Fact]
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
    #endregion
}