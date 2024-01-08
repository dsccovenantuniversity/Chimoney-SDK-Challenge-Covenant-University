
namespace ChimonyDotNet.Test;
public class AccountTests
{
    private readonly Chimoney chimoney = new(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? 
        "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");

    private readonly string success = "success";
    private readonly string error = "error";

    public AccountTests()
    {
        Chimoney.BaseUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";
    }

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
}