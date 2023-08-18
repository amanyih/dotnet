using Blog.Data;
using Blog.Models;

namespace Blog.Services;

public class PostService{

    private readonly BlogDbContext _blogDbContext;

    public PostService(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
    }

    public Post CreatePost(Post post){
        _blogDbContext.Posts.Add(post);
        _blogDbContext.SaveChanges();
        return post;
    }

    public List<Post> GetAllPosts(){
        return  _blogDbContext.Posts.ToList();
    }

    public Post? GetPostById(int id){
        return _blogDbContext.Posts.Find(id);
    }

    public Post? UpdatePostById(int id, Post post){
        var postToUpdate = _blogDbContext.Posts.Find(id);
        if(postToUpdate != null){
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            postToUpdate.UpdatedAt = DateTime.Now;
            _blogDbContext.SaveChanges();
        }
        return postToUpdate;
    }

    public void DeletePostById(int id){
        var post = _blogDbContext.Posts.Find(id);
        if(post != null){
            _blogDbContext.Posts.Remove(post);
            _blogDbContext.SaveChanges();
        }
    }
}