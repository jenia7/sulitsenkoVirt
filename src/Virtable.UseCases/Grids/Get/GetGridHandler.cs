using Ardalis.Result;
using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Get;

internal class GetGridHandler(IRepository<Grid> repo) : IRequestHandler<GetGridQuery, Result<Grid>>
{
    public async Task<Result<Grid>> Handle(GetGridQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.Id);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null) return Result<Grid>.NotFound();

        return Result<Grid>.Success(grid);
    }
}
