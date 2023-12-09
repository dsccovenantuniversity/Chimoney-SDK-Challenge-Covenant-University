![Tests](https://github.com/gearhead041/Chimoney-SDK-Challenge-Covenant-University/actions/workflows/dotnet.yml/badge.svg)

![Nuget](https://img.shields.io/nuget/dt/ChimoneyDotNet)

This is the Chimoney SDK for .NET. It is a library that allows you to easily integrate Chimoney into your .NET applications.

## Intallation Guide

In your .NET project, run the following command in the terminal:
```
dotnet add package ChimoneyDotNet
```

## Usage Examples
```Csharp
using ChimoneyDotNet;
var chimoney = new Chimoney("your_api_key");

// Get supported banks
var banks = chimoney.GetSupportedBanks();

//Make an account transfer
using ChimoneyDotNet.Models;

var account  = new AccountTransfer()
{
  ChiRef = "1234567890",
  ReceiverId = "1234567890",
  ValueInUSD = 100,
  WalletType = "NGN",

}
var transfer = chimoney.AccountTransfer(account);

```



- [x] Proper Coding Standards and Conventions
- [ ] Proper Skeleton Structure
- [x] Readme Doc (Demo,Installation Guide, Usage Examples)
- [x] Error Handling
- [x] Tests

