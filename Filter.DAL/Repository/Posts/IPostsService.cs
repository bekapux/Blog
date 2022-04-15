using Blog.DAL.DTO;

namespace Filter.DAL.Repository.Posts
{
    public interface IPostsService
    {
        Task<ServiceResponse<IEnumerable<Post>>> Posts_GetAll();
        Task<ServiceResponse<Post>> Posts_GetSingleByID(int PostID);
        Task<ServiceResponse<int>> Posts_AddNew(AddPostDto post);

    }
}