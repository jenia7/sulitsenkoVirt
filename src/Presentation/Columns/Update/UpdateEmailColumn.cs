using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateEmailColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateEmailColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/email")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateEmailColumnRequest req, CancellationToken cancellationToken = default)
    {
        UpdateEmailColumnCommand command = new(req.GridId, req.ColumnId, req.Index, req.Email);

        var result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
