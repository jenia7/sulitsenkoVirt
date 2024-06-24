namespace Virtable.UseCases.Grids.Add;

public record AddValidatedColumnCommand(long GridId, string Pattern) : IRequest<Result>;
