
public class UserInterface : IUserInterface
{
    private readonly IContactService contactService;

    public UserInterface(IContactService contactService)
    {
        this.contactService = contactService;
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void AddContact()
    {
        Console.WriteLine("Enter contact information:");


        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        // Create a new contact
        IContact contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            Address = address
        };

        // Add the contact
        contactService.AddContact(contact);

        // Clear the console screen
        Console.Clear();

        Console.WriteLine("Contact added successfully!");
    }

    public string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }


}