using Habr.Service.Domain.Commons;

namespace Habr.Service.Domain.Entities.BlogPosts;

public class BlogPostCategory : Auditable
{
    public string Name { get; set; }

    public BlogPostCategory(int id) 
                    : base(id)
    {
    }
}