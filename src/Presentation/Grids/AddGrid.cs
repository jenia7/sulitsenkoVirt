using Virtable.Core.GridAggregate;
using Virtable.UseCases.Grids.Add;

namespace Presentation.Grids;

public class AddGrid(ISender mediator) : EndpointBaseAsync.WithRequest<AddGridRequest>.WithActionResult
{
    [HttpPost("api/grids")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult> HandleAsync(AddGridRequest request, CancellationToken cancellationToken = default)
    {
        AddGridCommand command = new();

        var result = await mediator.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            Grid entity = result.Value;
            return CreatedAtRoute("GetGridById", new { entity.Id }, entity);
        }
        return BadRequest(result.ValidationErrors);
    }
}
