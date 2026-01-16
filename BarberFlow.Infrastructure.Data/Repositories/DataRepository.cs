namespace BarberFlow.Infrastructure.Data.Repositories;

public class DataRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public DataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<TEntity> GetPage()
    {
        return _context.Set<TEntity>().ToList();
    }
}
