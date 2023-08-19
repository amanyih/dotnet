namespace Blog.Domain.Entities;

public class Post : BaseEntity{

    public Post(){
        Comments = new HashSet<Comment>();
    }


    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

}