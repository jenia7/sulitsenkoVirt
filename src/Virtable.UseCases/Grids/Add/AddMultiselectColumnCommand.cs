namespace Virtable.UseCases.Grids.Add;

public record AddMultiselectColumnCommand(long GridId, List<string> VariantsToSelect) : IRequest<Result>;
