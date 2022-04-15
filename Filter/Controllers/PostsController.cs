using Blog.DAL.DTO;
using Filter.DAL;
using Filter.DAL.Repository.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZBlog.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }


        [HttpGet("getall")]
        public async Task<ServiceResponse<IEnumerable<Post>>> Get()
        {
            var Result = await postsService.Posts_GetAll();
            return Result;
        }

        [HttpPost("add-post")]
        public async Task<ServiceResponse<int>> AddPost(AddPostDto newPost)
        {
            var result = await postsService.Posts_AddNew(newPost);
            return result;
        }
    }
}
