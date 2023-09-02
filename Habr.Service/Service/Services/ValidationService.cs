using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Helpers;
using Newtonsoft.Json;
namespace Habr.Service.Service.Services;

public static class ValidationService 
{
    private static readonly string UserDataPath = Constant.UserDataFile;

    static ValidationService()
    {
        string source = File.ReadAllText(UserDataPath);
        if(string.IsNullOrWhiteSpace(source))
            File.WriteAllText(UserDataPath,"[]");
    }
    
    public static bool IsValidName(string name)
    {
        if (!Validator.IsValidName(name))
            return false;
        return true;
    }

    public static bool IsValidEmail(string email)
    {
        string source = File.ReadAllText(UserDataPath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(source);
        var existEmailAddress = users.Any(u => u.Email.Equals(email));

        if (!Validator.IsValidEmail(email) || !existEmailAddress)
            throw new FormatException("This email address is not valid or already in use!");
        
        return true;
    }

    public static bool IsValidPassword(string password)
    {
        if (!Validator.IsValidPassword(password))
            throw new FormatException("This password is not valid! Example : << passwors@123>> ");
        
        return true;
    }

    public static bool IsExistsUser(User user)
    {
        var source = File.ReadAllText(UserDataPath);
        List<User>? users = JsonConvert.DeserializeObject<List<User>>(source);
        
        var result = users.Any(x => x.Id == user.Id);
        return result;
    }
}