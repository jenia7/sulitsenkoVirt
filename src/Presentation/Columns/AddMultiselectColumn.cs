using Virtable.UseCases.Grids.Add;

namespace Presentation.Columns;

public class AddMultiselectColumn(ISender mediator) : EndpointBaseAsync.WithRequest<AddMultiselectColumnRequest>.WithResult<Result>
{
    [HttpPost("api/grids/columns/multiselect")]
    [TranslateResultToActionResult]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<Result> HandleAsync(AddMultiselectColumnRequest request, CancellationToken cancellationToken = default)
    {
        AddMultiselectColumnCommand command = new(request.GridId, request.VariantsToSelect);

        Result result = await mediator.Send(command, cancellationToken);

        return result;
    }
}
