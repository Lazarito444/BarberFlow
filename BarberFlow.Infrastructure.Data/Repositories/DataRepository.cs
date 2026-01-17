using BarberFlow.Core.Domain.OperationResults;
using Microsoft.EntityFrameworkCore;

namespace BarberFlow.Infrastructure.Data.Repositories;

public class DataRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public DataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountBySpecification(Specification<TEntity> specification, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        IQueryable<TEntity> aggregate = specification.Includes
            .Aggregate(_context.Set<TEntity>().AsQueryable(), (current, include)
            => current.Include(include));

        return await aggregate.CountAsync(specification.Criteria, ct);
    }

    public async Task HardDelete(TEntity entity, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task HardDelete(Guid id, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        TEntity? entity = await _context.Set<TEntity>().FindAsync([id], cancellationToken: ct);

        if (entity is null) return;

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetPage()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
}
