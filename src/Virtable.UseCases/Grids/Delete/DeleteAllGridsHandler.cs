namespace Virtable.UseCases.Grids.Delete;

internal class DeleteAllGridsHandler(IRepository<Grid> repo) : IRequestHandler<DeleteAllGridsCommand, Result>
{
    public async Task<Result> Handle(DeleteAllGridsCommand request, CancellationToken cancellationToken)
    {
        await repo.ExecuteDeleteAsync(cancellationToken);
        return Result.Success();
    }
}
