namespace Virtable.UseCases.Grids.Add;

public record AddNumericColumnCommand(long GridId) : IRequest<Result>;
