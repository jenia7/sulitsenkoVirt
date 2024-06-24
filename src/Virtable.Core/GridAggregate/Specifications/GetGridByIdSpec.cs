using Ardalis.Specification;

namespace Virtable.Core.GridAggregate.Specifications;

public class GetGridByIdSpec : Specification<Grid>
{
    public GetGridByIdSpec(long id)
    {
        Query.Where(e => e.Id == id)
            .Include(e => e.Records)
            .ThenInclude(e => e.Fields)
            .ThenInclude(e => e.Column);
    }
}
