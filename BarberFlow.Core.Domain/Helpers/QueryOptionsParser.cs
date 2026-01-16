using BarberFlow.Core.Domain.OperationResults;

namespace BarberFlow.Core.Domain.Helpers;

public static class QueryOptionsParser
{
    public static QueryOptions Parse(string filters, string sorts)
    {
        QueryOptions options = new QueryOptions();

        if (!string.IsNullOrWhiteSpace(filters))
        {
            string[] filterItems = filters.Split(',');

            foreach (string item in filterItems)
            {
                string[] parts = item.Split(':');
                if (parts.Length == 3)
                {
                    FilterDefinition filter = new FilterDefinition
                    {
                        Field = parts[0],
                        Operator = parts[1],
                        Value = parts[2]
                    };

                    options.Filters.Add(filter);
                }
            }
        }

        if (!string.IsNullOrWhiteSpace(sorts))
        {
            string[] sortItems = sorts.Split(',');

            foreach (string item in sortItems)
            {
                string[] parts = item.Split(':');
                if (parts.Length == 2)
                {
                    SortDefinition sort = new SortDefinition
                    {
                        Field = parts[0],
                        Direction = parts[1]
                    };

                    options.Sorts.Add(sort);
                }
            }
        }


        return options;
    }
}
