using Virtable.Core.GridAggregate.Columns;

namespace Virtable.Core.GridAggregate;

public interface IColumnsReadRepo
{
    Task<List<Column>> GetColumnsByGridIdAsync(int gridId);

}
