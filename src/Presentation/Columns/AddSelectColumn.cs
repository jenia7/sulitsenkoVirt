using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddSelectColumn(ISender mediator) : EndpointBaseAsync.WithRequest<AddSelectColumnRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/select")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddSelectColumnRequest request, CancellationToken cancellationToken = default)
    {
        AddSelectColumnCommand command = new(request.GridId, request.VariantsToSelect);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
