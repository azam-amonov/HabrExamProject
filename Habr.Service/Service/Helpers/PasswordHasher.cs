namespace Habr.Service.Service.Helpers;

public static class PasswordHasher
{
    public static string Encrypt(string password) =>
                    BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(string hashedPassword, string password) => 
                    BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
