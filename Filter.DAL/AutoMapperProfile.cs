using AutoMapper;
using Blog.DAL.DTO;
using Filter.DAL;

namespace Blog.DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap< CreateUpdatePostDto, Post >();
        }
    }
}
