using ChimoneyDotNet;
using ChimoneyDotNet.Models.Payout;

var wrapperBase = new Chimoney("88cd4465f56b3132c385303ca1fd4950c6896eee96304f4dd46513aebff5bcde");

//var response = await wrapperBase.Simulate("random_id", Status.Failed);

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

var result = await wrapperBase.PayoutToChimoneyWallet(payoutRequest);
//Console.WriteLine(response.Status);
//Console.WriteLine(response.Error);
//Console.WriteLine(response.Message);
