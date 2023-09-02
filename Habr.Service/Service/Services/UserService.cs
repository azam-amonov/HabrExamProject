using Habr.Service.Domain.Entities;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Interfaces;
using Constant = Habr.Service.DataAccses.Constans.Constant;

namespace Habr.Service.Service.Services;

public class UserService : IUserService
{
    private readonly string _userDataPath;
    private readonly int _lastId;
    
    public UserService()
    {
        _userDataPath = Constant.GenericFilePath<User>(new User());
        _lastId = GetLastId();
        
        if (!File.Exists(_userDataPath)) 
            File.Create(_userDataPath);
        
        InitializeAsync().Wait();
    }

    private async Task InitializeAsync()
    {
        var source = File.ReadAllTextAsync(_userDataPath);
        
        if (string.IsNullOrEmpty(source.ToString()))
            await File.WriteAllTextAsync(_userDataPath,"[]");
    }
    
    public async Task<User> CreateAsync(User user) 
    {
        if (ValidationService.IsExistsUser(user))
            throw new ArgumentException("User already exists");
        
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        user = new User
        { 
            Id = _lastId,
            Email = user.Email,
            FullName = user.FullName,
            Password = user.Password,
            Role = user.Role
        };
        
        users.Add(user);
        await users.WriteToFileFromJsonAsync(_userDataPath);
        
    return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync() =>
         await _userDataPath.ReadJsonFromFileAsync<List<User>>();

    public async Task<User?> GetByIdAsync(int userId)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var user = users.FirstOrDefault(u => u.Id == userId);

        if (user is null)
            throw new ArgumentNullException($"User with id {userId} does not exist!");

        return user;
    }
    
    public async Task<User> UpdateAsync(User user)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var userToUpdate = users.FirstOrDefault(u => u.Id == user.Id);
        
        if (!ValidationService.IsExistsUser(userToUpdate))
            throw new ArgumentNullException("This user does not exist");
        
        userToUpdate.Role = user.Role;
        userToUpdate.Email = user.Email;
        userToUpdate.FullName = user.FullName;
        userToUpdate.Password = user.Password;
        userToUpdate.IsActive = user.IsActive;
        userToUpdate.UpdatedTime = DateTime.Now;
        await users.WriteToFileFromJsonAsync(_userDataPath);

        return user;
    }
    
    public async Task<User> DeleteByIdAsync(int userId)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var userToDelete = users.FirstOrDefault(u => u.Id == userId);

        if (userToDelete is null)
            throw new ArgumentNullException($"User with id: {userId} is not found");
        
        users.Remove(userToDelete);
        await users.WriteToFileFromJsonAsync(_userDataPath);
        return userToDelete;
    }

    private  int GetLastId()
    {
        var users =  GetAllAsync().Result.ToList();
        var lastUser = users.LastOrDefault();
        if (lastUser is null)
            return 1;
        return lastUser.Id + 1;
    }
}