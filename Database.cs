using Microsoft.Data.SqlClient;

namespace LoginLab;

/// <summary>
/// Opens connections to the LoginLab SQL Server database.
/// Change Server= if your SQL Server uses a different server/instance name.
/// </summary>
internal static class Database
{
    // Default for a computer with SQL Server LocalDB installed.
    // For a regular SQL Server Express installation, a common value is:
    // Server=localhost\\SQLEXPRESS;Database=LoginLab;Trusted_Connection=True;TrustServerCertificate=True;
    public const string ConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=LoginLab;Integrated Security=True;TrustServerCertificate=True;";

    public static SqlConnection CreateConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}
