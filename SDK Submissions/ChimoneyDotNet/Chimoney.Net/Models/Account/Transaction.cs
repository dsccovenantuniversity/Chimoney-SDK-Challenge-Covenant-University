namespace ChimoneyDotNet.Models.Account;

/// <summary>
/// Base transaction model
/// </summary>
public class Transaction
{
    public string Id { get; set; }
    public string IssueDate { get; set; }
    public string IssueId { get; set; }
    /// <summary>
    /// Transaction Reference
    /// </summary>
    public string ChiRef { get; set; }
    public string Status { get; set; }
    public string Issuer { get; set; }
}
