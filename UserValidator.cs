namespace LoginLab;

/// <summary>
/// Checks user input before the application sends it to SQL Server.
/// An empty return value means the information passed validation.
/// </summary>
internal class UserValidator
{
    public string ValidateNewUser(string username, string password, string confirmPassword)
    {
        username = username.Trim();

        if (string.IsNullOrWhiteSpace(username))
            return "Please enter a username.";

        if (username.Length < 3 || username.Length > 50)
            return "The username must be between 3 and 50 characters.";

        if (string.IsNullOrWhiteSpace(password))
            return "Please enter a password.";

        if (password.Length < 8)
            return "The password must be at least 8 characters long.";

        if (password != confirmPassword)
            return "The password and confirmation password do not match.";

        return string.Empty;
    }

    public string ValidateLogin(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return "Please enter your username.";

        if (string.IsNullOrWhiteSpace(password))
            return "Please enter your password.";

        return string.Empty;
    }
}
