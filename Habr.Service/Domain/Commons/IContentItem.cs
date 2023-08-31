namespace Habr.Service.Domain.Commons;

public interface IContentItem
{
    public int UserId { get; set; }
    public int Like { get; set; }
    public int SavedCount { get; set; }
    public string Content { get; set; }
    
}