using AutoMapper;
using Blog.DAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace Filter.DAL.Repository.Posts
{
    public class PostsService : RepositoryBase, IPostsService
    {
        #region Constructors
        public PostsService(BlogContext _context, IMapper _mapper) : base(_context, _mapper) { }

        public async Task<ServiceResponse<int>> Posts_AddNew(AddPostDto post)
        {
            var SR = new ServiceResponse<int>();
            try
            {
                var newPost = _mapper.Map<Post>(post);
                _context.Posts.Add(newPost);
                SR.Data = await _context.SaveChangesAsync();
            }
            catch
            {
                SR.IsSuccess = false;
            }
            return SR;
        }
        #endregion

        #region Methods
        public async Task<ServiceResponse<IEnumerable<Post>>> Posts_GetAll()
        {
            var SR = new ServiceResponse<IEnumerable<Post>>();
            try
            {
                SR.Data = await _context.Posts
                    .Where(x => x.PostIsVisible == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                SR.IsSuccess = false;
                SR.ErrorMessage = ex.Message;
            }
            return SR;
        }
        public async Task<ServiceResponse<Post>> Posts_GetSingleByID(int PostID)
        {
            var SR = new ServiceResponse<Post>();
            try
            {
                SR.Data = await _context.Posts.Where(x => x.PostIsVisible == true).FirstOrDefaultAsync(x => x.PostId == PostID);
                if (SR.Data == null)
                {
                    SR.ErrorMessage = "Not Found";
                    throw new KeyNotFoundException();
                }
            }
            catch
            {
                SR.IsSuccess = false;
            }
            return SR;
        }
        #endregion
    }
}
