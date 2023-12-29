
public interface IContactRepository
{
    /// <summary>
    /// Retrieves all contacts from the storage.
    /// </summary>
    /// <returns>A list of contacts.</returns>
    List<IContact> GetAllContacts();

    /// <summary>
    /// Saves the provided list of contacts to the storage.
    /// </summary>
    /// <param name="contacts">The list of contacts to be saved.</param>
    void SaveContacts(List<IContact> contacts);
}
