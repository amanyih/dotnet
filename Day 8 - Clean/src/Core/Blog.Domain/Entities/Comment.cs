namespace Blog.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}