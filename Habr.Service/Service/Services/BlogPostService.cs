using System.Linq.Expressions;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Service.Interfaces;

namespace Habr.Service.Service.Services;

public class BlogPostService : IBlogPostService
{
    public IQueryable<BlogPost> GetAsync(Expression<Func<BlogPost>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost> UpdateAsync(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost> DeleteAsync(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogPost>> GetByUserIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogPost>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}