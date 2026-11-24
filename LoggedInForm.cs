namespace LoginLab;

public partial class LoggedInForm : Form
{
    public LoggedInForm(string username)
    {
        InitializeComponent();
        lblWelcome.Text = $"You have successfully logged in, {username}!";
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        Close(); // Returns the user to the login form.
    }

    private void btnExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}
