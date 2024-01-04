
namespace ChimoneyDotNet.Models;

public class UpdateSubAccount
{
    public string Id { get; set; }
    public Dictionary<string,object> Meta { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
