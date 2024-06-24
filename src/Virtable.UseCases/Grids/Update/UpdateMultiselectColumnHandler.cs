using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Update;

internal class UpdateMultiselectColumnHandler(IRepository<Grid> repo) : IRequestHandler<UpdateMultiselectColumnCommand, Result>
{
    public async Task<Result> Handle(UpdateMultiselectColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        bool ok = false;

        if (ok)
        {
            await repo.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Invalid();
    }
}
