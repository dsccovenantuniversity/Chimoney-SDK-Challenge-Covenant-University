
using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

/// <summary>
/// Entrypoint for interfacing with Chimoney API
/// </summary>
public partial class Chimoney
{
    public async Task<Response<string[]>> GetSupportedAirtimeCountries()
    {
        var url = BaseAPIUrl + "/info/airtime-countries";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonSerializer.Deserialize<Response<string[]>>(content, serializerOptions);
        return countries ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<BenefitsData>> GetAllAssets()
    {
        var url = BaseAPIUrl + $"/info/assets";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var assetsResponse = JsonSerializer.Deserialize<Response<BenefitsData>>(content, serializerOptions);
        return assetsResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<BenefitsData>> GetAllAssets(string countryCode)
    {
        var url = BaseAPIUrl + $"/info/assets?countryCode={countryCode}";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var assetsResponse = JsonSerializer.Deserialize<Response<BenefitsData>>(content, serializerOptions);
        return assetsResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<ConversionToUSD>> ConvertLocalCurrencyToUSD(string originCurrency, decimal amountInOriginCurrency)
    {
        var url = BaseAPIUrl + $"/info/local-amount-in-usd?originCurrency={originCurrency}" +
            $"&amountInOriginCurrency={amountInOriginCurrency}";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var conversionResponse = JsonSerializer.Deserialize<Response<ConversionToUSD>>(content, serializerOptions);
        return conversionResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<BankBranch>>> GetBankBranches(string bankCode)
    {
        var url = BaseAPIUrl + $"/info/bank-branches?bankCode={bankCode}";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var bankBranches = JsonSerializer.Deserialize<Response<IEnumerable<BankBranch>>>(content, serializerOptions);
        return bankBranches ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<Bank>>> GetSupportedBanks(string countryCode)
    {
        var url = BaseAPIUrl + $"/info/country-banks?countryCode={countryCode}";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var banks = JsonSerializer.Deserialize<Response<IEnumerable<Bank>>>(content, serializerOptions);
        return banks ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<Dictionary<string, decimal>>> GetExchangeRates()
    {
        var url = BaseAPIUrl + $"/info/exchange-rates";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var rates = JsonSerializer.Deserialize<Response<Dictionary<string, decimal>>>(content, serializerOptions);
        return rates ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<MobileMoneyCode>>> GetSupportedMobileMoneyCodes()
    {
        var url = BaseAPIUrl + $"/info/mobile-money-codes";
        var request = SetupRequestObject(HttpMethod.Get, url);


        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var codes = JsonSerializer.Deserialize<Response<IEnumerable<MobileMoneyCode>>>(content, serializerOptions);
        return codes ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<USDToLocalConversion>> GetUSDAmountInLocal(string destinationCurrency, decimal amountInUSD)
    {
        var url = BaseAPIUrl + $"/info/usd-amount-in-local?destinationCurrency={destinationCurrency}" +
            $"&amountInUSD={amountInUSD}";
        var request = SetupRequestObject(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var conversion = JsonSerializer.Deserialize<Response<USDToLocalConversion>>(content, serializerOptions);
        return conversion ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<BankAccount>>> VerifyBankAccounts(IEnumerable<BankAccount> bankAccounts)
    {
        var url = BaseAPIUrl + $"/info/verify-bank-account-number";
        var request = SetupRequestObject(HttpMethod.Post, url);

        //var options = new JsonSerializerOptions()
        //{
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //};
        var json = JsonSerializer.Serialize(new 
        { 
            verifyAccountNumbers = bankAccounts 
        });

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var accounts = JsonSerializer.Deserialize<Response<IEnumerable<BankAccount>>>(content, serializerOptions);
        return accounts ?? throw new NonSerializableResponseException(content);
    }
}
