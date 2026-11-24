namespace LoginLab;

public partial class Form1 : Form
{
    private readonly UserValidator _validator = new UserValidator();
    private readonly UserRepository _users = new UserRepository();

    public Form1()
    {
        InitializeComponent();
        txtLoginPassword.UseSystemPasswordChar = true;
        txtNewPassword.UseSystemPasswordChar = true;
        txtConfirmPassword.UseSystemPasswordChar = true;
    }

    private void btnCreateUser_Click(object? sender, EventArgs e)
    {
        string username = txtNewUsername.Text.Trim();
        string password = txtNewPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;

        string validationMessage = _validator.ValidateNewUser(username, password, confirmPassword);
        if (validationMessage != string.Empty)
        {
            MessageBox.Show(validationMessage, "Check Your Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            bool created = _users.CreateUser(username, password);

            if (!created)
            {
                MessageBox.Show("That username is already being used. Please choose a different username.",
                    "Username Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewUsername.Focus();
                txtNewUsername.SelectAll();
                return;
            }

            MessageBox.Show("Your account was created successfully. You can now log in.",
                "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtLoginUsername.Text = username;
            txtLoginPassword.Clear();
            txtNewUsername.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtLoginPassword.Focus();
        }
        catch (Exception ex)
        {
            ShowDatabaseError(ex);
        }
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtLoginUsername.Text.Trim();
        string password = txtLoginPassword.Text;

        string validationMessage = _validator.ValidateLogin(username, password);
        if (validationMessage != string.Empty)
        {
            MessageBox.Show(validationMessage, "Check Your Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            if (!_users.AuthenticateUser(username, password))
            {
                MessageBox.Show("The username or password is incorrect.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginPassword.Clear();
                txtLoginPassword.Focus();
                return;
            }

            txtLoginPassword.Clear();
            using (LoggedInForm loggedInForm = new LoggedInForm(username))
            {
                Hide();
                loggedInForm.ShowDialog(this);
                Show();
                txtLoginPassword.Clear();
                txtLoginPassword.Focus();
            }
        }
        catch (Exception ex)
        {
            ShowDatabaseError(ex);
        }
    }

    private static void ShowDatabaseError(Exception ex)
    {
        MessageBox.Show(
            "The application could not connect to or use the LoginLab database. " +
            "Check that SQL Server is running, that you ran CreateDatabase.sql, and that the server name in Database.cs is correct.\n\n" +
            "Technical details: " + ex.Message,
            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
