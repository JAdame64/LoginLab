using System.Security.Cryptography;

namespace LoginLab;

/// <summary>
/// Creates and verifies salted PBKDF2 password hashes.
/// The original password is never saved in the database.
/// </summary>
internal static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    public const int Iterations = 600_000;

    public static (byte[] Hash, byte[] Salt) CreateHash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        return (hash, salt);
    }

    public static bool VerifyPassword(string password, byte[] savedSalt, byte[] savedHash)
    {
        byte[] enteredHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            savedSalt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        return CryptographicOperations.FixedTimeEquals(enteredHash, savedHash);
    }
}
