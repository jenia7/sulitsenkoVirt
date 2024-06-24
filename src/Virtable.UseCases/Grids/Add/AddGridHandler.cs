using Virtable.Core.Factory;

namespace Virtable.UseCases.Grids.Add;

internal class AddGridHandler(IRepository<Grid> repo) : IRequestHandler<AddGridCommand, Result<Grid>>
{
    public async Task<Result<Grid>> Handle(AddGridCommand request, CancellationToken cancellationToken)
    {
        Grid grid = Factory.makeGridWithOneRecordAndOneStringField();
        grid = await repo.AddAsync(grid, cancellationToken);

        await repo.SaveChangesAsync(cancellationToken);

        return grid;
    }
}
