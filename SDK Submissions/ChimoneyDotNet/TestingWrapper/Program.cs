using ChimoneyDotNet;
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Models.Payout;

var wrapperBase = new Chimoney(Environment.GetEnvironmentVariable("CHIMONEY_API_KEY")!);

//var response = await wrapperBase.Simulate("random_id", Status.Failed);

var request = new ChimoneyTransaction()
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
                  Currency = "currency",
              }
          }
};

var result = await wrapperBase.InitiateChimoneyTransaction(request);
//Console.WriteLine(response.Status);
//Console.WriteLine(response.Error);
//Console.WriteLine(response.Message);
