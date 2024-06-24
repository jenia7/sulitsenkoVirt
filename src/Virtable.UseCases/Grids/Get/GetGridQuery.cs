using Ardalis.Result;
using MediatR;
using Virtable.Core.GridAggregate;

namespace Virtable.UseCases.Grids.Get;

public record GetGridQuery(long Id) : IRequest<Result<Grid>>;
