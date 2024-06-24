namespace Virtable.UseCases.Grids.Add;

public record AddSelectColumnCommand(long GridId, List<string> VariantsToSelect) : IRequest<Result>;
