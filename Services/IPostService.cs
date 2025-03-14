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