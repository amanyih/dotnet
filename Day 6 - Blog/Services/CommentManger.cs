using Blog.Data;
using Blog.Models;

namespace Blog.Services;

public class CommentManger{
    private readonly BlogDbContext _context;

    public CommentManger(BlogDbContext context){
        _context = context;
    }

    public Comment CreateComment(Comment comment){
        _context.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    public IEnumerable<Comment> GetAllComments(){
        return _context.Comments.ToList();
    }

    public Comment? GetCommentById(int id){
        return _context.Comments.Find(id);
    }

    public Comment? UpdateComment(Comment comment){
        _context.Update(comment);
        _context.SaveChanges();
        return comment;
    }

    public bool DeleteComment(int id){
        var comment = _context.Comments.Find(id);
        if(comment == null){
            return false;
        }
        _context.Remove(comment);
        _context.SaveChanges();
        return true;
    }
}