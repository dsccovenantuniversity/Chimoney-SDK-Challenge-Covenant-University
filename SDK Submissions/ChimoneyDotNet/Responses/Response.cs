namespace ChimoneyDotNet.Responses;

/// <summary>
/// Base Response Class. Has a string data field that gets overidden by responses that inherit from it.
/// This is used in error handling to pass information from the Chimoney API
/// </summary>
public class Response<T>
{
    public string Status { get; set; }
    public string? Error { get; set; }
    public T Data { get; set; }
}
