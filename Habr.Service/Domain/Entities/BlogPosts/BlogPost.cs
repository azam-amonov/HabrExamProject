using Habr.Service.Domain.Commons;

namespace Habr.Service.Domain.Entities.BlogPosts;

public class BlogPost: Auditable, IContentItem
{
    public int Like { get; set; }
    public int UserId { get; set; }
    public int SavedCount { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public bool IsPublic { get; set; }
    public string? Description { get; set; }
    public BlogPostCategory Category { get; set; }

    public BlogPost(int id) 
                    : base(id)
    {
    }
}