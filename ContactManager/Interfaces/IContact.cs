
/// <summary>
/// Interface defining the properties of a contact.
/// </summary>
public interface IContact
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; }
}
