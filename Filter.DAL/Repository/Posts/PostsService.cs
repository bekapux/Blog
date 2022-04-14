using Microsoft.EntityFrameworkCore;

namespace Filter.DAL.Repository.Posts
{
    public class PostsService : RepositoryBase, IPostsService
    {
        #region Constructors
        public PostsService(BlogContext context) : base(context) { }
        #endregion

        #region Methods
        public async Task<ServiceResponse<IEnumerable<Post>>> Posts_GetAll()
        {
            var SR = new ServiceResponse<IEnumerable<Post>>();
            try
            {
                SR.Data = await context.Posts.Where(x => x.PostIsVisible == true).ToListAsync();
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
