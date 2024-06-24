using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddRegexValidatedColumnHandler(IRepository<Grid> repo) : IRequestHandler<AddValidatedColumnCommand, Result>
{
    public async Task<Result> Handle(AddValidatedColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null)
        {
            return Result.Invalid();
        }

        //grid.AddRegexValidatedColumn(request.Pattern);

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
