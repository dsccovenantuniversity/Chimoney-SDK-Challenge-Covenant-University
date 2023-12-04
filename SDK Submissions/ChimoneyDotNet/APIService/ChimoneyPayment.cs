
using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;

namespace ChimoneyDotNet;

public partial class Chimoney
{
    public Task<Response<PaymentInfo>> InitiatePaymentRequest(PaymentRequest paymentRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PaymentVerification>> VerifyPayment(string transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PaymentVerification>> VerifyPayment(string transactionId, string? subAccount = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PaymentVerification>> Simulate(string issueId, string status)
    {
        throw new NotImplementedException();
    }

    public Task<Response<PaymentVerification>> Simulate(string issueId, string status, string? subAccount = null)
    {
        throw new NotImplementedException();
    }
}
