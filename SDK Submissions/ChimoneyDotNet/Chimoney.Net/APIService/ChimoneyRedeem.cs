using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models.Redeem;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<Response<object>> RedeemAirtimecard(RedeemAirtimeRequest redeemRequest)
    {
        var url = $"{BaseUrl}/redeem/airtime";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(redeemRequest, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<object>> RedeemAny(RedeemAnyRequest redeemRequest)
    {
        var url = $"{BaseUrl}/redeem/any";
        var request = SetupRequestObject(HttpMethod.Post,url);
        request.Content = new StringContent(JsonSerializer.Serialize(redeemRequest, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<object>> RedeemChimoney(RedeemChimoneyRequest redeemRequest)
    {
        var url = $"{BaseUrl}/redeem/any";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(redeemRequest, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<object>> RedeemGiftcard(RedeemGiftcardRequest redeemRequest)
    {
        var url = $"{BaseUrl}/redeem/any";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(redeemRequest, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<object>> RedeemMobileMoney(RedeemMobileMoneyRequest redeemRequest)
    {
        var url = $"{BaseUrl}/redeem/any";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(redeemRequest, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }
}
