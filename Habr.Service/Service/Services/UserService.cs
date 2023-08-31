using System.Linq.Expressions;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Interfaces;
using Constant = Habr.Service.DataAccses.Constans.Constant;

namespace Habr.Service.Service.Services;

public class UserService : IUserService
{
    private readonly string _userDataPath = Constant.UserDataFile;
    
    public UserService()
    {
        var source = File.ReadAllTextAsync(_userDataPath);
        if (string.IsNullOrEmpty(source.ToString()))
            File.WriteAllTextAsync(_userDataPath,"[]");
    }
    
    public IQueryable<User> Get(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }
    
    public async Task<User> CreateAsync(User user) 
    {
        if (ValidationService.IsExistsUser(user))
            throw new ArgumentException("User already exists");
        
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
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
}