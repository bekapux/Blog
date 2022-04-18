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
      CreateMap<Post, PostsGetDTO>();
      CreateMap<User, PostAuthorDTO>();
      CreateMap<PostCategory, PostCategoryDTO>();
      CreateMap<User, CreateUpdateUserDTO>();
      CreateMap<User, UsersGetDTO>();
      CreateMap<Role, UserRoleGetDTO>();
    }
  }
}
