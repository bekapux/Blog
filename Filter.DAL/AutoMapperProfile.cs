using AutoMapper;
using Blog.DAL.DTO;
using Filter.DAL;

namespace Blog.DAL
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<CreateUpdatePostDTO, Post>();
      CreateMap<Post, GetPostsDTO>();
      CreateMap<User, PostAuthorDTO>();
      CreateMap<PostCategory, PostCategoryDTO>();
    }
  }
}
