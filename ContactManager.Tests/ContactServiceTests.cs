// ContactServiceTests.cs
using System.Collections.Generic;
using Xunit;

public class ContactServiceTests
{
    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange
        var contactRepository = new ContactRepository();
        var contactService = new ContactService(contactRepository);

        // Clear existing contacts (for a clean environment)
        List<IContact> existingContacts = contactRepository.GetAllContacts();
        existingContacts.ForEach(contact => contactRepository.RemoveContact(contact.Email));

        // Act
        contactService.AddContact(new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" });

        // Assert
        List<IContact> contacts = contactRepository.GetAllContacts();

        // Debugging information
        Console.WriteLine("Number of contacts: " + contacts.Count);
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.Email}");
        }

        Assert.Single(contacts); // Assuming the repository is initially empty
        Assert.Equal("John", contacts[0].FirstName);
        Assert.Equal("Doe", contacts[0].LastName);
    }

    [Fact]
    public void RemoveContact_ShouldRemoveContactFromList()
    {
        // Arrange
        var contactRepository = new ContactRepository();
        var contactService = new ContactService(contactRepository);

        // Clear existing contacts (for a clean environment)
        List<IContact> existingContacts = contactRepository.GetAllContacts();
        existingContacts.ForEach(contact => contactRepository.RemoveContact(contact.Email));

        // Add a contact for testing
        contactService.AddContact(new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" });

        // Act
        contactService.RemoveContact("john.doe@example.com");

        // Assert
        List<IContact> contacts = contactRepository.GetAllContacts();

        // Debugging information
        Console.WriteLine("Number of contacts: " + contacts.Count);
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.Email}");
        }

        Assert.Empty(contacts); // Expecting an empty list after removal
    }

    [Fact]
    public void DisplayAllContacts_ShouldDisplayAllContacts()
    {
        // Arrange
        var contactRepository = new ContactRepository();
        var contactService = new ContactService(contactRepository);

        // Add contacts for testing
        contactService.AddContact(new Contact { FirstName = "Alice", LastName = "Smith", Email = "alice.smith@example.com" });
        contactService.AddContact(new Contact { FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com" });

        // Act
        contactService.DisplayAllContacts();

        // Assert (Output should be verified visually or using a mocking framework)
    }

    [Fact]
    public void DisplayContactDetails_ShouldDisplayContactDetails()
    {
        // Arrange
        var contactRepository = new ContactRepository();
        var contactService = new ContactService(contactRepository);

        // Add a contact for testing
        contactService.AddContact(new Contact { FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com" });

        // Act
        contactService.DisplayContactDetails("charlie.brown@example.com");

        // Assert (Output should be verified visually or using a mocking framework)
    }
}