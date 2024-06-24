using Virtable.UseCases.Grids.Update;

namespace Presentation.Columns.Update;

public class UpdateNumericColumn(ISender mediator) : EndpointBaseAsync.WithRequest<UpdateNumericColumnRequest>.WithResult<Result>
{
    [HttpPut("api/grids/columns/num")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(UpdateNumericColumnRequest request, CancellationToken cancellationToken = default)
    {
        request.Deconstruct(out long GridId, out long ColumnId, out int FieldIndex, out decimal Value);

        UpdateNumericFieldCommand command = new(GridId, ColumnId, FieldIndex, Value);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
