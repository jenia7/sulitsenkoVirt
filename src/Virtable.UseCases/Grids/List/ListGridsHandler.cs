using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.List;

internal class ListGridsHandler(IRepository<Grid> repo) : IRequestHandler<ListGridsQuery, Result<List<Grid>>>
{
    public async Task<Result<List<Grid>>> Handle(ListGridsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllGrids();
        List<Grid> grids = await repo.ListAsync(spec, cancellationToken);
        return grids;
    }
}
