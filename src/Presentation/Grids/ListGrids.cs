using Virtable.Core.GridAggregate;
using Virtable.UseCases.Grids.List;

namespace Presentation.Grids;

public class ListGrids(ISender mediator) : EndpointBaseAsync.WithoutRequest.WithResult<List<Grid>>
{
    [HttpGet("api/grids")]
    [TranslateResultToActionResult]
    [ProducesResponseType(typeof(List<Grid>), StatusCodes.Status200OK)]
    public override async Task<List<Grid>> HandleAsync(CancellationToken cancellationToken = default)
    {
        ListGridsQuery query = new();

        var result = await mediator.Send(query, cancellationToken);

        return result;
    }
}
