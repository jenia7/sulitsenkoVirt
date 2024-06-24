using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddEmailColumnHandler(IRepository<Grid> repo) : IRequestHandler<AddEmailColumnCommand, Result>
{
    public async Task<Result> Handle(AddEmailColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        //grid.AddEmailColumn();

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
