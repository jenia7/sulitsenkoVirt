using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddEmailColumn(ISender mediator) : EndpointBaseAsync.WithRequest<AddEmailColumnRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/email")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddEmailColumnRequest request, CancellationToken cancellationToken = default)
    {
        AddEmailColumnCommand command = new(request.GridId);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
