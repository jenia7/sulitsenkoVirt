namespace Virtable.UseCases.Grids.Update;

public record UpdateNumericFieldCommand(
    long GridId,
    long ColumnId,
    int Index,
    decimal Value) : IRequest<Result>;
