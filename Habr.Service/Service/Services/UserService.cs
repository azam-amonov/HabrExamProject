using System.Linq.Expressions;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Helpers;
using Habr.Service.Service.Interfaces;
using Constant = Habr.Service.DataAccses.Constans.Constant;

namespace Habr.Service.Service.Services;

public class UserService : IUserService
{
    private readonly string _userDataPath = Constant.UserDataFile;
    private int _lastId = 0;

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
/// <summary>
/// Create method and the same time write data to the file using
/// Extension which named 
/// </summary>
/// <param name="user"></param>
/// <returns></returns>
    public async Task<Response<User>> CreateAsync(User user)
    {
        if (ValidationService.IsExistsUser(user))
            return await Task.FromResult(new Response<User>
            {
                    StatusCode = 403,
                    Message = "User with this id is already exists",
                    Data = user
            });
        
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        users.Add(user);
        await users.WriteToFileFromJsonAsync(_userDataPath);
        
        return await Task.FromResult(new Response<User>
        {
            StatusCode = 200,
            Message = "Success",
            Data = user
        });
    }

    public async Task<Response<IEnumerable<User>>> GetAllAsync()
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        return new Response<IEnumerable<User>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = users
        };

    }

    public async Task<Response<User?>> GetByIdAsync(int userId)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var user = users.FirstOrDefault(u => u.Id == userId);
        
        if (user is null)
            return await Task.FromResult(new Response<User?>
            {
                            StatusCode = 403,
                            Message = "User not found",
                            Data = user
            });

        return await Task.FromResult(new Response<User?>
        {
                        StatusCode = 200,
                        Message = "Success",
                        Data = user
        });
    }
    

    public Task<Response<BlogPost>> GetUserPostsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Comment>> GetUserCommentsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<User>> UpdateAsync(User user)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var userToUpdate = users.FirstOrDefault(u => u.Id == user.Id);
        
        if (!ValidationService.IsExistsUser(userToUpdate))
            throw new ArgumentNullException("This user does not exist");
        
        userToUpdate.Id = user.Id;
        userToUpdate.Rank = user.Rank;
        userToUpdate.Role = user.Role;
        userToUpdate.Email = user.Email;
        userToUpdate.FullName = user.FullName;
        userToUpdate.Password = user.Password;
        userToUpdate.IsActive = user.IsActive;
        userToUpdate.UpdatedTime = DateTime.Now;
        userToUpdate.CreatedTime = userToUpdate.CreatedTime;

        await users.WriteToFileFromJsonAsync(_userDataPath);
        
        return new Response<User>
        {
            StatusCode = 200,
            Message = "User updated successfully",
            Data = userToUpdate
        };
    }

    public async Task<Response<bool>> DeleteByIdAsync(int userId)
    {
        var users = await _userDataPath.ReadJsonFromFileAsync<List<User>>();
        var userToDelete = users.FirstOrDefault(u => u.Id == userId);

        if (userToDelete is not null)
        {
            users.Remove(userToDelete);
            await users.WriteToFileFromJsonAsync(_userDataPath);
            return new Response<bool>
            {
                            StatusCode = 200,
                            Message = "User deleted successfully",
                            Data = true
            };
        }

        return new Response<bool>
        {
                        StatusCode = 404,
                        Message = "User not found",
                        Data = false
        };

    }
}