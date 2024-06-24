using Ardalis.Specification;

namespace Virtable.Core.GridAggregate.Specifications;

public class GetAllGrids : Specification<Grid>
{
    public GetAllGrids()
    {
        Query.Include(e => e.Records).ThenInclude(e => e.Fields).ThenInclude(e => e.Column);
    }
}
