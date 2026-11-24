# LoginLab – C# Windows Forms and SQL Server

A beginner-friendly Windows Forms login application for a school lab. It allows a user to create an account, stores a salted PBKDF2 password hash in SQL Server, authenticates existing accounts, and opens a second form after a successful login.

## Requirements

- Windows 10 or Windows 11
- Visual Studio 2022 with the **.NET desktop development** workload
- .NET 8 SDK (or a compatible newer SDK)
- SQL Server and permission to create a database
- SQL Server Management Studio (SSMS) is recommended for running the setup script

## 1. Create the database

1. Open SQL Server Management Studio and connect to your SQL Server instance.
2. Open `CreateDatabase.sql` in SSMS (File > Open > File).
3. Execute the script (the **Execute** button or F5).
4. Refresh Databases in Object Explorer. You should see `LoginLab`, with a `dbo.Users` table.

## 2. Set the correct SQL Server connection string

Open `Database.cs`. The starter connection string is configured for SQL Server LocalDB:

```csharp
@"Server=(localdb)\MSSQLLocalDB;Database=LoginLab;Integrated Security=True;TrustServerCertificate=True;"
```

If you use SQL Server Express, a common connection string is:

```csharp
@"Server=localhost\SQLEXPRESS;Database=LoginLab;Trusted_Connection=True;TrustServerCertificate=True;"
```

If you use a different SQL Server instance, replace the `Server=...` part with the server name shown in SSMS's Connect to Server window. Keep the database name and the remaining settings. This project uses Windows Authentication; your Windows account must have permission to access the database.

## 3. Open and run the project

1. Open `LoginLab.csproj` in Visual Studio 2022.
2. Allow Visual Studio to restore the `Microsoft.Data.SqlClient` NuGet package.
3. Check that the connection string in `Database.cs` matches your SQL Server instance.
4. Press F5 to run.

## 4. Try the application

1. In **Create a New User**, enter a username (3–50 characters), a password (at least 8 characters), and the same password in Confirm Password.
2. Select **Create User**. The application should confirm that the account was created.
3. Try creating the same username again. The application should warn you to choose another username.
4. Enter the account credentials in **Existing User Login** and select **Login**.
5. The Logged In form should appear with a success message and Logout and Exit buttons.
6. Select Logout to return to the login form.

## Project files

- `Form1.cs` / `Form1.Designer.cs` – login and account creation interface and events
- `LoggedInForm.cs` / `LoggedInForm.Designer.cs` – successful login screen
- `UserValidator.cs` – validates the information before database calls
- `UserRepository.cs` – parameterized SQL commands for account creation and login
- `PasswordHasher.cs` – creates salted PBKDF2 password hashes
- `Database.cs` – SQL Server connection string and connection helper
- `CreateDatabase.sql` – creates the database and Users table

## Security notes

Passwords are not encrypted for later decryption and are never stored as plain text. Each account receives a random 16-byte salt, and PBKDF2-HMAC-SHA256 derives a 32-byte password hash using 600,000 iterations. Login compares hashes using a constant-time comparison. SQL commands use parameters, and the database enforces unique usernames.

This is an educational starter project, not a complete production identity system. A production application should also add account recovery, rate limiting, audit logging, and other operational protections.
