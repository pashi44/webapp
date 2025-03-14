using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;
namespace webapp.Controllers;
    [ApiController]
    [Route("api/[controller]")]
//attribute routing for webapis unlike mvc  conventional ,routing for mvc commubication 
    //controller is the classController name 
    public class PostController : ControllerBase
        {

private readonly IPostService _postService;
//titghly coupling to the POstservice class ; we could have use d the DI with interface class
//  but slowly start with this approach and win the race at the end;  later in time

public PostController(IPostService postService){

_postService = postService;


}

    // sice we made a  service that retuenan api request we can use the service to get the data
    // rather than using the controller for CRUD ing the data
    // public   ActionResult<List<Post>> GetObjects()
    // {
    // return  new List<Post>
    // {   
    // new ()
    // {
    // Id=  1,
    // Name = "Prashanth",
    // Email = "pashireddi@gmail.com",
    // Phone = "816 203 9740",
    // },
    // new ()
    // {
    // Id=  2,
    // Name = "Mouni",
    // Email = "asdasdsadsa",
    // Phone = "913 735 0496",
    // },
    // new ()
    // {
    // Id=  3,
    // Name = "Vijaya;",
    // Email = "",
    // Phone = "816 203 9740",
    // },
    // new (){
    // Id=  4,
    // Name = "asldal;sdaslkjd;",
    // Email = "",
    // Phone = "816",
    // }
    // };
    // }
    [HttpGet("{id}")]


        public async Task<ActionResult<Post?>> GetPost(int id)
        {
            Post? post = await _postService.GetPost(id);
            if(post == null){
                return NotFound();
            }
            return Ok(post);
        }
[HttpGet]
public async Task<ActionResult<List<Post>>> GetAllPosts()
{
List<Post> postlist =  await _postService.GetAllPosts();
// 
if(postlist.Count == 0){
return NotFound();}
else  return Ok(postlist);
}

[HttpPost]
public async Task<ActionResult<Post>> CreatePost( Post item){

 
 await _postService.CreatePost(item);


return  CreatedAtAction(nameof(GetPost),new {id = item.Id},item);

}


[HttpPut("{id}")]

public async Task<ActionResult<Post?>> UpdatePost(int id,Post item){


if(id != item.Id){
 return BadRequest();   


}


Post? updatedPost=  await _postService.UpdatePost(id,item);
if(updatedPost == null)
return NotFound();
else return Ok(item);

}





[HttpGet("{id}/name")]

public  async Task<ActionResult<string>> GetPostName(int id){



Post? post = await _postService.GetPost(id);
if(post == null)  return NotFound();
else return Ok(post.Name);

}


        }//class
        
