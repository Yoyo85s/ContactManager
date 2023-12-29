
/// <summary>
/// Implementation of the IContact interface representing a contact.
/// </summary>

public class Contact : IContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}