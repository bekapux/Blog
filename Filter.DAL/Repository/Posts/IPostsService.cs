using Blog.DAL;
using Blog.DAL.DTO;

namespace Filter.DAL.Repository.Posts
{
    public interface IPostsService
    {
        Task<ServiceResponse<IEnumerable<GetPostsDTO>>> Posts_GetAll();
        Task<ServiceResponse<Post>> Posts_GetSingleByID(int PostID);
        Task<ServiceResponse<int>> Posts_AddNew(CreateUpdatePostDTO post);
        Task<ServiceResponse<int?>> Posts_Insert_Update(CreateUpdatePostDTO updatedPost);
        Task<ServiceResponse<int?>> Posts_DeletByID(int PostID);

    }
}