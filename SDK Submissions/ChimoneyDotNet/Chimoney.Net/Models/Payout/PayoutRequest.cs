
namespace ChimoneyDotNet.Models.Payout;

/// <summary>
/// Represents a request to make a payout
/// </summary>
/// <typeparam name="T"></typeparam>
public class PayoutRequest<T>
{
    /// <summary>
    /// Subaccount if any
    /// </summary>
    public string? SubAccount { get; set; } = null;
    public bool TurnOffNotification { get; set; }

    /// <summary>
    /// Changes the json name of the prperty to that of the class
    /// Serializes the property as a json array
    /// Field naming to be consistent with the API
    /// </summary>
    public IEnumerable<T> Data { get; set; }
}
