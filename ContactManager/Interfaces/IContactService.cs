
public interface IContactService
{
    void AddContact(IContact contact);
    void RemoveContact(string email);
    void DisplayAllContacts();
    void DisplayContactDetails(string email);
}
