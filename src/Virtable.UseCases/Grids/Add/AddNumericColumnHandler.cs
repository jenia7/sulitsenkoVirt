using Virtable.Core.GridAggregate.Columns;
using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddNumericColumnHandler(IRepository<Grid> repo) : IRequestHandler<AddNumericColumnCommand, Result>
{
    public async Task<Result> Handle(AddNumericColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        grid.AddColumn(ColumnType.Numeric);

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
