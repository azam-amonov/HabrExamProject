using System.Linq.Expressions;
using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Helpers;
using Habr.Service.Service.Interfaces;

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
    
    public Task<Response<User>> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<BlogPost>> GetUserPostsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Comment>> GetUserCommentsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<User>> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Response<User>> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}