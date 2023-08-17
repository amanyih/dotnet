using Blog.Services;
using Xunit;

namespace UnitTest;

public class PostManagerTest{
    private readonly PostManager _postManager;

    public PostManagerTest(){
        var context = ContextBuilder.BuildInMemoryContext();
        _postManager = new PostManager(context);
    }

    [Fact]
    public void CreatePostTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        Assert.NotNull(post);
    }

    [Fact]
    public void GetPostByIdTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var postFromDb = _postManager.GetPostById(post.PostId);

        Assert.NotNull(postFromDb);
        Assert.Equal(post.PostId, postFromDb.PostId);
    }

    [Fact]
    public void GetAllPostsTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var posts = _postManager.GetAllPosts();

        Assert.NotNull(posts);
        Assert.NotEmpty(posts);
    }

    [Fact]
    public void UpdatePostTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        post.Title = "Updated Title";
        post.Content = "Updated Content";

        var updatedPost = _postManager.UpdatePost(post);

        Assert.NotNull(updatedPost);
        Assert.Equal(post.PostId, updatedPost.PostId);
        Assert.Equal(post.Title, updatedPost.Title);
        Assert.Equal(post.Content, updatedPost.Content);
    }

    [Fact]
    public void DeletePostTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        _postManager.DeletePost(post.PostId);

        var postFromDb = _postManager.GetPostById(post.PostId);

        Assert.Null(postFromDb);
    }
    
}