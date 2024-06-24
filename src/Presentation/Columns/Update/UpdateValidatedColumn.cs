using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateValidatedColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateValidatedColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/regex")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateValidatedColumnRequest req, CancellationToken cancellationToken = default)
    {
        UpdateValidatedColumnCommand command = new(req.GridId, req.ColumnId, req.Index, req.Value);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
