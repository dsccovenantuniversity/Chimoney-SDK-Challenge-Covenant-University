
namespace ChimonyDotNet.Test;

public class RedeemTest
{
    private readonly IChimoneyBase chimoney = new Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? 
        "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");
    private readonly string error = "error";

    public RedeemTest()
    {
        Chimoney.BaseUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";
    }

    [Fact]
    public async Task RedeemAirtime_Returns_ValidResponse()
    {
        var result = await chimoney.RedeemAirtimecard(new RedeemAirtimeRequest()
        {
            ChiRef = "1234567890",
            CountryToSend = "Nigeria",
            PhoneNumber = "+2348123456789",
        });

        Assert.Equal(error, result.Status);
        Assert.Equal("no transaction found for chiRef 1234567890", result.Error);
    }

    [Fact]
    public async Task RedeemAny_Returns_ValidResponse()
    {
        var result = await chimoney.RedeemAny(new RedeemAnyRequest()
        {
            ChiRef = "1234567890",
            RedeemData = new()
        {
            {"id", "1234567890" },
            {"value", "1234567890" }
        },
        });

        Assert.Equal(error, result.Status);
        Assert.Equal("no transaction found for chiRef 1234567890", result.Error);
    }

    [Fact]
    public async Task RedeemChimoney_Returns_ValidResponse()
    {
        var result = await chimoney.RedeemChimoney(new RedeemChimoneyRequest()
        {
            ChiRef = "1234567890",
            TurnOffNotification = false,
            Chimoneys = new()
        {
            new ()
            {
                {"id", "1234567890" },
                {"value", "1234567890" }
            }
        }
        });

        Assert.Equal(error, result.Status);
        Assert.Equal("no transaction found for chiRef 1234567890", result.Error);
    }

    [Fact]
    public async Task RedeemGiftcardReturns_ValidResponse()
    {
        var result = await chimoney.RedeemGiftcard(new RedeemGiftcardRequest()
        {
            ChiRef = "1234567890",
            Meta = new()
        {
            {"id",13232 }
        },
            RedeemOptions = new()
        {
            {"id", "1234567890" },
            {"value", "1234567890" }
        },
        });

        Assert.Equal(error, result.Status);
        Assert.Equal("no transaction found for chiRef 1234567890", result.Error);
    }

    [Fact]
    public async Task RedeemMobileMoneyReturns_ValidResponse()
    {
        var result = await chimoney.RedeemMobileMoney(new RedeemMobileMoneyRequest()
        {
            ChiRef = "1234567890",
            Meta = new()
        {
            {"id",13232 }
        },
            RedeemOptions = new()
        {
            {"id", "1234567890" },
            {"value", "1234567890" }
        },
        });

        Assert.Equal(error, result.Status);
        Assert.Equal("no transaction found for chiRef 1234567890", result.Error);
    }


}
