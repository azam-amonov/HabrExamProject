using Habr.Service.Domain.Commons;

namespace Habr.Service.Domain.Entities.Comments;

public class Comment: Auditable, IContentItem
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public int Like { get; set; }
    public int SavedCount { get; set; }
    public string Content { get; set; }

    public Comment(int id, int userId, int postId, int like, int savedCount, string content) 
                    : base(id)
    {
        UserId = userId;
        PostId = postId;
        Like = like;
        SavedCount = savedCount;
        Content = content;
    }

    public override string ToString()
    {
        return $"{Id} {UserId}: {PostId} {Content}";
    }
}