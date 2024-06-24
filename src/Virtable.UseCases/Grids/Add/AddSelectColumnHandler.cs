using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddSelectColumnHandler(IRepository<Grid> repo) : IRequestHandler<AddSelectColumnCommand, Result>
{
    public async Task<Result> Handle(AddSelectColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        HashSet<string> variantsToSelect = new(request.VariantsToSelect);
        //grid.AddSelectColumn(variantsToSelect);

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
