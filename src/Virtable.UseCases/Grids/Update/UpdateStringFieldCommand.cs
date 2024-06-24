namespace Virtable.UseCases.Grids.Update;

public record UpdateStringFieldCommand(
    long GridId,
    long ColumnId,
    int Index,
    string Value) : IRequest<Result>;
