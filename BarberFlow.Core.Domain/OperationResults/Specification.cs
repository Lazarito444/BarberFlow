using System.Linq.Expressions;

namespace BarberFlow.Core.Domain.OperationResults;

public class Specification<TEntity>
{

    public Expression<Func<TEntity, bool>> Criteria { get; set; } = _ => true;

    public Expression<Func<TEntity, object>>? OrderBy { get; set; }

    public List<Expression<Func<TEntity, object>>> OrderByList { get; set; } = [];

    public Expression<Func<TEntity, object>>? OrderByDescending { get; set; }

    public List<Expression<Func<TEntity, object>>> OrderByDescendingList { get; set; } = [];

    public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];

    public int? Skip { get; set; }

    public int? Take { get; set; }

    public Expression<Func<TEntity, TEntity>>? Selector { get; set; }

    public bool AsNoTracking { get; set; }
}
