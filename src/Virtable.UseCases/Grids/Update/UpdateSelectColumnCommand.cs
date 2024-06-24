namespace Virtable.UseCases.Grids.Update;

public record UpdateSelectColumnCommand(
    long GridId,
    long ColumnId,
    int Index,
    string Variant) : IRequest<Result>;
