using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateSelectColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateSelectColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/select")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateSelectColumnRequest req, CancellationToken cancellationToken = default)
    {
        UpdateSelectColumnCommand command = new(req.GridId, req.ColumnId, req.Index, req.Variant);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
