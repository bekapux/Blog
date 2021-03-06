using AutoMapper;
using Blog.DAL;
using Blog.DAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace Filter.DAL.Repository.Posts
{
  public class PostsService : RepositoryBase, IPostsService
  {
    #region Constructors
    public PostsService(BlogContext _context, IMapper _mapper) : base(_context, _mapper) { }
    #endregion

    #region Methods
    public async Task<ServiceResponse<IEnumerable<PostsGetDTO>>> Posts_GetAll()
    {
      var SR = new ServiceResponse<IEnumerable<PostsGetDTO>>();
      try
      {
        SR.Data= await _context.Posts
            .Where(x => x.PostIsVisible == true)
            .Include(x=> x.PostAuthorUser)
            .Include(x=> x.PostCategory)
            .Select(x => _mapper.Map<PostsGetDTO>(x)).ToListAsync();
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

    public async Task<ServiceResponse<int>> Posts_AddNew(CreateUpdatePostDTO post)
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

    public async Task<ServiceResponse<int?>> Posts_Insert_Update(CreateUpdatePostDTO updatedPost)
    {
      var SR = new ServiceResponse<int?>();
      var OldPost = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == updatedPost.PostID);
      if (OldPost != null)
      {
        OldPost.PostIsVisible = updatedPost.PostIsVisible ?? OldPost.PostIsVisible;
        OldPost.PostFullVersion = updatedPost.PostFullVersion ?? OldPost.PostFullVersion;
        OldPost.PostShortVersion = updatedPost.PostShortVersion ?? OldPost.PostShortVersion;
        OldPost.PostCategoryId = updatedPost.PostCategoryId ?? OldPost.PostCategoryId;
        OldPost.PostAuthorUserId = updatedPost.PostAuthorUserId ?? OldPost.PostAuthorUserId;
        OldPost.PostTitle = updatedPost.PostTitle ?? OldPost.PostTitle;
        SR.Data = await _context.SaveChangesAsync();
      }
      else
      {
        _context.Posts.Add(_mapper.Map<Post>(updatedPost));
        SR.Data = await _context.SaveChangesAsync();
      }
      return SR;
    }

    public async Task<ServiceResponse<int?>> Posts_DeletByID(int PostID)
    {
      var SR = new ServiceResponse<int?>();
      var PostToDelete = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == PostID);
      if (PostToDelete != null)
      {
        _context.Posts.Remove(PostToDelete);
        SR.Data = await _context.SaveChangesAsync();
      }
      else
      {
        SR.ErrorMessage = "Post Not Found";
        SR.IsSuccess = false;
      }
      return SR;
    }
    #endregion
  }
}
