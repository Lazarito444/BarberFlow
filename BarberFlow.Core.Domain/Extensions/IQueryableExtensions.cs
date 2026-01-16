using BarberFlow.Core.Domain.OperationResults;
using System.Linq.Expressions;

namespace BarberFlow.Core.Domain.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<FilterDefinition> filters)
    {
        foreach (FilterDefinition filter in filters)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.PropertyOrField(parameter, filter.Field);

            ConstantExpression constant = Expression.Constant(Convert.ChangeType(filter.Value, member.Type));

            Expression comparison = BuildExpression(member, constant, filter.Operator);

            if (comparison != null)
            {
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
                query = query.Where(lambda);
            }
        }

        return query;
    }

    private static Expression BuildExpression(Expression member, Expression constant, string op)
    {
        return op switch
        {
            "eq" => Expression.Equal(member, constant),
            "neq" => Expression.NotEqual(member, constant),
            "gt" => Expression.GreaterThan(member, constant),
            "gte" => Expression.GreaterThanOrEqual(member, constant),
            "lt" => Expression.LessThan(member, constant),
            "lte" => Expression.LessThanOrEqual(member, constant),
            "cont" => Expression.Call(
                member,
                typeof(string).GetMethod("Contains", [typeof(string)])!,
                constant
            ),
            _ => throw new InvalidOperationException("Unsupported operation"),
        };
    }

    public static IQueryable<T> ApplySorts<T>(this IQueryable<T> query, List<SortDefinition> sorts)
    {
        bool first = true;

        foreach (SortDefinition sort in sorts)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.PropertyOrField(param, sort.Field);

            LambdaExpression keySelector = Expression.Lambda(member, param);

            string method = first
                ? (sort.Direction == "desc" ? "OrderByDescending" : "OrderBy")
                : (sort.Direction == "desc" ? "ThenByDescending" : "ThenBy");

            first = false;

            query = (typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == method && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), member.Type)
                .Invoke(null, [query, keySelector]) as IQueryable<T>)!;
        }

        return query;
    }
}
