using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateMultiselectColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateMultiselectColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/multiselect")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateMultiselectColumnRequest req, CancellationToken cancellationToken = default)
    {
        UpdateMultiselectColumnCommand command = new(req.GridId, req.ColumnId, req.Index, req.Variants);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
