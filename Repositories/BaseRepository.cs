using DB;

namespace Repositories
{
    public abstract class BaseRepository
    {
        public BaseRepository(BasicDotNetDataContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets database context.
        /// </summary>
        protected internal BasicDotNetDataContext DbContext { get; }
    }
}