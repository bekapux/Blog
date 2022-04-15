using Blog.DAL.DTO;

namespace Filter.DAL.Repository.Posts
{
    public interface IPostsService
    {
        Task<ServiceResponse<IEnumerable<PostDto>>> Posts_GetAll();
        Task<ServiceResponse<Post>> Posts_GetSingleByID(int PostID);
    }
}