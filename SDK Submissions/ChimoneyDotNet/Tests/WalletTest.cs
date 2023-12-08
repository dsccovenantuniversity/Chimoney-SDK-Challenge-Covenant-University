
using ChimoneyDotNet.Models;

namespace ChimonyDotNet.Test;

public class WalletTest
{
    private readonly IChimoneyBase chimoney = new
    Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY") ?? "3b890bee5f1ef80b399542a6ec62bb8748708f81f198768be11e37055ae01d55");
    //TODO : Replace with your API key from ENV or config file
    private readonly string success = "success";
    private readonly string error = "error";

    [Fact]
    public async Task ListWallets_Returns_Success()
    {
        var result = await chimoney.ListAssociatedWallets();
        Assert.Equal(success, result.Status);
        Assert.IsAssignableFrom<IEnumerable<Wallet>>(result.Data);
    }

    [Fact]
    public async Task GetSingleWallet_Returns_Sucess()
    {
        var wallets = await chimoney.ListAssociatedWallets();
        var walletID = wallets.Data.First().Id;
        var result = await chimoney.GetSingleWallet(walletID);
        Assert.Equal(success, result.Status);
        Assert.IsType<Wallet>(result.Data);
    }

    [Fact]
    public async Task TransferBetweenWallets_Returns_Valid_Response()
    {
        var wallets = await chimoney.ListAssociatedWallets();
        var receiverID = wallets.Data.First().Owner;
        var result = await chimoney.TransferBetweenWallets(receiverID, 200);
        Assert.Equal(error, result.Status);
        Assert.Equal("Cannot send. Sender is the same Receiver pA3oQQ56ikcpFdPonr2fA83FEDJ3", result.Error);
    }
}
