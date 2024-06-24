namespace Virtable.UseCases.Grids.Add;

public record AddEmailColumnCommand(long GridId) : IRequest<Result>;
