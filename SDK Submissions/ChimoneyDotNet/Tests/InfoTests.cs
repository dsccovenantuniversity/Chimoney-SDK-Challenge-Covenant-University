﻿namespace ChimonyDotNet.Test;

public class InfoTests
{
    private readonly IChimoneyBase chimoney = new Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? 
        "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");
    private readonly string success = "success";

    public InfoTests()
    {
        Chimoney.BaseUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";
    }

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
        await Task.Delay(1000);
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
        await Task.Delay(1000);
        var result = await chimoney.GetBankBranches("280");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<BankBranch>>(result.Data);
    }

    [Fact]
    public async Task Get_Supported_Bank_Returns_Success()
    {
        await Task.Delay(1000);
        var result = await chimoney.GetSupportedBanks("NG");
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<Bank>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_Exchange_Rates_Returns_Success()
    {
        await Task.Delay(1000);
        var result = await chimoney.GetExchangeRates();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<Dictionary<string, decimal>>(result.Data);
    }

    [Fact]
    public async Task Get_MobileMoneyCodes_Returns_Success()
    {
        await Task.Delay(1000);
        var result = await chimoney.GetSupportedMobileMoneyCodes();
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<MobileMoneyCode>>(result.Data);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task Get_USD_To_Local_Returns_Success()
    {
        await Task.Delay(1000);
        var result = await chimoney.GetUSDAmountInLocal("NGN", 300m);
        Assert.NotNull(result);
        Assert.Equal(success, result.Status);
        Assert.IsType<USDToLocalConversion>(result.Data);
        Assert.NotEqual(decimal.Zero, result.Data.AmountInDestinationCurrency);
    }

    [Fact]
    public async Task Verify_BankAccounts_Returns_Success()
    {
        await Task.Delay(1000);
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
}
