namespace BarberFlow.Core.Domain.OperationResults;

public class Page<T>
    where T : class
{
    public List<T> Items { get; init; } = [];
    public int TotalItems { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public bool IsEmpty => Items.Count == 0;
    public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
}
