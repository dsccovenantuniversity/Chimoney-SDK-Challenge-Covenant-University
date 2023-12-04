using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{

    public async Task<Response<TransferDetail>> AccountTransfer(AccountTransfer accountTransfer)
    {
        string url = BaseAPIUrl + "/accounts/transfer";
        var request = SetupRequestObject(HttpMethod.Post, url);
        string json;
        if (accountTransfer.SubAccount == null)
        {
            var dataObject = new
            {
                receiver = accountTransfer.ReceiverId,
                valueInUSD = accountTransfer.ValueInUSD,
                wallet = accountTransfer.WalletType,
            };
            json = JsonSerializer.Serialize(dataObject);
        }
        else
        {
            var dataObject = new
            {
                receiver = accountTransfer.ReceiverId,
                valueInUSD = accountTransfer.ValueInUSD,
                wallet = accountTransfer.WalletType,
                subAccount = accountTransfer.SubAccount,
            };
            json = JsonSerializer.Serialize(dataObject);
        }
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpClient _httpClient = new();
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var transferResponse = JsonSerializer.Deserialize<Response<TransferDetail>>(content, serializerOptions);

        return transferResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<Transaction>> DeleteTransfer(string chiRef)
    {
        string url = BaseAPIUrl + $"/accounts/delete-unpaid-transaction?chiRef={chiRef}";
        var request = SetupRequestObject(HttpMethod.Delete, url);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var deleteResponse = JsonSerializer.Deserialize<Response<Transaction>>
            (content, serializerOptions);

        return deleteResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<Transaction>> DeleteTransfer(string chiRef, string subAccount)
    {
        string url = BaseAPIUrl + "/accounts/delete-unpaid-transaction";
        url += $"?chiRef={chiRef}&subAccount={subAccount}";
        var request = SetupRequestObject(HttpMethod.Delete, url);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var deleteResponse = JsonSerializer.Deserialize<Response<Transaction>>
            (content, serializerOptions);

        return deleteResponse ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<TransactionDetail>>> GetAllTransactionsByAccount(string subAccount)
    {
        string url = BaseAPIUrl + "accounts/transactions";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var json = JsonSerializer.Serialize(new
        {
            subAccount
        });
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var transactions = JsonSerializer.Deserialize<Response<IEnumerable<TransactionDetail>>>(content, serializerOptions);

        return transactions ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<IEnumerable<TransactionDetail>>> GetAllTransactionsByAccount()
    {
        string url = BaseAPIUrl + "accounts/transactions";
        var request = SetupRequestObject(HttpMethod.Post, url);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var transactions = JsonSerializer.Deserialize<Response<IEnumerable<TransactionDetail>>>(content, serializerOptions);

        return transactions ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<TransactionDetail>> GetSingleTransactionDetail(string id)
    {
        string url = BaseAPIUrl + "accounts/transaction";
        url += $"?id={id}";
        var request = SetupRequestObject(HttpMethod.Post, url);

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        //HACK weird behaviour here
        // the api can return a response like
        // "data" : { "error message"}
        // causing deserialization to fail
        //Easy fix is including try catch on all such methods. *sigh*
        try
        {
            var transaction = JsonSerializer.Deserialize<Response<TransactionDetail>>(content, serializerOptions);
            return transaction ?? throw new NonSerializableResponseException(content);
        }
        catch (JsonException)
        {

            var errorResponse = JsonSerializer.Deserialize<Response<string>>(content, serializerOptions)
                ?? throw new NonSerializableResponseException(content);
            var transaction = new Response<TransactionDetail>()
            {
                Status = errorResponse.Status,
                //get error message in data field
                Error = errorResponse.Data
            };

            return transaction;
        }
    }

    public async Task<Response<TransactionDetail>> GetSingleTransactionDetail(string id, string subAccount)
    {
        string url = BaseAPIUrl + "accounts/transaction";
        url += $"?id={id}";
        var request = SetupRequestObject(HttpMethod.Post, url);

        var json = JsonSerializer.Serialize(new
        {
            subAccount
        });
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        var transaction = JsonSerializer.Deserialize<Response<TransactionDetail>>(content, serializerOptions);
        return transaction ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<TransactionDetail>> GetTransactionDetailByIssueId(string issueId)
    {
        string url = BaseAPIUrl + $"accounts/issue-id-transactions?issueID={issueId}";
        var request = SetupRequestObject(HttpMethod.Post, url);

        var json = JsonSerializer.Serialize(new
        {
            issueId
        });
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var transaction = JsonSerializer.Deserialize<Response<TransactionDetail>>(content, serializerOptions);
        return transaction ?? throw new NonSerializableResponseException(content);
    }

    public async Task<Response<TransactionDetail>> GetTransactionDetailByIssueId(string issueId, string subAccount)
    {
        string url = BaseAPIUrl + "accounts/issue-id-transactions";
        url += $"?issueID={issueId}";
        var request = SetupRequestObject(HttpMethod.Post, url);

        var json = JsonSerializer.Serialize(new
        {
            subAccount
        });
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var transaction = JsonSerializer.Deserialize<Response<TransactionDetail>>(content, serializerOptions);
        return transaction ?? throw new NonSerializableResponseException(content);
    }

}
