using Blog.Data;
using Blog.Models;

namespace Blog.Services;

public class CommentServices{
    private readonly BlogDbContext _blogDbContext;

    public CommentServices(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
    }

    public Comment CreateComment(Comment comment){
        _blogDbContext.Comments.Add(comment);
        _blogDbContext.SaveChanges();
        return comment;
    }

    public List<Comment> GetAllComments(){
        return _blogDbContext.Comments.ToList();
    }

    public Comment? GetCommentById(int id){
        return _blogDbContext.Comments.Find(id);
    }

    public Comment? UpdateComment(int id, Comment comment){
        var commentToUpdate = _blogDbContext.Comments.Find(id);

        if(commentToUpdate != null){
            commentToUpdate.Content = comment.Content;
            commentToUpdate.UpdatedAt = DateTime.Now;
            _blogDbContext.SaveChanges();
        }
        return commentToUpdate;
    }

    public void DeleteCommentById(int id){
        var comment = _blogDbContext.Comments.Find(id);
        if(comment != null){
            _blogDbContext.Comments.Remove(comment);
            _blogDbContext.SaveChanges();
        }
    }

}