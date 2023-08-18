namespace Blog.Models;


public class Comment{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int PostId { get; set; }
    public virtual Post Post { get; set; } = null!;
}