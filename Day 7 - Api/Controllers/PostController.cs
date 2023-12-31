using Blog.Data;
using Blog.Dtos;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase{

    private readonly PostService _postService;

    public PostController(BlogDbContext blogDbContext){
        _postService = new PostService(blogDbContext);
    }

    [HttpPost]
    public IActionResult Create(PostDto postDto){
        Console.WriteLine("Heree");
        try{
            Post post = new()
            {
                Title = postDto.Title,
                Content = postDto.Content
            };
            return Created("",_postService.CreatePost(post));
        }catch(Exception e){
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Read(){
        try{
            return Ok(_postService.GetAllPosts());
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Read(int id){
        try{
            return Ok(_postService.GetPostById(id));
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PostDto post){
        try{
            _postService.UpdatePostById(id,post);
            return NoContent();
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id){
        try{
            _postService.DeletePostById(id);
            return NoContent();
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

}