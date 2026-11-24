using Microsoft.Data.SqlClient;

namespace LoginLab;

/// <summary>
/// Contains the SQL commands used to create accounts and check login credentials.
/// </summary>
internal class UserRepository
{
    public bool CreateUser(string username, string password)
    {
        var passwordData = PasswordHasher.CreateHash(password);

        const string sql = @"
            INSERT INTO dbo.Users (Username, PasswordHash, PasswordSalt, PasswordIterations)
            VALUES (@Username, @PasswordHash, @PasswordSalt, @PasswordIterations);";

        using SqlConnection connection = Database.CreateConnection();
        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Username", username.Trim());
        command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarBinary, 32).Value = passwordData.Hash;
        command.Parameters.Add("@PasswordSalt", System.Data.SqlDbType.VarBinary, 16).Value = passwordData.Salt;
        command.Parameters.AddWithValue("@PasswordIterations", PasswordHasher.Iterations);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
            return true;
        }
        catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
        {
            // SQL Server reports these numbers when a unique username already exists.
            return false;
        }
    }

    public bool AuthenticateUser(string username, string password)
    {
        const string sql = @"
            SELECT PasswordHash, PasswordSalt, PasswordIterations
            FROM dbo.Users
            WHERE Username = @Username;";

        using SqlConnection connection = Database.CreateConnection();
        using SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Username", username.Trim());

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return false;

        byte[] savedHash = (byte[])reader["PasswordHash"];
        byte[] savedSalt = (byte[])reader["PasswordSalt"];
        int iterations = Convert.ToInt32(reader["PasswordIterations"]);

        // Use the iteration count stored with this account so the hash can be upgraded later.
        byte[] enteredHash = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(
            password,
            savedSalt,
            iterations,
            System.Security.Cryptography.HashAlgorithmName.SHA256,
            savedHash.Length);

        return System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(enteredHash, savedHash);
    }
}
