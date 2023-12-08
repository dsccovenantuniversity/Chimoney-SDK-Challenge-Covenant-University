![Tests](https://github.com/gearhead041/Chimoney-SDK-Challenge-Covenant-University/actions/workflows/dotnet.yml/badge.svg)

This is the Chimoney SDK for .NET. It is a library that allows you to easily integrate Chimoney into your .NET applications.

## Intsallation Guide

In your .NET project, run the following command in the terminal:
```
dotnet add package ChimoneyDotNet --version 1.0.0
```

## Usage Examples
```Csharp
using ChimoneyDotNet;

var chimoney = new Chimoney("your_api_key");

// Get supported banks
var banks = chimoney.GetSupportedBanks();

```

- [x] Proper Coding Standards and Conventions
- [ ] Proper Skeleton Structure
- [ ] Readme Doc (Demo,Installation Guide, Usage Examples)
- [x] Error Handling
- [x] Tests

