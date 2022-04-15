using Blog.DAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace Filter.DAL.Repository.Posts
{
    public class PostsService : RepositoryBase, IPostsService
    {
        #region Constructors
        public PostsService(BlogContext context) : base(context) { }
        #endregion

        #region Methods
        public async Task<ServiceResponse<IEnumerable<PostDto>>> Posts_GetAll()
        {
            var SR = new ServiceResponse<IEnumerable<PostDto>>();
            try
            {
                SR.Data = await context.Posts
                    .Include(x => x.PostAuthorUser)
                    .Include(x => x.PostCategory)
                    .Where(x => x.PostIsVisible == true)
                    .Select(x => new PostDto 
                    { 
                        PostAuthorUser = x.PostAuthorUser,
                        PostAuthorUserId = x.PostAuthorUserId,
                        PostCategoryId = x.PostCategoryId,
                        PostTitle = x.PostTitle,
                        PostDateCreated = x.PostDateCreated,
                        PostFullVersion = x.PostFullVersion,
                        PostId = x.PostId,
                        PostIsVisible = x.PostIsVisible,
                        PostShortVersion = x.PostShortVersion,
                        PostCategory = x.PostCategory                    
                    })
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
                SR.Data = await context.Posts.Where(x => x.PostIsVisible == true).FirstOrDefaultAsync(x => x.PostId == PostID);
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
