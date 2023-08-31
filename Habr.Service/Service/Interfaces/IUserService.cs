using System.Linq.Expressions;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Helpers;

namespace Habr.Service.Service.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> expression);

    Task<Response<User>> CreateAsync(User user);
    Task<Response<User>> GetByIdAsync(int userId);
    Task<Response<User>> UpdateAsync(User user);
    Task<Response<BlogPost>> GetUserPostsAsync(int userId);
    Task<Response<Comment>> GetUserCommentsAsync(int userId);
    Task<Response<User>> DeleteAsync(User user);
    Task<Response<bool>> DeleteByIdAsync(int userId);
}