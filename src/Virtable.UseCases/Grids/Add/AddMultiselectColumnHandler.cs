using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddMultiselectColumnHandler(IRepository<Grid> repo) : IRequestHandler<AddMultiselectColumnCommand, Result>
{
    public async Task<Result> Handle(AddMultiselectColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        HashSet<string> variantsToSelect = new(request.VariantsToSelect);
        //grid.AddMultiselectColumn(variantsToSelect);

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
