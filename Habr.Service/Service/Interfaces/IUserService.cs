using System.Linq.Expressions;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Service.Helpers;

namespace Habr.Service.Service.Interfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int userId);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteByIdAsync(int userId);
}