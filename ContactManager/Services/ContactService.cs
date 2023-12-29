using System;
using System.Collections.Generic;
using System.Linq;

// ContactService.cs
public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public void AddContact(IContact contact)
    {
        List<IContact> contacts = _contactRepository.GetAllContacts();
        contacts.Add(contact);
        _contactRepository.SaveContacts(contacts);
    }




    public void RemoveContact(string email)
    {
        List<IContact> contacts = _contactRepository.GetAllContacts();


        IContact contactToRemove = contacts.FirstOrDefault(c => c.Email.Trim().Equals(email.Trim(), StringComparison.OrdinalIgnoreCase));

        if (contactToRemove != null)
        {

            contacts.Remove(contactToRemove);
            _contactRepository.SaveContacts(contacts);
        }
        else
        {

            Console.WriteLine($"Contact with email '{email}' not found.");
        }
    }







    public void DisplayAllContacts()
    {
        List<IContact> contacts = _contactRepository.GetAllContacts();

        if (contacts.Any())
        {
            Console.WriteLine("All Contacts:");

            for (int i = 0; i < contacts.Count; i++)
            {
                // Set color for index
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[ {i + 1} ] ");
                Console.ResetColor();

                // Set color for name
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{contacts[i].FirstName} {contacts[i].LastName} - ");
                Console.ResetColor();

                // Set color for email
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(contacts[i].Email);
                Console.ResetColor();


            }
        }
        else
        {
            Console.WriteLine("No contacts available.");
        }



    }


    public void DisplayContactDetails(string email)
    {
        List<IContact> contacts = _contactRepository.GetAllContacts();
        IContact contact = contacts.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (contact != null)
        {
            Console.WriteLine($"Contact Details for {contact.FirstName} {contact.LastName}:");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Address: {contact.Address}");
        }
        else
        {
            Console.WriteLine($"Contact with email '{email}' not found.");
        }
    }
}



