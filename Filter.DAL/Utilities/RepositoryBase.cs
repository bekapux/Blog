namespace Filter.DAL
{
    public class RepositoryBase
    {
        protected readonly BlogContext context;

        public RepositoryBase(BlogContext context)
        {
            this.context = context;
        }
    }
}
