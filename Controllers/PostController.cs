using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapp.Controllers
{
    [ApiController]
    [Route("[controller]")] // Base route for the controller

    // [Route("/make")] // Multiple route attributes should be allowed on controllers
    // If you want to have multiple routes for the same controller, do so if there is a strong reason.
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // In ASP.NET Core REST APIs, we usually do not use the [action] token because the action
        // name is not included in the route template. Similarly, do not use the [Route] attribute for action
        // methods. Instead, we use the HTTP method to distinguish action methods. We will discuss this in
        // the following section.

        // GET /post/{id}
        [HttpGet("{id:int:range(1,1000)}")]
        public async Task<ActionResult<Post?>> GetPost([FromRoute] int id) // Use [FromRoute] for route parameters
        {
            Post? post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // GET /post
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            List<Post> postList = await _postService.GetAllPosts();
            if (postList.Count == 0)
            {
                return NotFound();
            }
            return Ok(postList);
        }

        // Source binding parameters

        // GET /post/{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<string>> GetPostByName([FromRoute] string name) // Use [FromRoute] for route parameters
        {
            Post? post = await _postService.GetPostByName(name);
            if (post == null || post.Name == null)
            {
                return BadRequest();
            }
            return Ok(post.Name);
        }

        // Absolute binding now the route is /post/id and it is static
        // Source binding parameters could also be used in the route templates
        // based on the type of source binding parameter for post?id=1
        // [FromBody]: The parameter is from the request body
        // [FromForm]: The parameter is from the form data in the request body
        // [FromHeader]: The parameter is from the request header
        // [FromQuery]: The parameter is from the query strings in the request
        // [FromRoute]: The parameter is from the route path
        // [FromServices]: The parameter is from the DI container

        // GET /post/search?id={id}

//statcic route path 
        [HttpGet("search")]
        public async Task<ActionResult<Post?>> SearchPost([FromQuery] int? id,
         [FromQuery] string? name ) // Use [FromQuery] for query parameters
        {


Post? post =   null;
            // Search by name if provided and no post was found by id

            if (id.HasValue)
                post = await _postService.GetPost(id.Value);
            else if (!string.IsNullOrEmpty(name))
                post = await _postService.GetPostByName(name);
            else
                return BadRequest("ID cannot be null");
//even if  the status code is 200 it may retuen  a  null objec
            if (post == null)
                return NotFound();

            return Ok(post);

        }
        // POST /post/{id}
        [HttpPost("{id:int:range(1,1000)}")]
        public async Task<ActionResult<Post>> CreatePost([FromRoute] int postid, [FromBody] Post item) // Use [FromBody] for request body
        {
            // [FromBody] is the binding source attribute that tells
            // the model binder to get the data from the request body
            await _postService.CreatePost(postid,item);
            return CreatedAtAction(nameof(GetPost), new { id = item.Id }, item);
        }
        // PUT /post/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Post?>> UpdatePost(
            [FromRoute] int id, // Use [FromRoute] for route parameters
            [FromBody] Post item) // Use [FromBody] for request body
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Post? updatedPost = await _postService.UpdatePost(id, item);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return Ok(updatedPost);
        }

        // GET /post/{id}/name
        [HttpGet("{id}/name")]
        public async Task<ActionResult<string>> GetPostName([FromRoute] int id) // Use [FromRoute] for route parameters
        {
            Post? post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.Name);
        }

        // GET /post/{id}/email
        [HttpGet("{id}/email")]
        public async Task<ActionResult<string>> GetEmail([FromRoute] int id) // Use [FromRoute] for route parameters
        {
            Post? post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.Email);
        }
    }
}