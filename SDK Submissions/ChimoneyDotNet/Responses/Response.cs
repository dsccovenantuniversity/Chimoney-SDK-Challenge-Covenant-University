namespace ChimoneyDotNet.Responses;

/// <summary>
/// Base Response Class.
/// </summary>
public class Response<T>
{
    public string Status { get; set; }
    public string? Error { get; set; }
    public T Data { get; set; }
}
