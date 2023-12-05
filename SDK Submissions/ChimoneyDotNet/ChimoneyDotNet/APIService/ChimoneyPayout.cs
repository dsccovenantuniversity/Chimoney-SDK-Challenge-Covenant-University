
using ChimoneyDotNet.Exceptions;
using ChimoneyDotNet.Models.Payout;
using ChimoneyDotNet.Responses;
using System.Text;
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public async Task<Response<PayoutResult>> PayoutAirtime(PayoutRequest<AirtimePayout> airtimePayoutRequest)
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
        var result = JsonSerializer.Deserialize<Response<PayoutResult>>(responseString, serializerOptions);
        return result ?? throw new NonSerializableResponseException("Error deserializing response");
    }

    public Task<Response<PayoutResult>> PayoutToBank(PayoutRequest<BankPayout> bankPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> PayoutChimoney(PayoutRequest<ChimoneyPayout> chimoneyPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> PayoutToChimoneyWallet(PayoutRequest<ChimoneyWalletPayout> chimoneyWalletPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> PayoutToInterledgerWallet(PayoutRequest<InterledgerWalletPayout> interledgerWalletPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> PayoutGiftcards(PayoutRequest<GiftcardPayout> giftcardPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> PayoutMobileMoney(PayoutRequest<MobileMoneyPayout> mobileMoneyPayout)
    {
        throw new NotImplementedException();
    }

    public Task<Response<ChimoneyResult>> CheckPayoutStatus(string chiRef, string? subAccount = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PayoutResult>> InitiateChimoneyTransaction(ChimoneyTransaction chimoneyTransaction)
    {
        throw new NotImplementedException();
    }
}
