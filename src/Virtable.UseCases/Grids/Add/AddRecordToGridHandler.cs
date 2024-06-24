using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddRecordToGridHandler(IRepository<Grid> repo) : IRequestHandler<AddRecordToGridCommand, Result>
{
    public async Task<Result> Handle(AddRecordToGridCommand command, CancellationToken cancellationToken)
    {
        var gridByIdSpec = new GetGridByIdSpec(command.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(gridByIdSpec, cancellationToken);

        if (grid is null)
        {
            //ValidationError error = new($"Cannot find a grid with the provided {command.GridId}");
            return Result.Invalid();
        }

        grid.AddRecord();

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
