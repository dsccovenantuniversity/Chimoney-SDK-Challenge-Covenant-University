
using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<Response<IEnumerable<Wallet>>> ListAssociatedWallets(string? subAccount = null)
    {
        var url = $"{_baseUrl}/wallets/list";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(new { subAccount },serializerOptions), 
            Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<IEnumerable<Wallet>>>(content, serializerOptions);
        return result ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<Wallet>> GetSingleWallet(string walletID, string? subAccount = null)
    {
        var url = $"{_baseUrl}/wallets/lookup";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(new {walletID, subAccount },serializerOptions),
            Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<Wallet>>(content, serializerOptions);
        return result ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<object>> TransferBetweenWallets(string receiverId, decimal valueInUSD, string? wallet = null, string? subAccount = null)
    {
        var url = $"{_baseUrl}/wallets/transfer";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(new { 
            subAccount, 
            receiver = receiverId,
            wallet,
            valueInUSD
            }, serializerOptions),
            Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<object>>(content, serializerOptions);
        return result ?? throw new NonSerializableResponseException(content);
    }
}
