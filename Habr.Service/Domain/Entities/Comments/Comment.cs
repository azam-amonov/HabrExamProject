using Habr.Service.Domain.Commons;

namespace Habr.Service.Domain.Entities.Comments;

public class Comment: Auditable, IContentItem
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public int Like { get; set; }
    public int SavedCount { get; set; }
    public string Content { get; set; }

    public Comment(int id, DateTime updatedTime) : base(id, updatedTime)
    {
    }
}