
public interface IUserInterface
{
    // <summary>
    /// Gets user input with the specified prompt.
    /// </summary>
    /// <param name="prompt">The prompt displayed to the user.</param>
    /// <returns>User input as a string.</returns>
    string GetUserInput(string prompt);

    // <summary>
    /// Displays a message to the user.
    /// </summary>
    /// <param name="message">The message to be displayed.</param>
    void DisplayMessage(string message);

    void WriteLine(string message);
    string ReadLine();

}
