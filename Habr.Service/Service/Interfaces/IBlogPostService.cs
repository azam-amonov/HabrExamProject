using System.Linq.Expressions;
using Habr.Service.Domain.Entities.BlogPosts;

namespace Habr.Service.Service.Interfaces;

public interface IBlogPostService
{
    IQueryable<BlogPost> GetAsync(Expression<Func<BlogPost>> expression);
    
    Task<BlogPost> CreateAsync(BlogPost blogPost);
    Task<BlogPost> UpdateAsync(BlogPost blogPost);
    Task<BlogPost> DeleteAsync(BlogPost blogPost);
    Task<BlogPost> GetByIdAsync(int id);
    Task<List<BlogPost>> GetByUserIdAsync(int id);
    Task<List<BlogPost>> GetAllAsync();
}