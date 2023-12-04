using ChimoneyDotNet;
using ChimoneyDotNet.Models;

var wrapperBase = new Chimoney("d3cd6f0247c5f4f7b398def389138b132a05e6443884f56b2fae3ed21e4ea47c");

var accounts = new List<BankAccount>()
        {
            new()
            {
                CountryCode = "NG",
                Account_Bank = "044",
                Account_Number = "0690000032"
            }
        };

var response = await wrapperBase.VerifyBankAccounts(accounts);

Console.WriteLine(response.Status);
Console.WriteLine(response.Error);
