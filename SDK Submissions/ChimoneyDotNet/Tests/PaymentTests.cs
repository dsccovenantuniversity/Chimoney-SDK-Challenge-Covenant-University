using ChimoneyDotNet.Models;
using ChimoneyDotNet.Models;

namespace ChimonyDotNet.Test;

public class PaymentTests
{
    private readonly IChimoneyBase chimoney = new Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? 
        "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");
    private readonly string success = "success";

    public PaymentTests()
    {
        Chimoney.BaseUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";
    }

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

}
