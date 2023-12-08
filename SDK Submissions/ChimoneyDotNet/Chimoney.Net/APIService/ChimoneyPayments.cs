
using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<PaymentResponse<PaymentInfo>> InitiatePaymentRequest(PaymentRequest paymentRequest)
    {
        var url = $"{BaseUrl}/payment/initiate";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(paymentRequest, serializerOptions),
            Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<PaymentResponse<PaymentInfo>>(content, serializerOptions);
        return result ?? throw new NonSerializableResponseException(content);
    }



    public async Task<PaymentResponse<PaymentVerification>> VerifyPayment(string transactionId, string? subAccount = null)
    {
        var url = $"{BaseUrl}/payment/verify";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(new
        {
            id = transactionId,
            subAccount
        }, serializerOptions), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        try
        {
            var result = JsonSerializer.Deserialize<PaymentResponse<PaymentVerification>>(content, serializerOptions);
            return result ?? throw new NonSerializableResponseException(content);
        }
        catch (JsonException)
        {
            var result = JsonSerializer.Deserialize<PaymentResponse<string[]>>(content, serializerOptions);
            var verification = new PaymentResponse<PaymentVerification>()
            {
                Status = result!.Status,
                Message = result.Message,
                Data = new()
            };
            return verification ?? throw new NonSerializableResponseException(content);
        }
    }

    public async Task<PaymentResponse<PaymentVerification>> Simulate(string issueID, string status, string? subAccount = null)
    {
        var url = $"{BaseUrl}/payment/simulate";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var json = JsonSerializer.Serialize(new
        {
            issueID,
            status,
            subAccount
        }, serializerOptions);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<PaymentResponse<PaymentVerification>>(content, serializerOptions);
        return result ?? throw new NonSerializableResponseException(content);
    }
}
