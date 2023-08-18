using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase{

    [HttpPost]
    public IActionResult Create(Comment comment){
        return Ok(comment);
    }

    [HttpGet]

    public IActionResult Read(){
        return Ok();
    }

    [HttpGet("{id}")]

    public IActionResult Read(int id){
        return Ok();
    }

    [HttpPut("{id}")]

    public IActionResult Update(int id, Comment comment){
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        return NoContent();
    }
}