namespace Virtable.UseCases.Grids.Update;

public record UpdateEmailColumnCommand(
    long GridId,
    long ColumnId,
    int Index,
    string Email) : IRequest<Result>;
