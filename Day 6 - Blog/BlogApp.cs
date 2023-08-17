using Blog.Data;
using Blog.Models;
using Blog.Services;

namespace Blog;
public class BlogApp {
    private readonly BlogDbContext _blogDbContext;
    private readonly PostManager _postManager;
    private readonly CommentManger _commentManger;

    public BlogApp(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
        _postManager = new PostManager(_blogDbContext);
        _commentManger = new CommentManger(_blogDbContext);
    }

    private void CreatePost(){
        Console.WriteLine("Enter the Title of the Post");
        var title = Console.ReadLine();
        Console.WriteLine("Enter the Content of the Post");
        var content = Console.ReadLine();
        var post = new Post{
            Title = title ?? "",
            Content = content ?? "",
        };
        try{

        _postManager.CreatePost(post);
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }

    private void ViewAllPosts(){
        var posts = _postManager.GetAllPosts();
        foreach(var post in posts){
            Console.WriteLine($"Id: {post.PostId} Title: {post.Title}");
        }
    }

    private void ViewPost(){
        Console.WriteLine("Enter the Id of the Post");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var postId)){
            var post = _postManager.GetPostById(postId);
            if(post == null){
                Console.WriteLine("Post not found");
                return;
            }
            Console.WriteLine($"Id: {post.PostId} Title: {post.Title} Content: {post.Content}");
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void UpdatePost(){
        Console.WriteLine("Enter the Id of the Post");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var postId)){
            var post = _postManager.GetPostById(postId);
            if(post == null){
                Console.WriteLine("Post not found");
                return;
            }
            Console.WriteLine($"Id: {post.PostId} Title: {post.Title} Content: {post.Content}");
            Console.WriteLine("Enter the Title of the Post");
            var title = Console.ReadLine();
            Console.WriteLine("Enter the Content of the Post");
            var content = Console.ReadLine();
            post.Title = title ?? "";
            post.Content = content ?? "";
            _postManager.UpdatePost(post);
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void DeletePost(){
        Console.WriteLine("Enter the Id of the Post");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var postId)){
            var post = _postManager.GetPostById(postId);
            if(post == null){
                Console.WriteLine("Post not found");
                return;
            }
            _postManager.DeletePost(postId);
            Console.WriteLine("Post Deleted!");
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void CreateComment(){
        Console.WriteLine("Enter the Text of the Comment");
        var text = Console.ReadLine();
        Console.WriteLine("Enter the PostId of the Comment");
        var postId = Console.ReadLine();
        if(int.TryParse(postId, out var postid)){
            var post = _postManager.GetPostById(postid);
            if(post == null){
                Console.WriteLine("Post not found");
                return;
            }
            var comment = new Comment{
                Text = text ?? "",
                PostId = postid,
            };
            _commentManger.CreateComment(comment);
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void ViewAllComments(){
        var comments = _commentManger.GetAllComments();
        foreach(var comment in comments){
            Console.WriteLine($"Id: {comment.CommentId} Text: {comment.Text}");
        }
    }

    private void ViewComment(){
        Console.WriteLine("Enter the Id of the Comment");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var commentId)){
            var comment = _commentManger.GetCommentById(commentId);
            if(comment == null){
                Console.WriteLine("Comment not found");
                return;
            }
            Console.WriteLine($"Id: {comment.CommentId} Text: {comment.Text}");
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void UpdateComment(){
        Console.WriteLine("Enter the Id of the Comment");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var commentId)){
            var comment = _commentManger.GetCommentById(commentId);
            if(comment == null){
                Console.WriteLine("Comment not found");
                return;
            }
            Console.WriteLine($"Id: {comment.CommentId} Text: {comment.Text}");
            Console.WriteLine("Enter the Text of the Comment");
            var text = Console.ReadLine();
            comment.Text = text ?? "";
            _commentManger.UpdateComment(comment);
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    private void DeleteComment(){
        Console.WriteLine("Enter the Id of the Comment");
        var id = Console.ReadLine();
        if(int.TryParse(id, out var commentId)){
            var comment = _commentManger.GetCommentById(commentId);
            if(comment == null){
                Console.WriteLine("Comment not found");
                return;
            }
            _commentManger.DeleteComment(commentId);
            Console.WriteLine("Comment Deleted!");
        }else{
            Console.WriteLine("Invalid Id");
        }
    }

    public void Run(){

        Console.WriteLine("Welcome to the Blog App!");

        while(true){
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Create a Post");
            Console.WriteLine("2) View all Posts"); 
            Console.WriteLine("3) View a Post");
            Console.WriteLine("4) Update a Post");
            Console.WriteLine("5) Delete a Post");
            Console.WriteLine("6) Create a Comment");
            Console.WriteLine("7) View all Comments");
            Console.WriteLine("8) View a Comment");
            Console.WriteLine("9) Update a Comment");
            Console.WriteLine("10) Delete a Comment");
            Console.WriteLine("11) Exit");
            var choice = Console.ReadLine();
            switch(choice){
                case "1":
                    CreatePost();
                    break;
                case "2":
                    ViewAllPosts();
                    break;
                case "3":
                    ViewPost();
                    break;
                case "4":
                    UpdatePost();
                    break;
                case "5":
                    DeletePost();
                    break;
                case "6":
                    CreateComment();
                    break;
                case "7":
                    ViewAllComments();
                    break;
                case "8":
                    ViewComment();
                    break;
                case "9":
                    UpdateComment();
                    break;
                case "10":
                    DeleteComment();
                    break;
                case "11":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}