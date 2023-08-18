using Blog.Data;
using Blog.Dtos;
using Blog.Models;

namespace Blog.Services;

public class CommentServices{
    private readonly BlogDbContext _blogDbContext;

    public CommentServices(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
    }

    public Comment CreateComment(CommentDto commentDto){
        //validate comment
        if(commentDto.Content == null){
            throw new Exception("Content is required");
        }
        //check if post exists
        _ = _blogDbContext.Posts.Find(commentDto.PostId) ?? throw new Exception("Post Doesn't Exist");

        Comment comment = new()
        {
            PostId = commentDto.PostId,
            Content = commentDto.Content
        };

        _blogDbContext.Comments.Add(comment);
        _blogDbContext.SaveChanges();
        return comment;
    }

    public List<Comment> GetAllComments(){
        return _blogDbContext.Comments.ToList();
    }

    public Comment? GetCommentById(int id){
        return _blogDbContext.Comments.Find(id) ?? throw new Exception("Comment Doesn't Exist");
    }

    public Comment? UpdateComment(int id, CommentDto comment){
        var commentToUpdate = _blogDbContext.Comments.Find(id) ?? throw new Exception("Comment Doesn't exist");
        
        commentToUpdate.Content = comment.Content ?? commentToUpdate.Content;
        commentToUpdate.UpdatedAt = DateTime.Now;
        _blogDbContext.SaveChanges();
        
        return commentToUpdate;
    }

    public void DeleteCommentById(int id){
        var comment = _blogDbContext.Comments.Find(id) ?? throw new Exception("Comment Doesn't exist");
        _blogDbContext.Comments.Remove(comment);
        _blogDbContext.SaveChanges();    
    }

}