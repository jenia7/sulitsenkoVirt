using Virtable.Core.GridAggregate.Records;
using Virtable.Core.GridAggregate.Specifications;

namespace Virtable.UseCases.Grids.Add;

internal class AddStringFieldToGridHandler(IRepository<Grid> repo) : IRequestHandler<AddStringColumnCommand, Result>
{
    public async Task<Result> Handle(AddStringColumnCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetGridByIdSpec(request.GridId);
        Grid? grid = await repo.FirstOrDefaultAsync(spec, cancellationToken);

        if (grid is null) return Result.Invalid();

        StringField field = new();
        //grid.AddField(field);

        await repo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
