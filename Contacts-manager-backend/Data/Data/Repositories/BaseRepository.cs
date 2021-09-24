namespace Core.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext context;

        protected BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
