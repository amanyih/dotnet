using Blog.Data;
using Blog.Dtos;
using Blog.Models;

namespace Blog.Services;

public class PostService{

    private readonly BlogDbContext _blogDbContext;

    public PostService(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
    }

    public Post CreatePost(Post post){
        
        //validate post
        if(post.Title == null || post.Content == null){
            throw new Exception("Title and Content are required");
        }

        _blogDbContext.Posts.Add(post);
        _blogDbContext.SaveChanges();
        return post;
    }

    public List<Post> GetAllPosts(){
        return  _blogDbContext.Posts.ToList();
    }

    public Post? GetPostById(int id){
        return _blogDbContext.Posts.Find(id) ?? throw new Exception("Post Doesn't exist");
    }

    public Post? UpdatePostById(int id, PostDto post){
        var postToUpdate = _blogDbContext.Posts.Find(id) ?? throw new Exception("Post Doesn't Exist");

        postToUpdate.Title = post.Title ?? postToUpdate.Title;
        postToUpdate.Content = post.Content ?? postToUpdate.Content;
        postToUpdate.UpdatedAt = DateTime.Now;
        _blogDbContext.SaveChanges();

        return postToUpdate;
    }

    public void DeletePostById(int id){
        var post = _blogDbContext.Posts.Find(id) ?? throw new Exception("Post Doesn't Exist");

        _blogDbContext.Posts.Remove(post);
        _blogDbContext.SaveChanges();

    }
}