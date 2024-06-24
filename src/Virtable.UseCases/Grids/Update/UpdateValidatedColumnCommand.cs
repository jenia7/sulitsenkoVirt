namespace Virtable.UseCases.Grids.Update;

public record UpdateValidatedColumnCommand(
    long GridId,
    long ColumnId,
    int Index,
    string Value) : IRequest<Result>;
