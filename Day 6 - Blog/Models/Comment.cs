namespace Blog.Models;

public class Comment{
    public int CommentId {get; set;}

    public string Text {get; set;} = "";

    public int PostId {get; set;}

    public DateTime createdAt {get; set;}

    public virtual Post Post {get; set;}
}