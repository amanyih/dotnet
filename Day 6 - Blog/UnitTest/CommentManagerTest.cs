using Blog.Data;
using Blog.Models;
using Blog.Services;
using Xunit;

namespace UnitTest;


public class CommentManagerTest{

    private readonly CommentManger _commentManager;
    private readonly PostManager _postManager;
    

    public CommentManagerTest(){
        var context = ContextBuilder.BuildInMemoryContext();
        _commentManager = new CommentManger(context);
        _postManager = new PostManager(context);
    }


    [Fact]
    public void CreateCommentTest(){
       
        
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var comment = _commentManager.CreateComment(new()
        {
            PostId = post.PostId,
            Text = "Test Comment"
        });

        Assert.NotNull(comment);
        
    }

    [Fact]
    public void GetCommentByIdTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var comment = _commentManager.CreateComment(new()
        {
            PostId = post.PostId,
            Text = "Test Comment"
        });

        var commentFromDb = _commentManager.GetCommentById(comment.CommentId);

        Assert.NotNull(commentFromDb);
        Assert.Equal(comment.CommentId, commentFromDb.CommentId);
    }
    [Fact]
    public void GetCommentByNegativeIdTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var comment = _commentManager.CreateComment(new() { PostId = -1, Text = "Test Comment" });

        var commentFromDb = _commentManager.GetCommentById(comment.CommentId);

        Assert.NotNull(commentFromDb);
        Assert.Equal(comment.CommentId, commentFromDb.CommentId);
    }
    
    [Fact]
    public void UpdateCommentTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var comment = _commentManager.CreateComment(new()
        {
            PostId = post.PostId,
            Text = "Test Comment"
        });

        comment.Text = "Updated Comment";
        _commentManager.UpdateComment(comment);

        var commentFromDb = _commentManager.GetCommentById(comment.CommentId);

        Assert.NotNull(commentFromDb);
        Assert.Equal(comment.CommentId, commentFromDb.CommentId);
        Assert.Equal(comment.Text, commentFromDb.Text);
    }

    [Fact]
    public void DeleteCommentTest(){
        var post = _postManager.CreatePost(new()
        {
            Title = "Test Post",
            Content = "Test Content"
        });

        var comment = _commentManager.CreateComment(new()
        {
            PostId = post.PostId,
            Text = "Test Comment"
        });

        _commentManager.DeleteComment(comment.CommentId);

        var commentFromDb = _commentManager.GetCommentById(comment.CommentId);

        Assert.Null(commentFromDb);
    }
}