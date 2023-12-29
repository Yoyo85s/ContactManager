

    // Program.cs
    class Program
    {
        static void Main()
        {
            // Create instances of dependencies
            IContactRepository contactRepository = new ContactRepository();
            IContactService contactService = new ContactService(contactRepository);
            IUserInterface userInterface = new UserInterface(contactService);

            // Create and run the ContactManager
            IContactManager contactManager = new ContactManager(contactService, userInterface);
            contactManager.Run();
        }
    }


