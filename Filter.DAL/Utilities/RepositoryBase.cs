using AutoMapper;

namespace Filter.DAL
{
    public class RepositoryBase
    {
        protected readonly BlogContext _context;
        protected readonly IMapper _mapper;

        public RepositoryBase(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
