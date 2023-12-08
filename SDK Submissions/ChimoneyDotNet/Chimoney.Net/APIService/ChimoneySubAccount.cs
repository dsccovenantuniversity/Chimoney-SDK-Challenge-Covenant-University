using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models.SubAccount;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<Response<SubAccount>> CreateSubAccount(CreateSubAccountRequest subAccount)
    {
        var url  = $"{BaseUrl}/sub-account/create";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(subAccount, serializerOptions),
                       Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var subAccountResponse = JsonSerializer.Deserialize<Response<SubAccount>>(result, serializerOptions);
        return subAccountResponse ?? throw new NonSerializableResponseException(result);

    }

    public async Task<Response<object>> UpdateSubAccount(UpdateSubAccount updateSubAccount)
    {
        var url = $"{BaseUrl}/sub-account/update";
        var request = SetupRequestObject(HttpMethod.Post, url);
        request.Content = new StringContent(JsonSerializer.Serialize(updateSubAccount, serializerOptions),
                       Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var subAccountResponse = JsonSerializer.Deserialize<Response<object>>(result, serializerOptions);
        return subAccountResponse ?? throw new NonSerializableResponseException(result);
    }

    public async Task<Response<object>> DeleteSubAccount(string subAccountId)
    {
        var url = $"{BaseUrl}/sub-account/delete?id={subAccountId}";
        var request = SetupRequestObject(HttpMethod.Delete, url);

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        var subAccountResponse = JsonSerializer.Deserialize<Response<object>>(result, serializerOptions);
        return subAccountResponse ?? throw new NonSerializableResponseException(result);
    }

    public async Task<Response<SubAccount>> GetSubAccount(string subAccountId)
    {
        var url = $"{BaseUrl}/sub-account/get?id={subAccountId}";
        var request = SetupRequestObject(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        var subAccountResponse = JsonSerializer.Deserialize<Response<SubAccount>>(result, serializerOptions);
        return subAccountResponse ?? throw new NonSerializableResponseException(result);
    }

    public async Task<Response<IEnumerable<SubAccount>>> GetAllSubAccounts()
    {
        var url = $"{BaseUrl}/sub-account/list";
        var request = SetupRequestObject(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        var subAccountResponse = JsonSerializer.Deserialize<Response<IEnumerable<SubAccount>>>(result, serializerOptions);
        return subAccountResponse ?? throw new NonSerializableResponseException(result);
    }
}
