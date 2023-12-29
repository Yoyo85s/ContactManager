
/// <summary>
/// Implementation of the contact manager responsible for handling user interactions
/// and delegating contact-related operations to the contact service.
/// </summary>
public class ContactManager : IContactManager
{
    private readonly IContactService _contactService;
    private readonly IUserInterface _userInterface;

    /// <summary>
    /// Constructor to initialize the ContactManager with the required dependencies.
    /// </summary>
    /// <param name="contactService">The contact service used for contact operations.</param>
    /// <param name="userInterface">The user interface for interacting with the user.</param>
    public ContactManager(IContactService contactService, IUserInterface userInterface)
    {
        _contactService = contactService;
        _userInterface = userInterface;
    }

    /// <summary>
    /// Runs the contact manager application, displaying a menu and handling user input.
    /// </summary>
    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            _userInterface.DisplayMessage("Contact Manager Menu, Choose an option:");
            Console.ForegroundColor = ConsoleColor.White;
            _userInterface.DisplayMessage("1. Add Contact");
            _userInterface.DisplayMessage("2. Display All Contacts");
            _userInterface.DisplayMessage("3. Display Contact Details");
            _userInterface.DisplayMessage("4. Remove Contact");
            _userInterface.DisplayMessage("5. Exit");

            string choice = _userInterface.GetUserInput("Enter your choice:");

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    DisplayAllContacts();
                    break;
                case "3":
                    DisplayContactDetails();
                    break;
                case "4":
                    RemoveContact();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    _userInterface.DisplayMessage("Invalid choice. Please try again.");
                    break;



            }
        }
    }

    /// <summary>
    /// Adds a new contact by collecting information from the user and delegating the
    /// addition operation to the contact service.
    /// </summary>
    public void AddContact()
    {
        // Collect contact information from the user

        Console.ForegroundColor = ConsoleColor.Yellow;
        string firstName = _userInterface.GetUserInput("Enter First Name:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string lastName = _userInterface.GetUserInput("Enter Last Name:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string phoneNumber = _userInterface.GetUserInput("Enter Phone Number:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string email = _userInterface.GetUserInput("Enter Email:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string address = _userInterface.GetUserInput("Enter Address:");
        Console.ResetColor();
        Console.Clear();

        // Create a new contact
        IContact newContact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            Address = address
        };

        // Add the contact
        _contactService.AddContact(newContact);
        Console.ForegroundColor = ConsoleColor.Green;
        _userInterface.DisplayMessage("Contact added successfully.");
    }

    /// <summary>
    /// Removes a contact by getting the email input from the user
    /// and delegating the removal operation to the contact service.
    /// </summary>
    public void RemoveContact()
    {
        // Get email input from the user
        string email = _userInterface.GetUserInput("Enter the Email of the contact to remove:");

        // Remove the contact
        _contactService.RemoveContact(email);
        _userInterface.DisplayMessage("Contact removed successfully.");
    }

    /// <summary>
    /// Displays all contacts using the contact service.
    /// </summary>
    public void DisplayAllContacts()
    {
        // Display all contacts
        _contactService.DisplayAllContacts();
    }

    /// <summary>
    /// Displays detailed information about a specific contact
    /// by getting the email input from the user and delegating
    /// the display operation to the contact service.
    /// </summary>
    public void DisplayContactDetails()
    {
        // Get email input from the user
        string email = _userInterface.GetUserInput("Enter the Email of the contact to display details:");

        // Display contact details
        _contactService.DisplayContactDetails(email);
    }
}
