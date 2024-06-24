using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateStringColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateStringColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/str")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateStringColumnRequest request, CancellationToken cancellationToken = default)
    {
        request.Deconstruct(out long GridId, out long ColumnId, out int FieldIndex, out string Value);

        UpdateStringFieldCommand command = new(GridId, ColumnId, FieldIndex, Value);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
