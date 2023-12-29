
using Newtonsoft.Json;

/// <summary>
/// Implementation of the contact repository responsible for data storage and retrieval.
/// </summary>
public class ContactRepository : IContactRepository
{
    private const string FilePath = "contacts.json";

    /// <summary>
    /// Retrieves all contacts from the storage file.
    /// </summary>
    /// <returns>A list of contacts.</returns>
    public List<IContact> GetAllContacts()
    {
        List<IContact> contacts;

        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);

            // Deserialize to List<Contact> instead of List<IContact>
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json).Cast<IContact>().ToList();
        }
        else
        {
            contacts = new List<IContact>();
        }

        return contacts;
    }
    /// <summary>
    /// Saves the provided list of contacts to the storage file.
    /// </summary>
    /// <param name="contacts">The list of contacts to be saved.</param>
    public void SaveContacts(List<IContact> contacts)
    {
        string json = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }

    /// <summary>
    /// Removes a contact from the storage file based on the provided email address.
    /// </summary>
    /// <param name="email">The email address of the contact to be removed.</param>
    public void RemoveContact(string email)
    {
        List<IContact> contacts = GetAllContacts();
        IContact contactToRemove = contacts.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            SaveContacts(contacts);
        }
    }
}