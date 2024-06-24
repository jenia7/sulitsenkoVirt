using Virtable.UseCases.Grids.Delete;

namespace Presentation.Grids;

public class DeleteGridsDANGER(ISender mediator) : EndpointBaseAsync.WithoutRequest.WithResult<Result>
{
    [HttpDelete("api/grids")]
    public override async Task<Result> HandleAsync(CancellationToken cancellationToken = default)
    {
        DeleteAllGridsCommand command = new();
        Result result = await mediator.Send(command, cancellationToken);
        return result;
    }
}
