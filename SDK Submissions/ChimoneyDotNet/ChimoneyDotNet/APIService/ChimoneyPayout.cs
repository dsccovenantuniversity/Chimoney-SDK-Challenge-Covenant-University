using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models.Payout;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<Response<PayoutResult<Payout>>> PayoutAirtime(PayoutRequest<AirtimePayout> airtimePayoutRequest)
    {
        var url = $"{_baseUrl}/payouts/airtime";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = airtimePayoutRequest.SubAccount,
            turnOffNotification = airtimePayoutRequest.TurnOffNotification,
            airtimes = airtimePayoutRequest.Data
        };

        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
            Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<Payout>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<List<Payout>>>> PayoutToBank(PayoutRequest<BankPayout> bankPayout)
    {
        var url = $"{_baseUrl}/payouts/bank";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = bankPayout.SubAccount,
            turnOffNotification = bankPayout.TurnOffNotification,
            banks = bankPayout.Data
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<List<Payout>>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<PayoutsDict>>> PayoutChimoney(PayoutRequest<ChimoneyPayout> chimoneyPayout)
    {
        var url = $"{_baseUrl}/payouts/chimoney";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = chimoneyPayout.SubAccount,
            turnOffNotification = chimoneyPayout.TurnOffNotification,
            chimoneys = chimoneyPayout.Data
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
            Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<PayoutsDict>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException(responseString);
    }

    public async Task<Response<PayoutResult<Payout>>> PayoutToChimoneyWallet(PayoutRequest<ChimoneyWalletPayout> chimoneyWalletPayout)
    {
        var urls = $"{_baseUrl}/payouts/wallet";
        var request = SetupRequestObject(HttpMethod.Post, urls);
        var data = new
        {
            subAccount = chimoneyWalletPayout.SubAccount,
            turnOffNotification = chimoneyWalletPayout.TurnOffNotification,
            wallets = chimoneyWalletPayout.Data
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                       Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<Payout>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<Payout>>> PayoutToInterledgerWallet(PayoutRequest<InterledgerWalletPayout> interledgerWalletPayout)
    {
        var url = $"{_baseUrl}/payouts/interledger-wallet-address";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = interledgerWalletPayout.SubAccount,
            turnOffNotification = interledgerWalletPayout.TurnOffNotification,
            interledgerWallets = interledgerWalletPayout.Data
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                                  Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<Payout>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<Payout>>> PayoutGiftcards(PayoutRequest<GiftcardPayout> giftcardPayout)
    {
        var url = $"{_baseUrl}/payouts/gift-card";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = giftcardPayout.SubAccount,
            turnOffNotification = giftcardPayout.TurnOffNotification,
            giftcards = giftcardPayout.Data
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                                             Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<Payout>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<List<Payout>>>> PayoutMobileMoney(PayoutRequest<MobileMoneyPayout> mobileMoneyPayout)
    {
        var url = $"{_baseUrl}/payouts/mobile-money";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount = mobileMoneyPayout.SubAccount,
            turnOffNotification = mobileMoneyPayout.TurnOffNotification,
            momos = mobileMoneyPayout.Data
        };

        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                                     Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<List<Payout>>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<ChimoneyResult>> CheckPayoutStatus(string chiRef, string? subAccount = null)
    {
        var url = $"{_baseUrl}/payouts/status";
        var request = SetupRequestObject(HttpMethod.Post, url);
        var data = new
        {
            subAccount,
            chiRef
        };
        request.Content = new StringContent(JsonSerializer.Serialize(data, serializerOptions),
                             Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<ChimoneyResult>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }

    public async Task<Response<PayoutResult<Payout>>> InitiateChimoneyTransaction(ChimoneyTransaction chimoneyTransaction)
    {
        var url = $"{_baseUrl}/payouts/initiate-chimoney";
        var request = SetupRequestObject(HttpMethod.Post, url);

        request.Content = new StringContent(JsonSerializer.Serialize(chimoneyTransaction, serializerOptions),
                             Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Response<PayoutResult<Payout>>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException($"Error deserializing response\n {responseString}");
    }
}
