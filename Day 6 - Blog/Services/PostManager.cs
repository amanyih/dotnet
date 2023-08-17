using Blog.Data;
using Blog.Models;

namespace Blog.Services;

public class PostManager {

    private readonly BlogDbContext _context;

    public PostManager(BlogDbContext context){
        _context = context;
    }

    public Post CreatePost(Post post){
         _context.Add(post);
         _context.SaveChanges();
         return post;
    }

    public  IEnumerable<Post> GetAllPosts(){
        return _context.Posts.ToList();
    }

    public Post? GetPostById(int id){
        return _context.Posts.Find(id);
    }

    public Post? UpdatePost(Post post){
        _context.Update(post);
        _context.SaveChanges();
        return post;
    }

    public bool DeletePost(int id){
        var post = _context.Posts.Find(id);
        if(post == null){
            return false;
        }
        _context.Remove(post);
        _context.SaveChanges();
        return true;
    }

}