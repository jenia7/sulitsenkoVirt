using Virtable.UseCases.Grids.Add;

namespace Presentation.Grids;

public class AddRecordToGrid(ISender mediator) : EndpointBaseAsync.WithRequest<AddRecordToGridRequest>.WithResult<Result>
{
    [HttpPost("api/grids/rows")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<Result> HandleAsync(AddRecordToGridRequest request, CancellationToken cancellationToken = default)
    {
        AddRecordToGridCommand command = new(request.GridId);

        var result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
