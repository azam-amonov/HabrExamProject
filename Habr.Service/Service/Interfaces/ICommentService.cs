using System.Linq.Expressions;
using Habr.Service.Domain.Entities.Comments;

namespace Habr.Service.Service.Interfaces;

public interface ICommentService
{
    Task<Comment> CreateAsync (Comment comment);
    Task<Comment> UpdateAsync (Comment comment);
    Task<Comment> DeleteAsync (int id);
    Task<Comment> GetByIdAsync (int id);
    Task<List<Comment>> GetByUserId (int userId);
    Task<List<Comment>> GetByPostIdAsync (int postId);
}