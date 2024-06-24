namespace Virtable.UseCases.Grids.Add;

public record AddStringColumnCommand(long GridId, long ColumnId) : IRequest<Result>;
