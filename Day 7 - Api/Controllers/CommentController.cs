using Blog.Data;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase{

    private CommentServices _commentService;

    public CommentController(BlogDbContext blogDbContext){
        _commentService = new CommentServices(blogDbContext);
    }

    [HttpPost]
    public IActionResult Create(Comment comment){
        try{
            return Created("",_commentService.CreateComment(comment));
        }catch{
            return BadRequest();
        }
    }

    [HttpGet]

    public IActionResult Read(){
        try{
            return Ok(_commentService.GetAllComments());
        }catch (Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]

    public IActionResult Read(int id){
        try{
            return Ok(_commentService.GetCommentById(id));

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]

    public IActionResult Update(int id, Comment comment){
        try{
            _commentService.UpdateComment(id,comment);
            return NoContent();
        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        try{
            _commentService.DeleteCommentById(id);
            return NoContent();

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }
}