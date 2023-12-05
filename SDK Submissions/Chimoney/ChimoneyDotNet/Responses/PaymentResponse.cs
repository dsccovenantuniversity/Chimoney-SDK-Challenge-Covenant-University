
namespace ChimoneyDotNet.Responses;

public class PaymentResponse<T> : Response<T>
{
    public string Message { get; set; }
}
