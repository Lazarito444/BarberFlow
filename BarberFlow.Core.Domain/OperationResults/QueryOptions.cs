namespace BarberFlow.Core.Domain.OperationResults;

public class QueryOptions
{
    public List<FilterDefinition> Filters { get; set; } = [];
    public List<SortDefinition> Sorts { get; set; } = [];
}

public class FilterDefinition
{
    public string Field { get; set; } = string.Empty;
    public string Operator { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class SortDefinition
{
    public string Field { get; set; } = string.Empty;
    public string Direction { get; set; } = "asc";
}
