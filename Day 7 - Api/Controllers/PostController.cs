using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase{

    [HttpPost]
    public IActionResult Create(Post post){
        return Ok(post);
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
    public IActionResult Update(int id, Post post){
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id){
        return NoContent();
    }

}