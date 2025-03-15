
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using webapp.Models;
using webapp.Services;
namespace webapp.Controllers;
    [ApiController]
    [Route("[controller]")]

// [Route("/make")] //multiple route attributes  should be allowd on controllers
//if ypou want to have multiple routes for the same controller  do  if is a strong reason
    public class PostController : ControllerBase
        {

private readonly IPostService _postService;

public PostController(IPostService postService){

_postService = postService;


}

    // In ASP.NET Core REST APIs, we usually do not use the[action] token because the action
    // name is not included in the route template.Similarly, do not use the[Route] attribute for action
    // methods. Instead, we use the HTTP method to distinguish action methods.We will discuss this in
    // the following section.
    
        [HttpGet("{id:int:range(1,1000)}")]


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




[HttpGet("search")] 
//source binding parametrs could also be used in the route  templaTES 
//based on the type of siurce binding parameter  for id?=123
public async  Task<ActionResult<Post?>> SearchPost([FromQuery]  int  id){


        Post? post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);

    }

//http verbs also  supports regex

[HttpPost("{id:int:range(1,1000)}")]
public async Task<ActionResult<Post>> CreatePost( [FromBody] Post item){

//[fromBOdy ] is  the binding source attributes that tells 
// the model binder to get the data from the
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


[HttpGet("{id}/email")]
public async  Task<ActionResult<string>>  Getemail(int id){


    Post? post = await _postService.GetPost(id);
if(post == null) return NotFound();


else 
    return   Ok(post.Email);
}


        }//class
        
