
namespace ChimoneyDotNet.Exceptions;

/// <summary>
/// Exception for API calls returning an unexpected value
/// </summary>
public class NonSerializableResponseException : Exception
{
    public NonSerializableResponseException(string message) : base(message)
    {
    }
}
