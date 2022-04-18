using Blog.API.Utilities;
using Blog.DAL;
using Blog.DAL.DTO;
using Filter.DAL;
using Filter.DAL.Repository.Posts;
using Microsoft.AspNetCore.Mvc;

namespace ZBlog.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        #region Constructors
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }
        #endregion

        #region Actions
        [HttpGet("getall", Name = ControllerActionRouteNames.Posts.GetAll)]
        public async Task<ServiceResponse<IEnumerable<GetPostsDTO>>> Get()
        {
            var Result = await postsService.Posts_GetAll();
            return Result;
        }

        [HttpGet("getpost/{PostID:int}", Name = ControllerActionRouteNames.Posts.GetByID)]
        public async Task<ServiceResponse<Post>> GetByID(int PostID)
        {
            var Result = await postsService.Posts_GetSingleByID(PostID);
            return Result;
        }

        [HttpPut("insert-update-post", Name = ControllerActionRouteNames.Posts.Update)]
        public async Task<ServiceResponse<int?>> UpdatePost(CreateUpdatePostDTO updatedPost)
        {
            var result = await postsService.Posts_Insert_Update(updatedPost);
            return result;
        }

        [HttpDelete("delete-post/{PostID}", Name = ControllerActionRouteNames.Posts.Delete)]
        public async Task<ServiceResponse<int?>> DeletePost(int PostID)
        {
            var result = await postsService.Posts_DeletByID(PostID);
            return result;
        }
        #endregion
    }
}
