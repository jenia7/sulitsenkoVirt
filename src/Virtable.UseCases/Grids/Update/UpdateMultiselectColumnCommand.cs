namespace Virtable.UseCases.Grids.Update;

public record UpdateMultiselectColumnCommand(
    long GridId,
    long ColumnId,
    int Index,
    List<string> Variants) : IRequest<Result>;
