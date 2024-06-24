using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddStringFieldToGrid(ISender mediator) : EndpointBaseAsync.WithRequest<AddStringFieldRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/str")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddStringFieldRequest request, CancellationToken cancellationToken = default)
    {
        AddStringColumnCommand command = new(request.GridId, request.ColumnId);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
