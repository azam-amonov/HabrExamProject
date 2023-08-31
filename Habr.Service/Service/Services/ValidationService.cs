using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Helpers;
using Newtonsoft.Json;
namespace Habr.Service.Service.Services;

public static class ValidationService 
{
    private static readonly string _userDataPath = Constant.UserDataFile;

    static ValidationService()
    {
        string source = File.ReadAllText(_userDataPath);
        if(string.IsNullOrWhiteSpace(source))
            File.WriteAllText(_userDataPath,"[]");
    }
    
    public static Task<Response<bool>> IsValidName(string name)
    {
        if (!Validator.IsValidName(name))
            return Task.FromResult(new Response<bool>
            {
                            StatusCode = 400,
                            Message = "Invalid name",
                            Data = false
            });
        
        return Task.FromResult(new Response<bool>
        {
                        StatusCode = 200,
                        Message = "Success",
                        Data = true
        });
    }

    public static Task<Response<bool>> IsValidEmail(string email)
    {
        string source = File.ReadAllText(_userDataPath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(source);
        
        var existEmailAddress = users.Any(u => u.Email.Equals(email));
        
        if (!Validator.IsValidEmail(email) || !existEmailAddress)
            return Task.FromResult(new Response<bool>
            {
                    StatusCode = 400,
                    Message = "Invalid email address or email is already in use!",
                    Data = false
            });
        
        return Task.FromResult(new Response<bool>
        {
                StatusCode = 200,
                Message = "Success",
                Data = true
        });
    }

    public static Task<Response<bool>> IsValidPassword(string password)
    {
        if (!Validator.IsValidPassword(password))
            return Task.FromResult(new Response<bool>
            {
                            StatusCode = 400,
                            Message = "Invalid password",
                            Data = false
            });
        
        return Task.FromResult(new Response<bool>
        {
                        StatusCode = 200,
                        Message = "Success",
                        Data = true
        });
    }

    public static bool IsExistsUser(User user)
    {
        var source = File.ReadAllText(_userDataPath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(source);
        
        var result = users.Any(x => x.Id == user.Id);
        return result;
    }
}