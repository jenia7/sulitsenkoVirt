using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtable.Core.GridAggregate;
using Virtable.UseCases.Grids.Get;

namespace Presentation.Grids;

public class GetGridById(ISender mediator) : EndpointBaseAsync.WithRequest<long>.WithResult<Result<Grid>>
{
    [HttpGet("api/grids/{id:long}", Name = "GetGridbyId")]
    [TranslateResultToActionResult]
    [ProducesResponseType(typeof(Grid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public override async Task<Result<Grid>> HandleAsync(long id, CancellationToken cancellationToken = default)
    {
        GetGridQuery query = new(id);

        var result = await mediator.Send(query, cancellationToken);

        return result;
    }
}
