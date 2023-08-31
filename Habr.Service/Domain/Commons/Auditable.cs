namespace Habr.Service.Domain.Commons;

public abstract class Auditable
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(5);
    public DateTime? UpdatedTime { get; set; }

    protected Auditable(int id)
    {
        Id = id;
    }
}