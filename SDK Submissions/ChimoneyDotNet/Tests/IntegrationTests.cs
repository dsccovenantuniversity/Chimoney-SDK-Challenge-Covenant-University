using ChimoneyDotNet.Models;
using ChimoneyDotNet.Models.Info;
using ChimoneyDotNet.Models.Payment;

namespace ChimoneyTests;
public class IntegrationTests
{
    private readonly IChimoneyBase chimoneyWrapper = new
        Chimoney("d3cd6f0247c5f4f7b398def389138b132a05e6443884f56b2fae3ed21e4ea47c");
    private readonly string success = "success";
    private readonly string error = "error";

    #region Account

    [Fact]
    public async Task Get_Transactions_By_Account_Returns_Success()
    {
        var result = await chimoneyWrapper.GetAllTransactionsByAccount();
        Assert.Equal(success, result.Status);
    }

    [Fact]
    public async Task Get_Single_Transaction_Detail_Returns_Success_And_Error()
    {
        var resultOnlyId = await chimoneyWrapper.GetSingleTransactionDetail("random_id");
        Assert.NotNull(resultOnlyId);
        Assert.Equal(success, resultOnlyId.Status);
        Assert.Equal("not found for that id", resultOnlyId.Error);

        var resultWithSubAccount = await chimoneyWrapper.GetSingleTransactionDetail("random_id", "subaccount_id");
        Assert.NotNull(resultWithSubAccount);
        Assert.Equal(error, resultWithSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultWithSubAccount.Error);
    }

    [Fact]
    public async Task Get_Transaction_Detail_By_IssueId_Returns_Error()
    {
        var resultOnlyId = await chimoneyWrapper.GetTransactionDetailByIssueId("random_id");
        Assert.NotNull(resultOnlyId);
        Assert.Equal(success, resultOnlyId.Status);

        var resultWithSubAccount = await chimoneyWrapper.GetTransactionDetailByIssueId("random_id", "1234567");
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

        var result = await chimoneyWrapper.AccountTransfer(accountTransfer);
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
        var resultSubAccount = await chimoneyWrapper.AccountTransfer(accountTransferSubaccount);
        Assert.NotNull(resultSubAccount);
        Assert.Equal(error, resultSubAccount.Status);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Error);
    }

    [Fact]
    public async Task Delete_Transfer_Returns_Error()
    {
        var result = await chimoneyWrapper.DeleteTransfer("9ae90e01-6689-453c-b4af-8ae230fafc5a");
        Assert.NotNull(result);
        Assert.Equal(error, result.Status);
        Assert.Equal("Cannot delete as you're not the owner", result.Error);

        var resultSubAccount = await chimoneyWrapper
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
        var result = await chimoneyWrapper.GetSupportedAirtimeCountries();
        Assert.NotNull(result);
        Assert.Null(result.Error);
        Assert.Equal(success, result.Status);
        Assert.IsType<string[]>(result.Data);
    }

    [Fact]
    public async Task Get_All_Assets_Returns_Success()
    {
        var result = await chimoneyWrapper.GetAllAssets();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<BenefitsData>(result.Data);

        var resultCountryCode = await chimoneyWrapper.GetAllAssets("NG");
        Assert.NotNull(resultCountryCode);
        Assert.Equal(success, resultCountryCode.Status);
        Assert.IsType<BenefitsData>(resultCountryCode.Data);
    }

    [Fact]
    public async Task Convert_Local_To_USD_Returns_Sucess()
    {
        var result = await chimoneyWrapper.ConvertLocalCurrencyToUSD("NGN", 300m);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<ConversionToUSD>(result.Data);
        Assert.IsType<decimal>(result.Data.AmountInUSD);
        Assert.NotEqual(decimal.Zero, result.Data.AmountInUSD);
    }

    [Fact]
    public async Task Get_Bank_Branches_Returns_Success()
    {
        var result = await chimoneyWrapper.GetBankBranches("280");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<BankBranch>>(result.Data);
    }

    [Fact]
    public async Task Get_Supported_Bank_Returns_Success()
    {
        var result = await chimoneyWrapper.GetSupportedBanks("NG");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<Bank>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_Exchange_Rates_Returns_Success()
    {
        var result = await chimoneyWrapper.GetExchangeRates();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<Dictionary<string, decimal>>(result.Data);
    }

    [Fact]
    public async Task Get_MobileMoneyCodes_Returns_Success()
    {
        var result = await chimoneyWrapper.GetSupportedMobileMoneyCodes();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<MobileMoneyCode>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_USD_To_Local_Returns_Success()
    {
        var result = await chimoneyWrapper.GetUSDAmountInLocal("NGN", 300m);
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


        var result = await chimoneyWrapper.VerifyBankAccounts(accounts);
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

        var result = await chimoneyWrapper.InitiatePaymentRequest(paymentRequest);
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

        var resultSubAccount = await chimoneyWrapper.InitiatePaymentRequest(paymentRequestSubAccount);
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }


    [Fact]
    public async Task Verify_Payment_Returns_Success()
    {
        var result = await chimoneyWrapper.VerifyPayment("random_id");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);

        var resultSubAccount = await chimoneyWrapper.VerifyPayment("random_id", "random_id");
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }

    [Fact]
    public async Task Simulate_Payment_Returns_Messsage()
    {
        var result = await chimoneyWrapper.Simulate("random_id", Status.Failed);
        Assert.NotNull(result);
        Assert.Equal("Cannot change status to failed", result.Message);

        var resultSubAccount = await chimoneyWrapper.Simulate("random_id", Status.Failed, "random_id");
        Assert.NotNull(resultSubAccount);
        Assert.Equal("sender must be a valid Chimoney user ID", resultSubAccount.Message);
    }
    #endregion
}