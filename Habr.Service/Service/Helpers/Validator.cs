using System.Text.RegularExpressions;

namespace Habr.Service.Service.Helpers;

public static class Validator
{
    private const string NameRegex = @"^[A-Za-z ]{2,30}$";
    private const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    private const string PasswordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
   
    public static bool IsValidName(string name) =>
                    !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name,NameRegex);

    public static bool IsValidEmail(string email) =>
                    !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email,EmailRegex);

    public static bool IsValidPassword(string password) =>
                    !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password,PasswordRegex);
    
}