using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddValidatedColumn(ISender mediator) : EndpointBaseAsync.WithRequest<AddValidatedColumnRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/regex")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddValidatedColumnRequest request, CancellationToken cancellationToken = default)
    {
        AddValidatedColumnCommand command = new(request.GridId, request.Pattern);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
