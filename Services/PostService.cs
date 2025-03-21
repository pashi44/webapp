using webapp.Models;
namespace webapp.Services;

public  class PostService : IPostService
{

private   static readonly List<Post>  postlist =  new();



public Task CreatePost(int id,Post item) {
postlist.Add(item);

return Task.CompletedTask;
}

public Task<Post ?>   UpdatePost(int id,Post item){

Post? post =   postlist.FirstOrDefault<Post?>(x=>x?.Id==id);
if(post !=null){post.Name = item.Name;  
post.Email = item.Email;
post.Phone = item.Phone;
post.WillAttend = item.WillAttend;
}
return Task.FromResult(post);

}
public Task<Post?> GetPost(int gid){
return Task.FromResult(postlist.FirstOrDefault<Post?>(x=>x?.Id==gid));
}
public Task<List<Post>> GetAllPosts(){ 
    return Task.FromResult(postlist);
}

public Task DeletePost(int gid){
    Post? post = postlist.FirstOrDefault(x=>x?.Id==gid);
    if(post !=null){
        postlist.Remove(post);
    }
    return Task.CompletedTask;
    }


public Task<Post?> GetPostByName(string name){
    return Task.FromResult(postlist.FirstOrDefault<Post?>(x=>x?.Name==name));


}
}//service inteface  implementatins