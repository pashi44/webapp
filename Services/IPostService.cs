using webapp.Models;
namespace webapp.Services;

public interface  IPostService
{
    Task CreatePost(Post item);
    Task<Post?> UpdatePost(int id,Post item);
    Task<Post?> GetPost(int gid);
    Task<List<Post>> GetAllPosts();
    Task DeletePost(int gid);
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