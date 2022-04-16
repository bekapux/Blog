using AutoMapper;
using Blog.DAL;

namespace Filter.DAL
{
    public class RepositoryBase
    {
        #region Constructors
        protected readonly BlogContext _context;
        protected readonly IMapper _mapper;

        public RepositoryBase(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion
    }
}
