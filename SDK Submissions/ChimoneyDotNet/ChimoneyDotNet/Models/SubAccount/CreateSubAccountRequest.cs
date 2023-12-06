namespace ChimoneyDotNet.Models.SubAccount;

public class CreateSubAccountRequest
{
    public string Name { get; set; }
    /// <summary>
    /// Email of the user
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// First name of the user
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Last name of the user
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// phone number with country code
    /// </summary>
    public string PhoneNumber { get; set; }
}
