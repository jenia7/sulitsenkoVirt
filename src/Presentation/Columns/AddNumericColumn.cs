using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddNumericColumn(ISender mediator) : EndpointBaseAsync.WithRequest<AddNumericColumnRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/num")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddNumericColumnRequest request, CancellationToken cancellationToken = default)
    {
        AddNumericColumnCommand command = new(request.GridId);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
